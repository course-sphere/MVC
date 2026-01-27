using DataAccessLayer.Entities;

namespace BusinessLayer.Responses.GradedItem
{
    public class GradedItemResponse
    {
        public Guid GradedItemId { get; set; }
        public Guid LessonId { get; set; }
        public GradedItemType Type { get; set; }
        public int MaxScore { get; set; }
        public bool IsAutoGraded { get; set; }
    }
}