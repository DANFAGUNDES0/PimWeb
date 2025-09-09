using AIssist.Domain.Entities;
using AIssist.Domain.Http.Request.RootCause;
using AIssist.Domain.Http.Response;

namespace AIssist.Application.Services.Interfaces
{
	public interface IRootCauseAppService
	{
        Task<DefaultResponse> Add(RootCausePostRequest rootCauseRequest);
        Task<List<RootCauses>> GetById(long entityId);
        Task<DefaultResponse> Update(RootCausePutRequest rootCauseRequest);
        Task<List<RootCauses>> Get();
        Task<DefaultResponse> Inactivate(long entityId);
    }
}

