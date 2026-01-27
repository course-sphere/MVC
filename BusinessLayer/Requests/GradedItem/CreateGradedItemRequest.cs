using DataAccessLayer.Entities;
using BusinessLayer.Requests.Question;

namespace BusinessLayer.Requests.GradedItem
{
    public class CreateGradedItemRequest
    {
        public Guid LessonId { get; set; }
        public GradedItemType Type { get; set; }
        public int MaxScore { get; set; }
        public List<CreateQuestionRequest>? Questions { get; set; }
    }
}
