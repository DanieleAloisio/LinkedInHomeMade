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
    public interface ILogRepository : IRepository<LogMessage>
    {
        void SaveLog(string message, LogMessageType type, string action);
    }

    public class LogRepository : RepositoryBase<LogMessage>, ILogRepository
    {
        public LogRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void SaveLog(string message, LogMessageType type, string action)
        {
            LogMessage log = new LogMessage()
            {
                Message = message,
                Type = type,
                Action = action,
                DateMessage = DateTime.Now,
            };
            _context.Logs.Add(log);
            _context.SaveChangesAsync();
        }
    }
}
