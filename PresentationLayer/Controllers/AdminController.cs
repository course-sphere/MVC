using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.IServices;
using PresentationLayer.ViewModels.Dashboard;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public AdminController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        // GET: /Admin
        public async Task<IActionResult> Dashboard()
        {
            var vm = new DashboardViewModel();

            var totalUsers = await _dashboardService.GetTotalUsersAsync();
            var totalCourses = await _dashboardService.GetTotalCoursesAsync();
            var activeCourses = await _dashboardService.GetActiveCoursesAsync();
            var totalEnrollments = await _dashboardService.GetTotalEnrollmentsAsync();
            var totalRevenue = await _dashboardService.GetTotalRevenueAsync();
            var recentActivities = await _dashboardService.GetRecentActivitiesAsync();

            if (totalUsers.IsSuccess) vm.TotalUsers = (int)totalUsers.Result;
            if (totalCourses.IsSuccess) vm.TotalCourses = (int)totalCourses.Result;
            if (activeCourses.IsSuccess) vm.ActiveCourses = (int)activeCourses.Result;
            if (totalEnrollments.IsSuccess) vm.TotalEnrollments = (int)totalEnrollments.Result;
            if (totalRevenue.IsSuccess && totalRevenue.Result != null)
            {
                vm.TotalRevenue = Convert.ToDecimal(totalRevenue.Result);
            }
            else
            {
                vm.TotalRevenue = 0;
            }
            if (recentActivities.IsSuccess)
                vm.RecentActivities = recentActivities.Result as List<RecentActivityViewModel>;

            return View(vm);
        }
    }
}