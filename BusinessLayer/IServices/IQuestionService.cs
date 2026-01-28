using BusinessLayer.Requests.Question;
using BusinessLayer.Responses;

namespace BusinessLayer.IServices
{
    public interface IQuestionService
    {
        Task<ApiResponse> CreateQuestionAsync(CreateQuestionRequest request);
    }
}
