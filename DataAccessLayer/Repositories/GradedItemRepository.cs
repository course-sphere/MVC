using DataAccessLayer.IRepositories;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class GradedItemRepository : GenericRepository<GradedItem>, IGradedItemRepository
    {
        public GradedItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}
