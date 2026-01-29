using Microsoft.AspNetCore.Mvc;
using PresentationLayer.MyMapper;

namespace PresentationLayer.Controllers
{
    public class PaymentController : Controller
    {
        private readonly PaymentApiClient _paymentApi;

        public PaymentController(PaymentApiClient paymentApi)
        {
            _paymentApi = paymentApi;
        }

        [HttpPost]
        public async Task<IActionResult> Pay(Guid courseId, decimal amount)
        {
            var result = await _paymentApi.CreatePayOSPaymentAsync(courseId, amount);
            return Redirect(result.CheckoutUrl);
        }

        public IActionResult Success() => View();
        public IActionResult Cancel() => View();
    }
}
