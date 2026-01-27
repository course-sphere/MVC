using BusinessLayer.Requests.User;
using BusinessLayer.Responses;

namespace BusinessLayer.IServices
{
    public interface IAuthService
    {
        Task<ApiResponse> LoginAsync(LoginRequest request);
        Task<ApiResponse> RegisterAsync(RegisterRequest request);
    }
}
