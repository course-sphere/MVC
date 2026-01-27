using DataAccessLayer.IRepositories;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class QuestionSubmissionRepository : GenericRepository<QuestionSubmission>, IQuestionSubmissionRepository
    {
        public QuestionSubmissionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
