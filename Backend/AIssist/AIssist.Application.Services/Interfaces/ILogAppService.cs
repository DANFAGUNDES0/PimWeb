using AIssist.Domain.Http.Response.Log;

namespace AIssist.Application.Services.Interfaces
{
	public interface ILogAppService
	{
        Task<List<LogResponse>> Get();
        Task Add(string action, string descrip);
    }
}

