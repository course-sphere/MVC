# Instructor Course Management

This document details the functionality available to instructors for managing courses, including creation, module/lesson management, and submission for review, as implemented in `InstructorController.cs` and associated views.

## 1. Course Creation Flow

Instructors can create new courses through a dedicated interface.

### Key Features:
- **Course Attributes**: Instructors can define the `Title`, `Description`, `Price`, `Level`, and upload a `CourseImage` for their courses.
- **Initial Status**: Newly created courses are typically in a "Draft" status, awaiting further content and eventual submission for review.

### Related Files:
- **Controller**: `PresentationLayer/Controllers/InstructorController.cs` (actions: `Create`, `Create` POST)
- **View**: `PresentationLayer/Views/Instructor/Create.cshtml`

## 2. Course Editing and Management

Instructors can edit existing courses, including adding and removing content.

### Key Features:
- **Course Details**: Instructors can modify the course's `Title`, `Description`, `Price`, `Level`, and `CourseImage`.
- **Module Management**:
    - Instructors can add new modules to a course.
    - Instructors can delete existing modules from a course.
- **Lesson Management**:
    - Instructors can add new lessons to any module within a course.
    - Instructors can delete existing lessons from modules.

### Related Files:
- **Controller**: `PresentationLayer/Controllers/InstructorController.cs` (actions: `Edit`, `Edit` POST, `AddModule`, `DeleteModule`, `AddLesson`, `DeleteLesson`)
- **View**: `PresentationLayer/Views/Instructor/Edit.cshtml`

## 3. Instructor Dashboard

The instructor dashboard provides an overview of their courses and quick access to management functions.

### Key Features:
- **Course Listing**: Displays a list of courses owned by the instructor.
- **Management Links**: Provides links to edit courses, manage modules/lessons, and submit courses for review.

### Related Files:
- **Controller**: `PresentationLayer/Controllers/InstructorController.cs` (action: `Dashboard`)
- **View**: `PresentationLayer/Views/Instructor/Dashboard.cshtml`
- **Partial View**: `PresentationLayer/Views/Instructor/_InstructorSidebar.cshtml` (provides navigation or common actions for instructors)

## 4. Course Submission for Review

Once a course is prepared, instructors can submit it for administrative review.

### Key Features:
- **Submit Action**: A specific action is available to change a course's status to "Pending Review".

### Related Files:
- **Controller**: `PresentationLayer/Controllers/InstructorController.cs` (action: `SubmitForReview`)

## 5. Security: IDOR Protection

Insecure Direct Object Reference (IDOR) protection is implemented to ensure that instructors can only access and modify courses they own.

### Key Mechanism:
- **`IsOwnerOfCourseAsync` Check**: Before any critical operation (edit, delete, module/lesson management), a check is performed to verify that the requesting instructor is the legitimate owner of the course. This prevents unauthorized access or modification of other instructors' courses.

### Related Files:
- **Controller**: `PresentationLayer/Controllers/InstructorController.cs` (This check is integrated into relevant actions like `Edit`, `DeleteModule`, etc.)
