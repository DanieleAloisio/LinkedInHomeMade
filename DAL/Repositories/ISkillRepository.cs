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
    public interface ISkillRepository : IRepository<Skills>
    {
        void GetSkillsByUserId(string id);
    }

    public class SkillRepository : RepositoryBase<Skills>, ISkillRepository
    {
        public SkillRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void GetSkillsByUserId(string id)
        {
            _context.Skills.Include(x => x.Users);
            _context.SaveChangesAsync();
        }
    }
}
