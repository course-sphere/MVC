using BusinessLayer.IServices;
using BusinessLayer.Responses.Course;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService _courseService;

        public HomeController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _courseService.GetAllCourseAsync();
            var courses = result.IsSuccess ? result.Result as List<CourseResponse> : new List<CourseResponse>();
            return View(courses);
        }
    }
}
