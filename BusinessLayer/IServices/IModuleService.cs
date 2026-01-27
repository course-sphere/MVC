using BusinessLayer.Requests.Module;
using BusinessLayer.Responses;

namespace BusinessLayer.IServices
{
    public interface IModuleService
    {
        Task<ApiResponse> CreateNewModuleForCourseAsync(CreateNewModuleForCourseRequest request);
        Task<ApiResponse> GetModulesByCourseAsync(Guid courseId);
        Task<ApiResponse> GetModuleDetailAsync(Guid moduleId);
        Task<ApiResponse> UpdateModuleAsync(UpdateModuleRequest request);
        Task<ApiResponse> DeleteModuleAsync(Guid moduleId);
    }
}
