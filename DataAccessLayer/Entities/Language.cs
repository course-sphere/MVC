namespace DataAccessLayer.Entities
{
    public class Language : Base
    {
        public Guid LanguageId { get; set; }
        public string Code { get; set; } 
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
