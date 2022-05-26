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
        private ILogRepository logRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_context);
                return userRepository;
            }
        }

        public ILogRepository LogRepository
        {
            get
            {
                if (logRepository == null)
                    logRepository = new LogRepository(_context);
                return logRepository;
            }
        }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> Remove<T>(T entity)
        {
            try
            {
                _context.Remove(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
