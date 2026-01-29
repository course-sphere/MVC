# Phase 1: Course Creation Flow

## Context Links
- [Scout Report](scout/scout-codebase-report.md)
- [CourseService](../../BusinessLayer/Services/CourseService.cs)
- [ModuleService](../../BusinessLayer/Services/ModuleService.cs)
- [LessonService](../../BusinessLayer/Services/LessonService.cs)

## Overview
- **Priority:** P1
- **Status:** completed (2026-01-29)
- **Effort:** 2.5h
- **Description:** Implement complete course creation flow for instructors including course details, modules, and lessons

## Key Insights
- CourseService.CreateNewCourseAsync exists - handles image upload to Firebase
- ModuleService and LessonService have CRUD operations ready
- Course status workflow: Draft -> PendingApproval -> Published/Rejected
- Instructor views exist but are empty templates (Create.cshtml, Dashboard.cshtml)

## Requirements

### Functional
- Instructor can create new course with title, description, price, level, language
- Instructor can upload course thumbnail image
- Instructor can add/edit/delete modules within course
- Instructor can add/edit/delete lessons within modules
- Instructor can reorder modules and lessons
- Instructor can submit course for review

### Non-Functional
- Form validation on client and server
- Image preview before upload
- Responsive design matching existing admin UI

## Architecture

```
User Flow:
Instructor -> Create Course Form -> Add Modules -> Add Lessons -> Submit for Review

Controller Actions:
InstructorController
├── Dashboard() -> GET instructor courses
├── Create() -> GET create form
├── Create(request) -> POST new course
├── Edit(id) -> GET course builder
├── AddModule(request) -> POST new module
├── AddLesson(request) -> POST new lesson
└── SubmitForReview(id) -> POST submit course
```

## Related Code Files

### Modify
| File | Purpose |
|------|---------|
| `PresentationLayer/Controllers/InstructorController.cs` | Add controller if missing, implement actions |
| `PresentationLayer/Views/Instructor/Create.cshtml` | Course creation form |
| `PresentationLayer/Views/Instructor/Dashboard.cshtml` | Instructor dashboard with course list |
| `PresentationLayer/Views/Instructor/Edit.cshtml` | Course builder with modules/lessons |

### Create
| File | Purpose |
|------|---------|
| `PresentationLayer/Controllers/InstructorController.cs` | New controller (if not exists) |
| `PresentationLayer/Views/Instructor/CourseBuilder.cshtml` | Interactive module/lesson editor |
| `PresentationLayer/Views/Shared/_InstructorSidebar.cshtml` | Sidebar for instructor portal |

## Implementation Steps

### Step 1: Create InstructorController (1h)
1. Create controller with `[Authorize(Roles = "Instructor")]`
2. Inject ICourseService, IModuleService, ILessonService, IClaimService
3. Implement actions:
   - `Dashboard()` - List instructor's courses via GetCoursesByInstructorAsync
   - `Create()` GET - Return create form view
   - `Create(CreateNewCourseRequest)` POST - Call CreateNewCourseAsync, redirect to Edit
   - `Edit(Guid id)` GET - Load course with modules/lessons for builder
   - `AddModule(CreateNewModuleForCourseRequest)` POST - Add module to course
   - `UpdateModule(UpdateModuleRequest)` POST - Update module
   - `DeleteModule(Guid id)` POST - Soft delete module
   - `AddLesson(CreateNewLessonForModuleRequest)` POST - Add lesson to module
   - `UpdateLesson(UpdateLessonRequest)` POST - Update lesson
   - `DeleteLesson(Guid id)` POST - Soft delete lesson
   - `SubmitForReview(Guid id)` POST - Call SubmitCourseForReviewAsync

### Step 2: Create Instructor Dashboard View (30m)
1. Update Dashboard.cshtml with:
   - Stats cards (total courses, pending, published)
   - Course list table with status badges
   - Action buttons (Edit, Submit, View)
2. Use _AdminLayout.cshtml pattern for consistency
3. Alpine.js for interactive elements

### Step 3: Create Course Form (30m)
1. Update Create.cshtml with form:
   - Title, Description (textarea)
   - Price, Level (dropdown), Language (dropdown)
   - Image upload with preview
   - Submit button
2. Form validation with data annotations
3. Image preview using FileReader API

### Step 4: Course Builder View (30m)
1. Create CourseBuilder.cshtml or update Edit.cshtml:
   - Course info header (editable)
   - Module accordion with drag-drop reorder
   - Lesson list within each module
   - Add Module/Lesson modals
   - Delete confirmations
2. Alpine.js for accordion, modals, drag-drop

## Todo List
- [x] Create InstructorController with all actions
- [x] Implement Dashboard.cshtml with course list
- [x] Implement Create.cshtml with course form
- [x] Implement Edit.cshtml (CourseBuilder) with module/lesson management
- [x] Add client-side validation
- [x] Add image preview functionality
- [x] Test complete flow: Create -> Add Modules -> Add Lessons -> Submit

## Success Criteria
- [ ] Instructor can login and access /Instructor/Dashboard
- [ ] Instructor can create new course with image upload
- [ ] Instructor can add modules to course
- [ ] Instructor can add lessons to modules
- [ ] Instructor can submit course for admin review
- [ ] All forms validate input correctly
- [ ] UI matches existing admin portal style

## Risk Assessment
| Risk | Impact | Mitigation |
|------|--------|------------|
| Firebase upload fails | High | Add error handling, fallback to local storage |
| Large image uploads slow | Medium | Add file size limit (5MB), compress on client |
| Complex nested forms | Medium | Use Alpine.js components, step-by-step wizard |

## Security Considerations
- Authorize attribute on all controller actions
- Validate instructor owns course before edit
- Sanitize file uploads (type, size validation)
- CSRF protection via AntiForgeryToken

## Next Steps
After completion:
1. Proceed to Phase 2: Student Learning Flow
2. Admin can review submitted courses via existing flow
