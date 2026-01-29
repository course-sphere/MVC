using BusinessLayer.IServices;
using BusinessLayer.Requests.Enrollment;
using BusinessLayer.Responses.Course;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IEnrollmentService _enrollmentService;
        private readonly IClaimService _claimService;

        public StudentController(ICourseService courseService, IEnrollmentService enrollmentService, IClaimService claimService)
        {
            _courseService = courseService;
            _enrollmentService = enrollmentService;
            _claimService = claimService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _courseService.GetEnrolledCoursesForStudentAsync();
            var courses = result.IsSuccess ? result.Result as List<CourseResponse> : new List<CourseResponse>();
            return View(courses);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Browse()
        {
            var result = await _courseService.GetAllCourseAsync();
            var courses = result.IsSuccess ? result.Result as List<CourseResponse> : new List<CourseResponse>();
            return View(courses);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detail(Guid id)
        {
            var result = await _courseService.GetCourseByIdAsync(id);
            if (!result.IsSuccess)
            {
                TempData["Error"] = "Course not found";
                return RedirectToAction(nameof(Browse));
            }
            
            // Check enrollment status
            var isEnrolled = User.Identity?.IsAuthenticated == true 
                ? await _enrollmentService.CheckEnrollmentAsync(id) 
                : false;
            ViewBag.IsEnrolled = isEnrolled;
            
            return View(result.Result as CourseResponse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enroll(Guid courseId)
        {
            var request = new CreateNewEnrollementRequest { CourseId = courseId };
            var result = await _enrollmentService.EnrollStudentDirectlyAsync(courseId);
            TempData[result.IsSuccess ? "Success" : "Error"] = result.IsSuccess ? "Enrolled successfully!" : result.ErrorMessage;
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Learn(Guid id)
        {
            var result = await _courseService.GetCourseByIdAsync(id);
            if (!result.IsSuccess)
            {
                TempData["Error"] = "Course not found";
                return RedirectToAction(nameof(Index));
            }
            var course = result.Result as CourseResponse;
            ViewBag.Modules = await GetModulesForCourse(id);
            return View(course);
        }

        private async Task<List<BusinessLayer.Responses.Module.ModuleResponse>> GetModulesForCourse(Guid courseId)
        {
            var moduleService = HttpContext.RequestServices.GetService<IModuleService>();
            var result = await moduleService.GetModulesByCourseAsync(courseId);
            return result.IsSuccess ? result.Result as List<BusinessLayer.Responses.Module.ModuleResponse> : new();
        }
    }
}
