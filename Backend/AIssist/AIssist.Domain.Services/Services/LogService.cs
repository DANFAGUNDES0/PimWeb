using AIssist.Domain.Entities;
using AIssist.Domain.Interfaces;
using AIssist.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AIssist.Domain.Services
{
	public class LogService : ILogService
	{
        private readonly IAppDbContext _context;

        public LogService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Logs>> Get()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<bool> Add(Logs entity)
        {
            try
            {
                await _context.Logs.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}

