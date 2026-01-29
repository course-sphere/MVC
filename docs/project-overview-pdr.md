# Project Overview PDR: Course Management System

## 1. Introduction
This document outlines the Product Development Requirements (PDR) for the Course Management System, focusing initially on the "Course Creation Flow" for instructors. The system aims to provide a robust platform for educators to create, manage, and deliver courses.

## 2. Goals
- Enable instructors to efficiently create and manage course content.
- Ensure data integrity and security for course-related operations.
- Provide a clear, intuitive user experience for course creation.

## 3. Scope - Phase 1: Course Creation Flow
This phase focuses on the core functionality for instructors to set up courses, including:
- Course definition (title, description, price, level, image).
- Module and lesson management within courses.
- Submission of courses for review.

## 4. Functional Requirements

### FR1: Instructor Course Creation
- **Description**: Instructors shall be able to create new courses.
- **Acceptance Criteria**:
    - Instructor can input course `Title`, `Description`, `Price`, `Level`, and upload a `CourseImage`.
    - Newly created courses are in a "Draft" status.

### FR2: Module Management
- **Description**: Instructors shall be able to add and delete modules within a course.
- **Acceptance Criteria**:
    - Instructor can add multiple modules to a course.
    - Instructor can delete existing modules from a course.

### FR3: Lesson Management
- **Description**: Instructors shall be able to add and delete lessons within a module.
- **Acceptance Criteria**:
    - Instructor can add multiple lessons to a module.
    - Instructor can delete existing lessons from a module.

### FR4: Course Submission for Review
- **Description**: Instructors shall be able to submit a draft course for administrative review.
- **Acceptance Criteria**:
    - A "Submit for Review" action is available for draft courses.
    - Upon submission, the course status changes to "Pending Review".

### FR5: IDOR Protection
- **Description**: The system must protect against Insecure Direct Object Reference (IDOR) vulnerabilities.
- **Acceptance Criteria**:
    - All course-related operations (edit, delete, manage modules/lessons) must verify that the performing instructor is the owner of the course.

## 5. Non-Functional Requirements
- **Security**: Implementation of IDOR protection for all course management operations.
- **Performance**: Course creation and management operations should be responsive.
- **Usability**: Intuitive user interface for instructors.

## 6. Technical Constraints & Dependencies
- **Platform**: ASP.NET Core MVC (based on `InstructorController.cs` and `.cshtml` views).
- **Database**: Assumed relational database for course, module, and lesson data.
- **Image Storage**: Mechanism for storing `CourseImage` files.

## 7. Implementation Guidance (Phase 1)
- **Controller**: `InstructorController` handles all instructor-specific course management actions.
- **Views**: Dedicated views (`Dashboard.cshtml`, `Create.cshtml`, `Edit.cshtml`, `_InstructorSidebar.cshtml`) for instructor UI.
- **Security**: Implement `IsOwnerOfCourseAsync` method for authorization checks.

## 8. Open Questions / Future Considerations
- Detailed validation rules for course fields.
- Handling of media files for lessons.
- Workflow for administrative course review and approval/rejection.
- UI/UX for reordering modules and lessons.
