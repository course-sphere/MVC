using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Responses;


namespace BusinessLayer.IServices
{
    public interface IDashboardService
    {
        // ===== Cards =====
        Task<ApiResponse> GetTotalUsersAsync();
        Task<ApiResponse> GetTotalInstructorsAsync();
        Task<ApiResponse> GetTotalStudentsAsync();

        Task<ApiResponse> GetTotalCoursesAsync();
        Task<ApiResponse> GetActiveCoursesAsync();

        Task<ApiResponse> GetTotalEnrollmentsAsync();
        Task<ApiResponse> GetTotalRevenueAsync();

        // ===== Tables / Charts =====
        Task<ApiResponse> GetRecentActivitiesAsync(int take = 5);
    }
}
