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

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_context);
                return userRepository;
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
    }
}
