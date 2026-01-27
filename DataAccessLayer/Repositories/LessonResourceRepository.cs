using DataAccessLayer.IRepositories;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class LessonResourceRepository : GenericRepository<LessonResource>, ILessonResourceRepository
    {
        public LessonResourceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
