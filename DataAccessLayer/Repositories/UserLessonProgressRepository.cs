using DataAccessLayer.IRepositories;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserLessonProgressRepository : GenericRepository<UserLessonProgress>, IUserLessonProgressRepository
    {
        public UserLessonProgressRepository(AppDbContext context) : base(context)
        {
        }
    }
}
