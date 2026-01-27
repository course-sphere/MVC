using BusinessLayer.Requests.LessonResource;
using BusinessLayer.Responses;

namespace BusinessLayer.IServices
{
    public interface ILessonResourceService
    {
        Task<ApiResponse> CreateLessonResourceAsync(CreateLessonResourceRequest request);
        Task<ApiResponse> GetResourcesByLessonAsync(Guid lessonId);
        Task<ApiResponse> UpdateLessonResourceAsync(Guid resourceId, UpdateLessonResourceRequest request);
        Task<ApiResponse> DeleteLessonResourceAsync(Guid resourceId);
    }
}
