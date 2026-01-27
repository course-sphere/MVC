using DataAccessLayer.IRepositories;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(AppDbContext context) : base(context)
        {
        }
    }
}
