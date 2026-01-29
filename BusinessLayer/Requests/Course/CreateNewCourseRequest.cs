using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Requests.Course
{
    public class CreateNewCourseRequest
    {
        public string Title { get ; set; }
        public string Description { get; set; }
        public IFormFile? ImageFile { get; set; }
        public decimal Price { get; set; }
        public CourseLevel Level { get; set; }
        public Guid LanguageId { get; set; } = Guid.Parse("11111111-1111-1111-1111-111111111111"); // Default: English
    }
}