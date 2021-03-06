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
        List<ApplicationUser> GetUsers();
    }

    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationUser GetUserById(string id)
        {
            return _dbSet.Include(x => x.Skills)
                         .Include(x => x.TipoGruppo)
                         .Include(x => x.CurriculumVitae)
                         .Include(x => x.Fan).ThenInclude(x => x.FollowUser)
                         .Include(x => x.Follow).ThenInclude(x => x.FanUser)
                         .FirstOrDefault(x => x.Id == id);
        }
        public List<ApplicationUser> GetUsers()
        {
            return _dbSet.Include(x => x.Skills)
                         .Include(x => x.TipoGruppo)
                         .Include(x => x.CurriculumVitae).ToList();
        }
        public List<ApplicationUser> GetUsersAndInclude()
        {
            return _dbSet.Include(x => x.Skills)
                         .Include(x => x.TipoGruppo)
                         .Include(x => x.Fan).ThenInclude(x => x.FollowUser)
                         .Include(x => x.Follow).ThenInclude(x => x.FanUser)
                         .Include(x => x.CurriculumVitae).ToList();
        }

    }
}
