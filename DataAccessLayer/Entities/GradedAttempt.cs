namespace DataAccessLayer.Entities
{
    public class GradedAttempt : Base
    {
        public Guid GradedAttemptId { get; set; }

        // FK
        public Guid UserId { get; set; }
        public Guid GradedItemId { get; set; }

        // Attempt info
        public int AttemptNumber { get; set; }
        public GradedAttemptStatus Status { get; set; }

        public DateTime? SubmittedAt { get; set; }
        public DateTime? GradedAt { get; set; }

        // Score
        public decimal? Score { get; set; }
        public int MaxScore { get; set; }
        public bool IsPassed { get; set; }

        // Quiz only
        public List<QuestionSubmission>? QuestionSubmissions { get; set; }

        // Assignment only
        public string? SubmittedText { get; set; }
        public string? FileUrl { get; set; }
        public string? AudioUrl { get; set; }

        // Feedback
        public string? Feedback { get; set; }
        public Guid? GradedBy { get; set; } // Teacher / AI

        // Navigation
        public User? User { get; set; }
        public GradedItem? GradedItem { get; set; }
    }

    public enum GradedAttemptStatus
    {
        InProgress,        // đang làm
        Submitted,         // đã nộp
        AutoGraded,        // AI / hệ thống chấm
        ManuallyGraded,    // giáo viên chấm
        Returned           // trả bài / yêu cầu làm lại
    }
}
