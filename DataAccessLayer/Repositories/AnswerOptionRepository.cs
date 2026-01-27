using DataAccessLayer.IRepositories;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class AnswerOptionRepository : GenericRepository<AnswerOption>, IAnswerOptionRepository
    {
        public AnswerOptionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
