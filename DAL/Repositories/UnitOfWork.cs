using DAL.Repositories;
using Data;
using System;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork
    {

        private readonly ApplicationDbContext _context;

        private IUserRepository userRepository;
        private ISkillRepository skillRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_context);
                return userRepository;
            }
        }

        public ISkillRepository SkillRepository
        {
            get
            {
                if (skillRepository == null)
                    skillRepository = new SkillRepository(_context);
                return skillRepository;
            }
        }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Remove(object skill)
        {
            _context.Remove(skill);
            return await _context.SaveChangesAsync();
        }
    }
}
