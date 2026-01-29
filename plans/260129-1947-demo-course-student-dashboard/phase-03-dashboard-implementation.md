# Phase 3: Dashboard Implementation

## Context Links
- [Scout Report](scout/scout-codebase-report.md)
- [_AdminSidebar.cshtml](../../PresentationLayer/Views/Shared/_AdminSidebar.cshtml)
- [_AdminLayout.cshtml](../../PresentationLayer/Views/Shared/_AdminLayout.cshtml)
- [CourseService](../../BusinessLayer/Services/CourseService.cs)
- [EnrollmentService](../../BusinessLayer/Services/EnrollmentService.cs)

## Overview
- **Priority:** P1
- **Status:** pending
- **Effort:** 2.5h
- **Description:** Implement role-based dashboards for Admin, Instructor, and Student with relevant metrics and actions

## Key Insights
- _AdminLayout.cshtml and _AdminSidebar.cshtml exist - good patterns to follow
- Admin sidebar references: Dashboard, Statistics, PendingCourses, Users, Payments, Reports
- CourseService has GetAllCourseForAdminAsync, GetCoursesByInstructorAsync
- EnrollmentService has GetStudentEnrollmentsAsync
- Need to aggregate stats via services or create dashboard-specific methods

## Requirements

### Functional

**Admin Dashboard:**
- Total users count (by role breakdown)
- Total courses count (by status)
- Total revenue (from payments)
- Pending courses requiring review (quick action)
- Recent enrollments list
- Activity timeline

**Instructor Dashboard:**
- Total courses created
- Published/Draft/Pending/Rejected counts
- Total students enrolled across courses
- Total earnings from course sales
- Recent enrollments in their courses
- Course performance (completion rates)

**Student Dashboard:**
- Enrolled courses count
- Completed courses count
- Current progress overview
- Continue learning (most recent course)
- Certificates earned (placeholder)
- Recommended courses

### Non-Functional
- Dashboard loads < 2 seconds
- Stats use efficient DB queries (no N+1)
- Consistent card-based design
- Mobile-responsive grid

## Architecture

```
Dashboard Data Flow:
Controller -> Service -> Repository (aggregate queries) -> ViewModel -> View

ViewModels:
├── AdminDashboardViewModel
│   ├── TotalUsers, UsersByRole
│   ├── TotalCourses, CoursesByStatus
│   ├── TotalRevenue, RecentPayments
│   └── PendingCoursesCount, RecentEnrollments
├── InstructorDashboardViewModel
│   ├── MyCourses, CoursesByStatus
│   ├── TotalStudents, TotalEarnings
│   └── RecentEnrollments, CourseStats
└── StudentDashboardViewModel
    ├── EnrolledCount, CompletedCount
    ├── InProgressCourses, RecentActivity
    └── ContinueLearning, RecommendedCourses
```

## Related Code Files

### Modify
| File | Purpose |
|------|---------|
| `PresentationLayer/Views/Instructor/Dashboard.cshtml` | Update with stats |
| `BusinessLayer/Services/CourseService.cs` | Add dashboard stats methods |
| `BusinessLayer/Services/EnrollmentService.cs` | Add stats methods |

### Create
| File | Purpose |
|------|---------|
| `PresentationLayer/Controllers/AdminController.cs` | Admin actions |
| `PresentationLayer/Views/Admin/Index.cshtml` | Admin dashboard |
| `PresentationLayer/Views/Student/Dashboard.cshtml` | Student dashboard |
| `PresentationLayer/ViewModels/AdminDashboardViewModel.cs` | Admin stats model |
| `PresentationLayer/ViewModels/InstructorDashboardViewModel.cs` | Instructor stats |
| `PresentationLayer/ViewModels/StudentDashboardViewModel.cs` | Student stats |
| `BusinessLayer/IServices/IDashboardService.cs` | Dashboard service interface |
| `BusinessLayer/Services/DashboardService.cs` | Aggregate stats service |

## Implementation Steps

### Step 1: Create DashboardService (45m)
1. Create IDashboardService interface:
```csharp
public interface IDashboardService
{
    Task<AdminDashboardStats> GetAdminStatsAsync();
    Task<InstructorDashboardStats> GetInstructorStatsAsync(Guid instructorId);
    Task<StudentDashboardStats> GetStudentStatsAsync(Guid studentId);
}
```

2. Create DashboardService with aggregate queries:
   - Use GroupBy for status counts
   - Use Sum for revenue totals
   - Use efficient single-query aggregations where possible

3. Register in BLLDependencies.cs

### Step 2: Create AdminController & Dashboard (45m)
1. Create AdminController with `[Authorize(Roles = "Admin")]`
2. Inject IDashboardService, ICourseService
3. Implement Index action returning AdminDashboardViewModel

4. Create Admin/Index.cshtml:
   - Stats row: Users, Courses, Revenue, Pending
   - Pending courses table with Approve/Reject buttons
   - Recent enrollments list
   - Charts placeholder (Chart.js ready)

5. Layout: Use _AdminLayout.cshtml (already exists)

### Step 3: Update Instructor Dashboard (30m)
1. Update InstructorController.Dashboard action
2. Pass InstructorDashboardViewModel to view

3. Update Instructor/Dashboard.cshtml:
   - Stats cards: Total Courses, Students, Earnings
   - Course status breakdown (Draft/Pending/Published)
   - Recent enrollments in your courses
   - Course cards with quick actions

### Step 4: Create Student Dashboard (30m)
1. Add Dashboard action to StudentController
2. Pass StudentDashboardViewModel to view

3. Create Student/Dashboard.cshtml:
   - Welcome message with user name
   - Stats: Enrolled, Completed, In Progress
   - "Continue Learning" - resume last course
   - Progress overview (circular progress)
   - Recently accessed courses
   - Recommended courses section

### Step 5: Create ViewModels (20m)
1. Create ViewModels folder if not exists
2. Create:

```csharp
// AdminDashboardViewModel.cs
public class AdminDashboardViewModel
{
    public int TotalUsers { get; set; }
    public int TotalInstructors { get; set; }
    public int TotalStudents { get; set; }
    public int TotalCourses { get; set; }
    public int PendingCourses { get; set; }
    public int PublishedCourses { get; set; }
    public decimal TotalRevenue { get; set; }
    public List<EnrollmentSummary> RecentEnrollments { get; set; }
    public List<CourseSummary> PendingCoursesList { get; set; }
}

// InstructorDashboardViewModel.cs
public class InstructorDashboardViewModel
{
    public int TotalCourses { get; set; }
    public int DraftCourses { get; set; }
    public int PendingCourses { get; set; }
    public int PublishedCourses { get; set; }
    public int TotalStudents { get; set; }
    public decimal TotalEarnings { get; set; }
    public List<CourseWithStats> Courses { get; set; }
    public List<EnrollmentSummary> RecentEnrollments { get; set; }
}

// StudentDashboardViewModel.cs
public class StudentDashboardViewModel
{
    public int EnrolledCount { get; set; }
    public int CompletedCount { get; set; }
    public int InProgressCount { get; set; }
    public CourseProgress ContinueLearning { get; set; }
    public List<CourseProgress> RecentCourses { get; set; }
    public List<CourseCard> RecommendedCourses { get; set; }
}
```

## Todo List
- [ ] Create IDashboardService interface
- [ ] Implement DashboardService with stats methods
- [ ] Register DashboardService in DI
- [ ] Create AdminController
- [ ] Implement Admin/Index.cshtml dashboard
- [ ] Update InstructorController.Dashboard
- [ ] Update Instructor/Dashboard.cshtml
- [ ] Add StudentController.Dashboard action
- [ ] Create Student/Dashboard.cshtml
- [ ] Create all ViewModel classes
- [ ] Test all three dashboards with real data

## Success Criteria
- [ ] Admin can view platform-wide stats at /Admin
- [ ] Admin sees pending courses with action buttons
- [ ] Instructor can view their stats at /Instructor/Dashboard
- [ ] Instructor sees breakdown of course statuses
- [ ] Student can view learning stats at /Student/Dashboard
- [ ] Student sees "Continue Learning" card
- [ ] All dashboards load within 2 seconds
- [ ] Stats are accurate and update in real-time
- [ ] UI consistent across all dashboards

## Risk Assessment
| Risk | Impact | Mitigation |
|------|--------|------------|
| Slow dashboard load | High | Use efficient aggregate queries, cache stats |
| N+1 query problem | Medium | Use Include/ThenInclude, project to DTOs |
| Stats mismatch | Medium | Unit test aggregation logic |
| Missing data edge cases | Low | Handle null/empty states gracefully |

## Security Considerations
- Strict role-based authorization on each controller
- Instructor can only see their own course stats
- Student can only see their own progress
- Admin stats don't expose individual user data
- No sensitive payment details in dashboards

## Next Steps
After completion:
1. Demo is ready for presentation
2. Future: Add Chart.js visualizations
3. Future: Export reports to PDF/Excel
4. Future: Email notifications for important events
