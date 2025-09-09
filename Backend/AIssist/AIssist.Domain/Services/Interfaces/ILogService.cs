using AIssist.Domain.Entities;

namespace AIssist.Domain.Services.Interfaces
{
	public interface ILogService
	{
        Task<List<Logs>> Get();
        Task Add(Logs entity);
    }
}

