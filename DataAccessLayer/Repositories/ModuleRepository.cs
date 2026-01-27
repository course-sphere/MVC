using DataAccessLayer.IRepositories;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class ModuleRepository : GenericRepository<Module>, IModuleRepository
    {
        public ModuleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
