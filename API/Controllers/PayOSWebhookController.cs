using BusinessLayer;
using BusinessLayer.IServices;
using BusinessLayer.Requests.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayOS.Models.Webhooks;
using PayOS;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayOSWebhookController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly PayOSClient _client;

        public PayOSWebhookController(IPaymentService paymentService, PayOSClient client)
        {
            _paymentService = paymentService;
            _client = client;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePayment(CreateNewPaymentRequest request)
        {
            var result = await _paymentService.CreatePayOSPaymentAsync(request);
            return Ok(result);
        }

        [HttpPost("webhook")]
        public async Task<IActionResult> HandleWebhook(Webhook webhook)
        {
            try
            {
                if (webhook == null)
                {
                    return BadRequest("Webhook data is required");
                }
                var verifiedData = await _client.Webhooks.VerifyAsync(webhook);

                await _paymentService.HandlePayOSWebhookAsync(verifiedData);

                return Ok("OK");
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid webhook");
            }
        }

    }
}
