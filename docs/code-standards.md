# Codebase Structure and Standards

## 1. Directory Structure
The project follows a standard MVC (Model-View-Controller) pattern with additional layers for better separation of concerns.

```
/
├── .claude/                             # Claude AI configuration and rules
├── docs/                                # Project documentation
│   ├── codebase-summary.md              # Auto-generated codebase summary
│   ├── project-overview-pdr.md          # Product Development Requirements
│   ├── code-standards.md                # Coding standards and guidelines
│   └── system-architecture.md           # High-level system architecture
├── PresentationLayer/                   # User Interface and API Controllers
│   ├── Controllers/                     # MVC Controllers
│   │   ├── InstructorController.cs      # Instructor-specific actions
│   │   └── ...
│   ├── Views/                           # CSHTML Views
│   │   ├── Instructor/                  # Instructor-specific views
│   │   │   ├── Dashboard.cshtml         # Instructor dashboard
│   │   │   ├── Create.cshtml            # Course creation form
│   │   │   ├── Edit.cshtml              # Course editing form
│   │   │   └── _InstructorSidebar.cshtml# Sidebar partial for instructors
│   │   └── Shared/                      # Shared views and partials
│   └── ViewModels/                      # Data transfer objects for views
├── BusinessLogicLayer/                  # Business logic and services
│   ├── Services/                        # Business services
│   └── Interfaces/                      # Service interfaces
├── DataAccessLayer/                     # Data access and persistence
│   ├── Models/                          # Entity models (e.g., Course, Module, Lesson)
│   ├── Repositories/                    # Data repositories
│   └── Context/                         # Database context
├── Common/                              # Shared utilities, helpers, and extensions
├── Tests/                               # Unit and integration tests
└── ...
```

## 2. Naming Conventions

### 2.1. Files and Folders
- **Folders**: PascalCase (e.g., `PresentationLayer`, `Controllers`, `Instructor`)
- **Controller Files**: `[Name]Controller.cs` (e.g., `InstructorController.cs`)
- **View Files**: `[Action].cshtml` (e.g., `Create.cshtml`, `Dashboard.cshtml`)
- **Partial Views**: `_[Name].cshtml` (e.g., `_InstructorSidebar.cshtml`)

### 2.2. C# Code
- **Classes, Interfaces, Methods, Properties**: PascalCase (e.g., `InstructorController`, `CreateCourse`, `CourseTitle`)
- **Local Variables, Method Parameters**: camelCase (e.g., `courseTitle`, `instructorId`)

## 3. Coding Guidelines

### 3.1. General Principles
- **YAGNI (You Aren't Gonna Need It)**: Avoid implementing functionality that is not immediately required.
- **KISS (Keep It Simple, Stupid)**: Favor simple and straightforward solutions over complex ones.
- **DRY (Don't Repeat Yourself)**: Avoid duplication of code; use abstraction and reusability where appropriate.

### 3.2. Code Readability
- Use meaningful and descriptive names for variables, methods, and classes.
- Keep methods concise and focused on a single responsibility.
- Add comments for complex logic or non-obvious implementations, but prefer self-documenting code.

### 3.3. Error Handling
- Implement robust error handling using `try-catch` blocks where necessary.
- Provide informative error messages to facilitate debugging and user feedback.

### 3.4. Security
- Implement appropriate security measures, such as authentication, authorization, and protection against common vulnerabilities (e.g., IDOR, XSS, CSRF).
- Example: Use `IsOwnerOfCourseAsync` for IDOR protection.

## 4. Specific to Instructor Course Management

### 4.1. Controller Actions
- **InstructorController**: Handles actions related to course creation, editing, module/lesson management, and submission for review.
- Actions should clearly map to UI interactions (e.g., `Create` for displaying the course creation form, `Create` POST for processing the form).

### 4.2. Views
- Views should be clean, separating presentation logic from business logic.
- Utilize partial views for reusable UI components (e.g., `_InstructorSidebar.cshtml`).

## 5. Architectural Patterns

### 5.1. MVC
- **Models**: Plain C# objects representing data.
- **Views**: UI templates (`.cshtml`).
- **Controllers**: Handle user input, interact with business logic, and select views.

### 5.2. Layered Architecture
- **Presentation Layer**: Handles user interaction and displays data.
- **Business Logic Layer**: Contains core business rules and operations.
- **Data Access Layer**: Manages interaction with the database.
