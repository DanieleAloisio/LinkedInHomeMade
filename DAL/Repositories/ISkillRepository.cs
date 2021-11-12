using Data;
using Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ISkillRepository : IRepository<Skills>
    {
        Skills GetSkillsByName(string name);
    }

    public class SkillRepository : RepositoryBase<Skills>, ISkillRepository
    {
        public SkillRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Skills GetSkillsByName(string name)
        {
            throw new NotImplementedException();
        }

    }
}
