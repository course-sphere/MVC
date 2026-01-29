# Phase 2: Student Learning Flow

## Context Links
- [Scout Report](scout/scout-codebase-report.md)
- [EnrollmentService](../../BusinessLayer/Services/EnrollmentService.cs)
- [UserLessonProgressService](../../BusinessLayer/Services/UserLessonProgressService.cs)
- [CourseService](../../BusinessLayer/Services/CourseService.cs)

## Overview
- **Priority:** P1
- **Status:** pending
- **Effort:** 3h
- **Description:** Implement student learning experience - browse courses, enroll, view lessons, track progress

## Key Insights
- EnrollmentService.EnrollStudentDirectlyAsync creates enrollment + initializes lesson progress
- UserLessonProgressService tracks: LastWatchedSecond, CompletionPercent, IsCompleted
- CourseService.GetEnrolledCoursesForStudentAsync retrieves student's courses
- CourseService.GetCourseDetailForStudentAsync returns course with modules/lessons
- Need StudentController and student-facing views

## Requirements

### Functional
- Student can browse published courses
- Student can view course details (description, modules, instructor)
- Student can enroll in course (free courses: instant, paid: after payment)
- Student can view enrolled courses list ("My Courses")
- Student can access lessons within enrolled course
- Student can mark lessons as complete
- Student can see progress percentage on course and lesson level
- Student can resume from last watched position (video lessons)

### Non-Functional
- Smooth video playback with progress tracking
- Progress auto-saves every 30 seconds
- Mobile-responsive learning interface
- Fast page loads with lazy content loading

## Architecture

```
User Flow:
Student -> Browse Courses -> Course Detail -> Enroll -> Learn -> Mark Complete

Controller Actions:
StudentController
├── Index() -> Browse all published courses
├── CourseDetail(id) -> View course info (pre-enroll)
├── Enroll(id) -> POST enroll in course
├── MyCourses() -> List enrolled courses
├── Learn(courseId) -> Learning interface
├── Lesson(lessonId) -> Lesson content
├── UpdateProgress(request) -> POST update watch progress
└── MarkComplete(lessonId) -> POST mark lesson done

Data Flow:
Lesson View -> Alpine.js Timer -> POST /Student/UpdateProgress
            -> Click "Complete" -> POST /Student/MarkComplete
            -> Updates Enrollment.ProgressPercent
```

## Related Code Files

### Modify
| File | Purpose |
|------|---------|
| `BusinessLayer/Services/CourseService.cs` | Add GetPublishedCoursesAsync if needed |
| `PresentationLayer/Views/Home/Index.cshtml` | Add course browsing section |

### Create
| File | Purpose |
|------|---------|
| `PresentationLayer/Controllers/StudentController.cs` | Student actions |
| `PresentationLayer/Views/Student/Index.cshtml` | Browse courses page |
| `PresentationLayer/Views/Student/CourseDetail.cshtml` | Course preview before enroll |
| `PresentationLayer/Views/Student/MyCourses.cshtml` | Enrolled courses grid |
| `PresentationLayer/Views/Student/Learn.cshtml` | Learning interface with sidebar |
| `PresentationLayer/Views/Student/Dashboard.cshtml` | Student stats |
| `PresentationLayer/Views/Shared/_StudentLayout.cshtml` | Student portal layout |
| `PresentationLayer/Views/Shared/_StudentSidebar.cshtml` | Student navigation |

## Implementation Steps

### Step 1: Create StudentController (1h)
1. Create controller with `[Authorize(Roles = "Student")]`
2. Inject services: ICourseService, IEnrollmentService, IUserLessonProgressService, ILessonService, IClaimService
3. Implement actions:

```csharp
// Browse courses (allow anonymous)
[AllowAnonymous]
public async Task<IActionResult> Index()
// Course detail (allow anonymous for preview)
[AllowAnonymous]
public async Task<IActionResult> CourseDetail(Guid id)
// Enroll in course
[HttpPost]
public async Task<IActionResult> Enroll(Guid courseId)
// My enrolled courses
public async Task<IActionResult> MyCourses()
// Learning interface (course + sidebar)
public async Task<IActionResult> Learn(Guid courseId, Guid? lessonId)
// Update progress (AJAX)
[HttpPost]
public async Task<IActionResult> UpdateProgress(UpdateUserLessonProgressRequest request)
// Mark lesson complete (AJAX)
[HttpPost]
public async Task<IActionResult> MarkComplete(Guid lessonId)
```

### Step 2: Create Browse Courses View (30m)
1. Create Student/Index.cshtml:
   - Course grid with cards (image, title, price, level, instructor)
   - Filter by level, price (free/paid)
   - Search by title
2. Use _Layout.cshtml (public layout)
3. Alpine.js for filters

### Step 3: Create Course Detail View (30m)
1. Create Student/CourseDetail.cshtml:
   - Hero section with course image
   - Course info (title, description, instructor, price)
   - Module/lesson preview (collapsed, show count)
   - Enroll button (or "Go to Course" if already enrolled)
   - Reviews/ratings placeholder

### Step 4: Create My Courses View (20m)
1. Create Student/MyCourses.cshtml:
   - Grid of enrolled courses
   - Progress bar on each card
   - "Continue Learning" button
   - Filter: All, In Progress, Completed

### Step 5: Create Learning Interface (40m)
1. Create Student/Learn.cshtml:
   - Left sidebar: Module/lesson navigation with progress indicators
   - Main content: Lesson content (video/text/quiz)
   - Progress bar at top
   - "Mark Complete" button
   - Next/Previous lesson navigation
2. Alpine.js for:
   - Sidebar collapse/expand
   - Auto-save progress timer (every 30s)
   - Lesson completion state

### Step 6: Create Student Layout (20m)
1. Create _StudentLayout.cshtml based on _AdminLayout.cshtml
2. Create _StudentSidebar.cshtml with:
   - Dashboard, My Courses, Browse, Profile links
   - Active state highlighting

## Todo List
- [ ] Create StudentController with all actions
- [ ] Implement Index.cshtml - browse courses
- [ ] Implement CourseDetail.cshtml - pre-enrollment view
- [ ] Implement MyCourses.cshtml - enrolled courses
- [ ] Implement Learn.cshtml - learning interface
- [ ] Create _StudentLayout.cshtml and _StudentSidebar.cshtml
- [ ] Add progress tracking with auto-save
- [ ] Add "Mark Complete" functionality
- [ ] Test complete flow: Browse -> Enroll -> Learn -> Complete

## Success Criteria
- [ ] Student can browse published courses at /Student
- [ ] Student can view course details before enrolling
- [ ] Student can enroll in free courses instantly
- [ ] Student can view enrolled courses at /Student/MyCourses
- [ ] Student can access learning interface at /Student/Learn/{id}
- [ ] Progress auto-saves while viewing lessons
- [ ] Student can mark lessons complete
- [ ] Course progress percentage updates correctly
- [ ] UI is responsive and matches platform style

## Risk Assessment
| Risk | Impact | Mitigation |
|------|--------|------------|
| Video not loading | High | Add fallback player, loading states |
| Progress not saving | Medium | Debounce saves, show save indicator |
| Slow course loading | Medium | Lazy load modules, paginate lessons |
| Enrollment race condition | Low | Check existing enrollment before create |

## Security Considerations
- Verify student enrolled before accessing Learn page
- Validate lessonId belongs to enrolled course
- Rate limit UpdateProgress endpoint (prevent spam)
- Don't expose lesson content in CourseDetail (preview only)

## Next Steps
After completion:
1. Proceed to Phase 3: Dashboard Implementation
2. Add payment integration for paid courses (future)
3. Add certificate generation on completion (future)
