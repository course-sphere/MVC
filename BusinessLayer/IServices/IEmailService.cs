using BusinessLayer.Responses;

namespace BusinessLayer.IServices
{
    public interface IEmailService
    {
        Task<ApiResponse> SendRejectCourseEmail(string receiverName, string receiverEmail, string rejectReason, string courseTitle);

        Task<ApiResponse> SendApproveCourseEmail(string receiverName, string receiverEmail, string courseTitle);
        Task<ApiResponse> SendShortAnswerNotifyToInstructor(
   string instructorName,
   string instructorEmail,
   string studentName,
   string courseTitle);
    }
}
