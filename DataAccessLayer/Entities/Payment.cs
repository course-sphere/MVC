namespace DataAccessLayer.Entities
{
    public class Payment : Base
    {
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public Guid EnrollmentId { get; set; }
        public long OrderCode { get; set; }              // unique
        public string PaymentLinkId { get; set; } = null!;
        public string? CheckoutUrl { get; set; }

        // 💸 Thông tin tiền
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "VND";

        // 🏦 Giao dịch PayOS
        public string? Reference { get; set; }            // từ webhook
        public string? CounterAccountNumber { get; set; }
        public string? CounterAccountName { get; set; }
        public string? CounterAccountBankName { get; set; }

        // 🧾 Chung cho mọi cổng
        public string Method { get; set; } = "PayOS";
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        // ⏱ Thời gian
        public DateTime? PaidAt { get; set; }

        // 🧠 Debug / audit
        public string? RawWebhookData { get; set; }

        // Navigation
        public User? User { get; set; }
        public Course? Course { get; set; }
        public Enrollment? Enrollment { get; set; }
    }
    public enum PaymentStatus
    {
        Pending = 0,
        Paid = 1,
        Failed = 2,
        Cancelled = 3
    }

}
