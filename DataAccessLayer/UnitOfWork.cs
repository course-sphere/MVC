using DataAccessLayer.IRepositories;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        // 1. Khai báo Property (Mỗi cái chỉ khai báo 1 lần)
        public IAnswerOptionRepository AnswerOptions { get; }
        public ICourseRepository Courses { get; }
        public IEnrollmentRepository Enrollments { get; }
        public IGradedAttemptRepository GradedAttempts { get; }
        public IGradedItemRepository GradedItems { get; }
        public ILanguageRepository Languages { get; }
        public ILessonRepository Lessons { get; }
        public ILessonItemRepository LessonItems { get; }
        public ILessonResourceRepository LessonResources { get; }
        public IModuleRepository Modules { get; }
        public IPaymentRepository Payments { get; }
        public IQuestionRepository Questions { get; }
        public IQuestionSubmissionRepository QuestionSubmissions { get; }
        public ISubmissionAnswerOptionRepository SubmissionAnswerOptions { get; }
        public IUserRepository Users { get; }
        public IUserLessonProgressRepository UserLessonProgresses { get; }
        public IWalletRepository Wallets { get; }
        public IWalletTransactionRepository WalletTransactions { get; }
        //18
        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Users = new UserRepository(context);
            Courses = new CourseRepository(context);
            Enrollments = new EnrollmentRepository(context);
            Lessons = new LessonRepository(context);
            Payments = new PaymentRepository(context);
            GradedItems = new GradedItemRepository(context);
            GradedAttempts = new GradedAttemptRepository(context);
            QuestionSubmissions = new QuestionSubmissionRepository(context);
            SubmissionAnswerOptions = new SubmissionAnswerOptionRepository(context);
            Modules = new ModuleRepository(context);
            LessonResources = new LessonResourceRepository(context);
            UserLessonProgresses = new UserLessonProgressRepository(context);
            Questions = new QuestionRepository(context);
            AnswerOptions = new AnswerOptionRepository(context);
            Languages = new LanguageRepository(context);
            LessonItems = new LessonItemRepository(context);
            Wallets = new WalletRepository(context);
            WalletTransactions = new WalletTransactionRepository(context);
            //18
        }

        public async Task SaveChangeAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while saving changes", ex);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}