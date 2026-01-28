namespace DataAccessLayer.Entities
{
    public class Lesson : Base
    {
        public Guid LessonId { get; set; }
        public Guid ModuleId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int EstimatedMinutes { get; set; }
        public int OrderIndex { get; set; }
        public Module? Module { get; set; }
        public List<LessonItem>? LessonItems { get; set; }
        public List<UserLessonProgress>? UserLessonProgresses { get; set; }
    }
}
