# Scout Report: Demo Course/Student/Dashboard

## Architecture
- ASP.NET MVC 3-tier: DataAccessLayer → BusinessLayer → PresentationLayer
- Repository + UoW pattern
- JWT auth with cookie-based session
- Firebase for storage, AutoMapper for DTOs

## Key Entities (DataAccessLayer/Entities/)
- `User.cs`: UserId, FullName, Email, PasswordHash, Role (Admin/Instructor/Student), Enrollments, Wallet
- `Course.cs`: Course entity with status workflow
- `Enrollment.cs`: User-Course relationship
- `UserLessonProgress.cs`: Student progress tracking
- `Module.cs`, `Lesson.cs`, `LessonItem.cs`: Course content structure
- `GradedItem.cs`, `GradedAttempt.cs`: Quiz/assessment system
- `Payment.cs`, `Wallet.cs`: Payment handling

## Business Services (BusinessLayer/Services/)
- `CourseService.cs`: CRUD, GetByInstructor, GetEnrolledForStudent, Approve, SubmitForReview
- `AuthService.cs`: Login, Register with HMACSHA512 hashing + JWT
- `EnrollmentService.cs`: Student course enrollment
- `UserLessonProgressService.cs`: Track learning progress
- `ModuleService.cs`, `LessonService.cs`: Content management

## Presentation (PresentationLayer/)
### Controllers
- `AuthController.cs`: Login/Register
- `HomeController.cs`: Homepage
- `InstructorController.cs` (implied): Course CRUD, Dashboard

### Views
- `Views/Auth/`: Login.cshtml, Register.cshtml
- `Views/Instructor/`: Create.cshtml, Dashboard.cshtml, Edit.cshtml, EditQuiz.cshtml, Index.cshtml
- `Views/Shared/`: _Layout.cshtml, _AdminLayout.cshtml, _Header, _Footer, _Sidebar

### UI Stack
- Tailwind CSS + Flowbite (component lib)
- Alpine.js (reactive UI)
- Font Awesome icons

### Routing (Program.cs)
- Cookie auth: LoginPath=/Auth/Login
- Default: {controller=Home}/{action=Index}/{id?}

## Existing Demo-Ready Features
1. **Course Creation**: InstructorController + Create.cshtml + CourseService.CreateNewCourseAsync
2. **Student Learning**: Enrollment system, UserLessonProgress, lesson views (need views)
3. **Dashboard**: Instructor/Dashboard.cshtml exists (need student dashboard)

## Gaps for Demo
- No Student-facing views for enrolled courses/lessons
- No StudentController or student dashboard
- CourseDetail view for students missing
- Progress visualization needs implementation
