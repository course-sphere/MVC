namespace DataAccessLayer.Entities
{
    public class LessonResource : Base
    {
        public Guid LessonResourceId { get; set; }
        public Guid LessonItemId { get; set; }
        public string Title { get; set; }
        public ResourceType ResourceType { get; set; }
        public string? ResourceUrl { get; set; }
        public int OrderIndex { get; set; }
        public string? TextContent { get; set; }
        public long? DurationInSeconds { get; set; }
        public bool IsDownloadable { get; set; } 
        public LessonItem? LessonItem { get; set; }
    }

    public enum ResourceType
    {

        Video,
        Pdf,
        Slide,
        Text,
        Link,
        Image,
        Audio
    }
}
