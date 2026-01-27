using DataAccessLayer.IRepositories;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class GradedAttemptRepository : GenericRepository<GradedAttempt>, IGradedAttemptRepository
    {
        public GradedAttemptRepository(AppDbContext context) : base(context)
        {
        }
    }
}
