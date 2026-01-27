using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Requests.LessonResource
{
    public class UpdateLessonResourceRequest
    {
        public string? Title { get; set; }
        public IFormFile? File { get; set; }
    }
}
