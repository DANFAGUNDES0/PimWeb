using AIssist.Domain.Entities;

namespace AIssist.Domain.Services.Interfaces
{
	public interface IRootCauseService
	{
        Task<bool> Add(RootCause rootCause);
        Task<RootCause?> GetById(long entityId);
        Task<bool> Update(RootCause rootCause);
        Task<List<RootCause>> Get();
        Task<bool> Inactivate(long entityId);
    }
}

