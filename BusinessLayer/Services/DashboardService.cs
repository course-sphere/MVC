using BusinessLayer.IServices;
using BusinessLayer.Responses;
using DataAccessLayer.Entities;

namespace BusinessLayer.Services
{
    public class DashboardService : IDashboardService
    {
        public async Task<ApiResponse> GetTotalUsersAsync()
        {
            return new ApiResponse().SetOk(0);
        }

        public async Task<ApiResponse> GetTotalInstructorsAsync()
        {
            return new ApiResponse().SetOk(0);
        }

        public async Task<ApiResponse> GetTotalStudentsAsync()
        {
            return new ApiResponse().SetOk(0);
        }

        public async Task<ApiResponse> GetTotalCoursesAsync()
        {
            return new ApiResponse().SetOk(0);
        }

        public async Task<ApiResponse> GetActiveCoursesAsync()
        {
            return new ApiResponse().SetOk(0);
        }

        public async Task<ApiResponse> GetTotalEnrollmentsAsync()
        {
            return new ApiResponse().SetOk(0);
        }

        public async Task<ApiResponse> GetTotalRevenueAsync()
        {
            return new ApiResponse().SetOk(0);
        }

        public async Task<ApiResponse> GetRecentActivitiesAsync(int take = 5)
        {
            return new ApiResponse().SetOk(new List<object>());
        }
    }
}
