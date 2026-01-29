

using DataAccessLayer.Entities;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class LessonItemRepository : GenericRepository<LessonItem>, ILessonItemRepository
    {
        public LessonItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}
