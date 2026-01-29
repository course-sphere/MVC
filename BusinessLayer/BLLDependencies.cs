using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BusinessLayer.Services; // Namespace chứa Service
using BusinessLayer.IServices; // Namespace chứa Interface
using DataAccessLayer; // Để gọi hàm AddDataAccessLayer

namespace BusinessLayer
{
    public static class BLLDependencies
    {
        public static void AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessLayer(configuration);

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFirebaseStorageService, FirebaseStorageService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<ILessonResourceService, LessonResourceService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IUserLessonProgressService, UserLessonProgressService>();
        }
    }
}