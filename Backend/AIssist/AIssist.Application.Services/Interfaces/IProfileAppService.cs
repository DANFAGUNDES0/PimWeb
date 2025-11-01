using AIssist.Domain.Entities;
using AIssist.Domain.Http.Request.Profile;
using AIssist.Domain.Http.Response;

namespace AIssist.Application.Services.Interfaces
{
	public interface IProfileAppService
	{
        Task<DefaultResponse> Add(ProfileRequest profileRequest);
        Task<Profiles?> GetById(long profileId);
        Task<DefaultResponse> Update(ProfileRequest profileRequest);
        Task<List<Profiles>> Get();
        Task<DefaultResponse> Inactivate(long entityId);
    }
}

