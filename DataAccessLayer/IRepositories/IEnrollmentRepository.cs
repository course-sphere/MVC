using DataAccessLayer.Entities;
using System.Linq;

namespace DataAccessLayer.IRepositories
{
    public interface IEnrollmentRepository : IGenericRepository<Enrollment>
    {
        IQueryable<Enrollment> GetQueryable();
    }
}
