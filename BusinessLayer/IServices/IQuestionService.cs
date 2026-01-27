using BusinessLayer.Requests.Question;
using BusinessLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IServices
{
    public interface IQuestionService
    {
        Task<ApiResponse> CreateQuestionAsync(CreateQuestionRequest request);
    }
}
