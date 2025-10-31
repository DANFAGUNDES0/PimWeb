using AIssist.Domain.Entities;
using AIssist.Domain.Interfaces;
using AIssist.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AIssist.Domain.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IAppDbContext _context;

        public ProfileService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Profiles entity)
        {
            try
            {
                await _context.Profiles.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Inactivate(long entityId)
        {
            try
            {
                var entity = await _context.Profiles.FindAsync(entityId);
                if (entity == null)
                    return false;

                entity.Active = !entity.Active;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Profiles>> Get()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async Task<Profiles?> GetById(long profileId)
        {
            return await _context.Profiles
            .FirstOrDefaultAsync(rc => rc.Id == profileId);
        }

        public async Task<bool> Update(Profiles profile)
        {
            try
            {
                var entity = await _context.Profiles.FindAsync(profile.Id);
                if (entity == null)
                    return false;

                profile.CreatedBy = entity.CreatedBy;
                _context.Atualizar(entity, profile);
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

