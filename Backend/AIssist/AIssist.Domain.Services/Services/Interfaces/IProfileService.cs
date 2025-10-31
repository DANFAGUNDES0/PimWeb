using AIssist.Domain.Entities;

namespace AIssist.Domain.Services.Interfaces
{
	public interface IProfileService
	{
        Task<Profiles?> GetById(long profileId);
        Task<bool> Add(Profiles profile);
        Task<List<Profiles>> Get();
        Task<bool> Update(Profiles entity);
        Task<bool> Inactivate(long entityId);
    }
}

