using Data;
using Data_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetUserById(string id);
    }

    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationUser GetUserById(string id)
        {
            return _dbSet.Include(x => x.Skills)
                         .Include(x => x.CurriculumVitae)
                         .FirstOrDefault(x => x.Id == id);
        }

    }
}
