using DataAccessLayer.IRepositories;
using DataAccessLayer.Entities;

namespace DataAccessLayer
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ILessonRepository Lessons { get; }
        ICourseRepository Courses { get; }
        IEnrollmentRepository Enrollments { get; }
        IPaymentRepository Payments { get; }
        IModuleRepository Modules { get; }
        ILessonResourceRepository LessonResources { get; }
        ILessonItemRepository LessonItems { get; }
        IGradedItemRepository GradedItems { get; }
        IGradedAttemptRepository GradedAttempts { get; }
        ISubmissionAnswerOptionRepository SubmissionAnswerOptions { get; }
        IQuestionSubmissionRepository QuestionSubmissions { get; }
        IAnswerOptionRepository AnswerOptions { get; }
        IQuestionRepository Questions { get; }
        IUserLessonProgressRepository UserLessonProgresses { get; }
        ILanguageRepository Languages { get; }
        IWalletRepository Wallets { get; }
        IWalletTransactionRepository WalletTransactions { get; }
        //18

        Task SaveChangeAsync();
    }
}