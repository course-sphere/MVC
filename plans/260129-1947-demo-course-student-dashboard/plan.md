---
title: "Demo: Course Creation, Student Learning & Dashboards"
description: "Implement 3 demo flows for Online Learning Platform"
status: pending
priority: P1
effort: 8h
branch: master
tags: [demo, course, student, dashboard, mvc]
created: 2026-01-29
---

# Demo Implementation Plan

## Overview
Implement 3 complete demo flows for the Online Learning Platform:
1. **Course Creation** - Instructor creates course with modules/lessons
2. **Student Learning** - Student enrolls, views lessons, tracks progress
3. **Dashboard** - Role-based dashboards (Admin/Instructor/Student)

## Architecture
- ASP.NET MVC 3-tier: DataAccessLayer -> BusinessLayer -> PresentationLayer
- UI: Tailwind CSS + Flowbite + Alpine.js
- Auth: Cookie-based JWT with role claims

## Phases

| Phase | Description | Effort | Status |
|-------|-------------|--------|--------|
| [Phase 1](phase-01-course-creation-flow.md) | Course Creation Flow | 2.5h | completed |
| [Phase 2](phase-02-student-learning-flow.md) | Student Learning Flow | 3h | pending |
| [Phase 3](phase-03-dashboard-implementation.md) | Dashboard Implementation | 2.5h | pending |

## Key Dependencies
- Existing entities: Course, Module, Lesson, Enrollment, UserLessonProgress
- Services: CourseService, EnrollmentService, UserLessonProgressService
- Layout: _AdminLayout.cshtml, _Layout.cshtml

## File Structure (New)
```
PresentationLayer/
├── Controllers/
│   ├── InstructorController.cs    (update)
│   ├── StudentController.cs       (create)
│   └── AdminController.cs         (create)
└── Views/
    ├── Instructor/
    │   ├── Create.cshtml          (update)
    │   ├── Dashboard.cshtml       (update)
    │   └── CourseBuilder.cshtml   (create)
    ├── Student/
    │   ├── Index.cshtml           (create)
    │   ├── MyCourses.cshtml       (create)
    │   ├── Learn.cshtml           (create)
    │   └── Dashboard.cshtml       (create)
    ├── Admin/
    │   └── Dashboard.cshtml       (create)
    └── Shared/
        ├── _StudentLayout.cshtml  (create)
        └── _StudentSidebar.cshtml (create)
```

## Success Criteria
- [ ] Instructor can create course with modules/lessons via UI
- [ ] Student can browse, enroll, and track learning progress
- [ ] Each role has functional dashboard with relevant metrics
- [ ] Consistent UI using Tailwind + Flowbite + Alpine.js
- [ ] Role-based authorization enforced on all routes

## Validation Summary

**Validated:** 2026-01-29
**Questions asked:** 4

### Confirmed Decisions
- **Paid courses:** Skip for demo - free enrollment only
- **Video player:** YouTube embed with JS API for progress
- **Demo data:** DB seed script with sample courses/modules/lessons
- **Dashboard charts:** Static stats only, no Chart.js for MVP

### Action Items
- [ ] Update Phase 2: Remove paid course handling, add YouTube embed
- [ ] Add seed script task to Phase 1 or create Phase 0
- [ ] Update Phase 3: Remove Chart.js implementation
