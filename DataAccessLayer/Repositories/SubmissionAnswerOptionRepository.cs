using DataAccessLayer.IRepositories;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class SubmissionAnswerOptionRepository : GenericRepository<SubmissionAnswerOption>, ISubmissionAnswerOptionRepository
    {
        public SubmissionAnswerOptionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
