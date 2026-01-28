
namespace DataAccessLayer.Entities
{
    public class LessonItem : Base
    {
        public Guid LessonItemId { get; set; }
        public Guid LessonId { get; set; }
        public LessonItemType Type { get; set; }
        public int OrderIndex { get; set; }
        public Lesson? Lesson { get; set; }
        public GradedItem? GradedItem { get; set; }
        public List<LessonResource>? LessonResources { get; set; } 
    }

    public enum LessonItemType
    {
        Video,          // Video bài giảng
        Reading,        // Bài đọc
        Vocabulary,     // Từ vựng
        Listening,      // Nghe hiểu
        Speaking,       // Nói (record audio)

        Quiz,           // Trắc nghiệm / điền từ (auto graded)
        Writing,        // Viết đoạn văn (manual graded)
        Assignment      // Bài tập upload file (manual graded)
    }
}
