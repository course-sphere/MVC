using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Responses;
using BusinessLayer.Requests.Enrollment;

namespace BusinessLayer.IServices
{
    public interface IEnrollmentService
    {
        Task<ApiResponse> EnrollStudentDirectlyAsync(Guid courseId);
        Task<ApiResponse> GetStudentEnrollmentsAsync();
        Task<bool> CheckEnrollmentAsync(Guid courseId);
    }
}
