using BusinessLayer.Requests.Payment;
using BusinessLayer.Responses;
using BusinessLayer.Responses.Payment;
using DataAccessLayer.DTOs;
using PayOS.Models.Webhooks;
using static BusinessLayer.Services.PaymentService;

namespace BusinessLayer.IServices
{
    public interface IPaymentService
    {
        /*        Task<ApiResponse> CreatePaymentUrlAsync(CreateNewPaymentRequest request, HttpContext context);
                Task<ApiResponse> PaymentExecuteAsync(IQueryCollection collection);*/
        Task<PaymentResponse> CreatePayOSPaymentAsync(CreateNewPaymentRequest request);
        Task HandlePayOSWebhookAsync(WebhookData data);
    }
}
