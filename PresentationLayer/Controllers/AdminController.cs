using BusinessLayer.IServices;
using BusinessLayer.Requests.Course;
using BusinessLayer.Responses.Course;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(ICourseService courseService, IUnitOfWork unitOfWork)
        {
            _courseService = courseService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PendingCourses()
        {
            var result = await _courseService.GetCoursesByStatusAsync(CourseStatus.PendingApproval);
            var courses = result.IsSuccess ? result.Result as List<CourseResponse> : new List<CourseResponse>();
            return View(courses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveCourse(Guid id)
        {
            var request = new ApproveCourseRequest { CourseId = id, Status = true };
            var result = await _courseService.ApproveCourseAsync(request);
            TempData[result.IsSuccess ? "Success" : "Error"] = result.ErrorMessage ?? "Operation completed";
            return RedirectToAction(nameof(PendingCourses));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectCourse(Guid id, string reason)
        {
            var request = new ApproveCourseRequest { CourseId = id, Status = false, RejectReason = reason };
            var result = await _courseService.ApproveCourseAsync(request);
            TempData[result.IsSuccess ? "Success" : "Error"] = result.ErrorMessage ?? "Operation completed";
            return RedirectToAction(nameof(PendingCourses));
        }

        public async Task<IActionResult> Users()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return View(users.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUserRole(Guid id, Role role)
        {
            var user = await _unitOfWork.Users.GetAsync(u => u.UserId == id);
            if (user == null)
            {
                TempData["Error"] = "User not found";
                return RedirectToAction(nameof(Users));
            }

            user.Role = role;
            await _unitOfWork.SaveChangeAsync();
            TempData["Success"] = $"Updated {user.FullName}'s role to {role}";
            return RedirectToAction(nameof(Users));
        }
    }
}
