namespace DataAccessLayer.Entities
{
    public class SubmissionAnswerOption
    {
        public Guid SubmissionAnswerOptionId { get; set; }
        public Guid QuestionSubmissionId { get; set; }
        public Guid AnswerOptionId { get; set; }
        public decimal Score { get; set; }
        public QuestionSubmission? QuestionSubmission { get; set; }
        public AnswerOption? AnswerOption { get; set; }
    }
}
