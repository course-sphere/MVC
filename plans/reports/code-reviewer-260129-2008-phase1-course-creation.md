# Code Review: Phase 1 - Course Creation Flow

**Date**: 2026-01-29
**Reviewer**: code-reviewer
**Score**: 6.5/10

## Scope
- Files reviewed: 5 controller/view files + 4 service/request files
- LOC analyzed: ~750
- Focus: Security, architecture, YAGNI/KISS/DRY

## Overall Assessment
Implementation follows ASP.NET MVC patterns with proper CSRF protection. However, **critical IDOR vulnerabilities** in authorization checks need immediate attention. Code is clean and readable but has security gaps in ownership verification.

---

## Critical Issues

### 1. IDOR Vulnerability - Course Edit/Submit (HIGH SEVERITY)
**Location**: `InstructorController.cs` lines 77-92, 160-172
```csharp
public async Task<IActionResult> Edit(Guid id)
{
    var courseResult = await _courseService.GetCourseByIdAsync(id);
    // NO ownership check - any instructor can view/edit ANY course
}

public async Task<IActionResult> SubmitForReview(Guid id)
{
    var result = await _courseService.SubmitCourseForReviewAsync(id);
    // NO ownership check - can submit any course for review
}
```
**Fix**: Add ownership verification in service layer:
```csharp
var userId = _service.GetUserClaim().UserId;
if (course.CreatedBy != userId) return response.SetForbidden("Not authorized");
```

### 2. IDOR Vulnerability - Module/Lesson Operations
**Location**: `ModuleService.cs` line 28-56, `LessonService.cs` line 25-55
- `CreateNewModuleForCourseAsync`: No check if user owns the course
- `DeleteModuleAsync`: No ownership check
- `CreateNewLessonForModuleAsync`: No ownership check
- `DeleteLessonAsync`: No ownership check

**Impact**: Instructor A can add/delete modules/lessons to Instructor B's courses

### 3. Missing ModelState Validation
**Location**: `InstructorController.cs` lines 96-108, 128-140
```csharp
public async Task<IActionResult> AddModule(CreateNewModuleForCourseRequest request)
{
    // Missing: if (!ModelState.IsValid) return...
    var result = await _moduleService.CreateNewModuleForCourseAsync(request);
}
```

---

## High Priority

### 4. Request Models Missing Validation Attributes
**Location**: `CreateNewCourseRequest.cs`, `CreateNewModuleForCourseRequest.cs`, `CreateNewLessonForModuleRequest.cs`
```csharp
// Current - no validation
public string Title { get; set; }

// Should be
[Required, StringLength(200, MinimumLength = 3)]
public string Title { get; set; }
```

### 5. Unused IClaimService Injection
**Location**: `InstructorController.cs` line 17, 23
```csharp
private readonly IClaimService _claimService; // Injected but NEVER used
```
Violates YAGNI - remove if not needed, or use for ownership checks

### 6. Dashboard Stats Hardcoded to Zero
**Location**: `Dashboard.cshtml` lines 6-8
```csharp
var draftCount = 0;
var pendingCount = 0;
var publishedCount = 0;
```
Stats never calculated from actual course data

---

## Medium Priority

### 7. ViewBag Usage Instead of ViewModel
**Location**: `InstructorController.cs` line 90
```csharp
ViewBag.Modules = modules;
```
Prefer strongly-typed ViewModel for type safety

### 8. Inconsistent Null Handling
**Location**: `InstructorController.cs` line 88
```csharp
var modules = modulesResult.IsSuccess ? modulesResult.Result : new List<object>();
```
Should be strongly typed `List<ModuleResponse>`

### 9. Dashboard Status Always Shows "Draft"
**Location**: `Dashboard.cshtml` line 134-136
```html
<span class="...">Draft</span>
```
Hardcoded - should use `@course.Status`

### 10. Alpine.js CDN in Scripts Section
**Location**: `Edit.cshtml` line 234
```html
<script src="https://unpkg.com/@@alpinejs/collapse@3.x.x/dist/cdn.min.js"></script>
```
Consider bundling or using specific version for stability

---

## Low Priority

### 11. DRY Violation - Repeated Modal Structure
**Location**: `Edit.cshtml` lines 173-230
Module modal and Lesson modal have identical structure. Consider partial view.

### 12. Magic Number for Index
**Location**: `Edit.cshtml` line 182
```html
<input type="hidden" name="Index" value="@(modules.Count + 1)" />
```
Index calculation duplicated (also in service) - should be service-only

---

## Positive Observations
- CSRF tokens on all POST forms
- Role-based authorization `[Authorize(Roles = "Instructor")]`
- Consistent error handling with TempData
- Clean Tailwind CSS styling
- Alpine.js for UI state management
- Soft delete pattern in services

---

## Recommended Actions

1. **[CRITICAL]** Add ownership checks in all service methods before CRUD operations
2. **[CRITICAL]** Add ModelState validation to AddModule, AddLesson, DeleteModule, DeleteLesson actions
3. **[HIGH]** Add validation attributes to all request DTOs
4. **[HIGH]** Remove or use `_claimService` in controller
5. **[MEDIUM]** Calculate actual course stats in Dashboard
6. **[MEDIUM]** Display actual course status instead of hardcoded "Draft"
7. **[LOW]** Create `CourseEditViewModel` with Course + Modules strongly typed

---

## Metrics
- Type Coverage: Good (uses typed DTOs)
- CSRF Protection: 100%
- Authorization Decorator: Present
- Ownership Verification: **MISSING**
- Input Validation: Partial

---

## Unresolved Questions
1. Should modules/lessons deletion be cascade soft-delete?
2. Is there a separate endpoint for updating course basic info (title, desc)?
3. Should lesson OrderIndex be auto-calculated or user-specified?
