using BusinessLayer.IServices;
using BusinessLayer.Requests.Course;
using BusinessLayer.Requests.Module;
using BusinessLayer.Requests.Lesson;
using BusinessLayer.Responses.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Instructor")]
    public class InstructorController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IModuleService _moduleService;
        private readonly ILessonService _lessonService;
        private readonly IClaimService _claimService;

        public InstructorController(
            ICourseService courseService,
            IModuleService moduleService,
            ILessonService lessonService,
            IClaimService claimService)
        {
            _courseService = courseService;
            _moduleService = moduleService;
            _lessonService = lessonService;
            _claimService = claimService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Dashboard));
        }

        public async Task<IActionResult> Dashboard()
        {
            var result = await _courseService.GetCoursesByInstructorAsync();
            if (!result.IsSuccess)
            {
                TempData["Error"] = result.ErrorMessage;
                return View(new List<CourseResponse>());
            }
            var courses = result.Result as List<CourseResponse> ?? new List<CourseResponse>();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewCourseRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please fill in all required fields.";
                return View(request);
            }

            var result = await _courseService.CreateNewCourseAsync(request);
            if (!result.IsSuccess)
            {
                TempData["Error"] = result.ErrorMessage;
                return View(request);
            }

            TempData["Success"] = "Course created successfully!";
            var courseId = (Guid)result.Result;
            return RedirectToAction(nameof(Edit), new { id = courseId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (!await IsOwnerOfCourseAsync(id))
            {
                TempData["Error"] = "You are not authorized to edit this course.";
                return RedirectToAction(nameof(Dashboard));
            }

            var courseResult = await _courseService.GetCourseByIdAsync(id);
            if (!courseResult.IsSuccess)
            {
                TempData["Error"] = "Course not found.";
                return RedirectToAction(nameof(Dashboard));
            }

            var modulesResult = await _moduleService.GetModulesByCourseAsync(id);
            var course = courseResult.Result as CourseResponse;
            var modules = modulesResult.IsSuccess ? modulesResult.Result : new List<object>();

            ViewBag.Modules = modules;
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddModule(CreateNewModuleForCourseRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please fill in all required fields.";
                return RedirectToAction(nameof(Edit), new { id = request.CourseId });
            }

            if (!await IsOwnerOfCourseAsync(request.CourseId))
            {
                TempData["Error"] = "You are not authorized to modify this course.";
                return RedirectToAction(nameof(Dashboard));
            }

            var result = await _moduleService.CreateNewModuleForCourseAsync(request);
            if (!result.IsSuccess)
            {
                TempData["Error"] = result.ErrorMessage;
            }
            else
            {
                TempData["Success"] = "Module added successfully!";
            }
            return RedirectToAction(nameof(Edit), new { id = request.CourseId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteModule(Guid id, Guid courseId)
        {
            if (!await IsOwnerOfCourseAsync(courseId))
            {
                TempData["Error"] = "You are not authorized to modify this course.";
                return RedirectToAction(nameof(Dashboard));
            }

            var result = await _moduleService.DeleteModuleAsync(id);
            if (!result.IsSuccess)
            {
                TempData["Error"] = result.ErrorMessage;
            }
            else
            {
                TempData["Success"] = "Module deleted successfully!";
            }
            return RedirectToAction(nameof(Edit), new { id = courseId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLesson(CreateNewLessonForModuleRequest request, Guid courseId)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please fill in all required fields.";
                return RedirectToAction(nameof(Edit), new { id = courseId });
            }

            if (!await IsOwnerOfCourseAsync(courseId))
            {
                TempData["Error"] = "You are not authorized to modify this course.";
                return RedirectToAction(nameof(Dashboard));
            }

            var result = await _lessonService.CreateNewLessonForModuleAsync(request);
            if (!result.IsSuccess)
            {
                TempData["Error"] = result.ErrorMessage;
            }
            else
            {
                TempData["Success"] = "Lesson added successfully!";
            }
            return RedirectToAction(nameof(Edit), new { id = courseId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteLesson(Guid id, Guid courseId)
        {
            if (!await IsOwnerOfCourseAsync(courseId))
            {
                TempData["Error"] = "You are not authorized to modify this course.";
                return RedirectToAction(nameof(Dashboard));
            }

            var result = await _lessonService.DeleteLessonAsync(id);
            if (!result.IsSuccess)
            {
                TempData["Error"] = result.ErrorMessage;
            }
            else
            {
                TempData["Success"] = "Lesson deleted successfully!";
            }
            return RedirectToAction(nameof(Edit), new { id = courseId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLesson(Guid lessonId, UpdateLessonRequest request, Guid courseId)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please fill in all required fields.";
                return RedirectToAction(nameof(Edit), new { id = courseId });
            }

            if (!await IsOwnerOfCourseAsync(courseId))
            {
                TempData["Error"] = "You are not authorized to modify this course.";
                return RedirectToAction(nameof(Dashboard));
            }

            var result = await _lessonService.UpdateLessonAsync(lessonId, request);
            if (!result.IsSuccess)
            {
                TempData["Error"] = result.ErrorMessage;
            }
            else
            {
                TempData["Success"] = "Lesson updated successfully!";
            }
            return RedirectToAction(nameof(Edit), new { id = courseId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitForReview(Guid id)
        {
            if (!await IsOwnerOfCourseAsync(id))
            {
                TempData["Error"] = "You are not authorized to submit this course.";
                return RedirectToAction(nameof(Dashboard));
            }

            var result = await _courseService.SubmitCourseForReviewAsync(id);
            if (!result.IsSuccess)
            {
                TempData["Error"] = result.ErrorMessage;
            }
            else
            {
                TempData["Success"] = "Course submitted for review!";
            }
            return RedirectToAction(nameof(Dashboard));
        }

        private async Task<bool> IsOwnerOfCourseAsync(Guid courseId)
        {
            var userId = _claimService.GetUserClaim().UserId;
            var coursesResult = await _courseService.GetCoursesByInstructorAsync();
            if (!coursesResult.IsSuccess) return false;

            var courses = coursesResult.Result as List<CourseResponse>;
            return courses?.Any(c => c.CourseId == courseId) ?? false;
        }
    }
}
