using BusinessLayer.IServices;
using BusinessLayer.Responses;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BusinessLayer.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> GetTotalUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return new ApiResponse().SetOk(users.Count());
        }

        public async Task<ApiResponse> GetTotalInstructorsAsync()
        {
            var instructors = await _unitOfWork.Users
                .GetAllAsync(u => u.Role == Role.Instructor);

            return new ApiResponse().SetOk(instructors.Count());
        }

        public async Task<ApiResponse> GetTotalStudentsAsync()
        {
            var students = await _unitOfWork.Users
                .GetAllAsync(u => u.Role == Role.Student);

            return new ApiResponse().SetOk(students.Count());
        }

        public async Task<ApiResponse> GetTotalCoursesAsync()
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();
            return new ApiResponse().SetOk(courses.Count());
        }

        public async Task<ApiResponse> GetActiveCoursesAsync()
        {
            var activeCourses = await _unitOfWork.Courses
                .GetAllAsync(c => c.IsDeleted == false);

            return new ApiResponse().SetOk(activeCourses.Count());
        }

        public async Task<ApiResponse> GetTotalEnrollmentsAsync()
        {
            var enrollments = await _unitOfWork.Enrollments.GetAllAsync();
            return new ApiResponse().SetOk(enrollments.Count());
        }

        public async Task<ApiResponse> GetTotalRevenueAsync()
        {
            var enrollments = await _unitOfWork.Enrollments.GetAllAsync();
            var courses = await _unitOfWork.Courses.GetAllAsync();

            var totalRevenue =
                (from e in enrollments
                 join c in courses on e.CourseId equals c.CourseId
                 where c.IsDeleted == false
                 select c.Price)
                .Sum();

            return new ApiResponse().SetOk(totalRevenue);
        }

        public async Task<ApiResponse> GetRecentActivitiesAsync(int take = 5)
        {
            var enrollments = await _unitOfWork.Enrollments.GetAllAsync();

            var recent = enrollments
                .OrderByDescending(e => e.CreatedAt)
                .Take(take)
                .Select(e => new
                {
                    Time = e.CreatedAt,
                    UserId = e.UserId,
                    CourseId = e.CourseId,
                    Status = "Success"
                });

            return new ApiResponse().SetOk(recent);
        }
    }
}