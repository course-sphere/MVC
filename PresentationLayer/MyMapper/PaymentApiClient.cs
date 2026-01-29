namespace PresentationLayer.MyMapper
{
    public class PaymentApiClient
    {
        private readonly HttpClient _http;

        public PaymentApiClient(HttpClient http)
        {
            _http = http;
        }
        public class PayOSPaymentVm
        {
            public string CheckoutUrl { get; set; } = "";
            public string? QrCode { get; set; }
            public long OrderCode { get; set; }
        }
        public async Task<PayOSPaymentVm> CreatePayOSPaymentAsync(Guid courseId, decimal amount)
        {
            var response = await _http.PostAsJsonAsync(
                "/api/payments/payos",
                new
                {
                    courseId,
                    amount
                });

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<PayOSPaymentVm>();
        }
    }
}
