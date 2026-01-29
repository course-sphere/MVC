namespace DataAccessLayer.Entities
{
    public class GradedItem : Base
    {
        public Guid GradedItemId { get; set; }
        public Guid LessonItemId { get; set; }
        public int MaxScore { get; set; }
        public bool IsAutoGraded { get; set; }
        public GradedItemType GradedItemType { get; set; }
        public string? SubmissionGuidelines { get; set; } // Assignment / Writing / Speaking
        public LessonItem? LessonItem { get; set; }
        public List<GradedAttempt>? GradedAttempts { get; set; }
        public List<Question>? Questions { get; set; } // Quiz only 
    }

    public enum GradedItemType
    {
        Assignment,
        Writing,
        Speaking,
        Quiz
    } 
}