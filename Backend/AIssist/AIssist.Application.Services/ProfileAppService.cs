using System.Text.Json;
using AIssist.Application.Services.Interfaces;
using AIssist.Domain.Entities;
using AIssist.Domain.Http.Request.Profile;
using AIssist.Domain.Http.Response;
using AIssist.Domain.Services.Interfaces;
using AutoMapper;

namespace AIssist.Application.Services
{
    public class ProfileAppService : IProfileAppService
    {
        private readonly IProfileService _profileService;
        private readonly ILogAppService _logAppService;
        private readonly IMapper _mapper;

        public ProfileAppService(IProfileService profileService, IMapper mapper, ILogAppService logAppService)
        {
            _profileService = profileService;
            _logAppService = logAppService;
            _mapper = mapper;
        }

        public Task<DefaultResponse> Add(ProfileRequest entity)
        {
            var response = new DefaultResponse();
            var profile = _mapper.Map<Profiles>(entity);
            var profileResult = _profileService.Add(profile);
            profileResult.Wait();

            if (profileResult.IsCompletedSuccessfully)
            {
                var logResult = _logAppService.Add("Inserção", JsonSerializer.Serialize(entity));
                logResult.Wait();

                if (logResult.IsCompletedSuccessfully)
                    response.Success = true;
                else
                    response.Message = "Falha ao salvar o log da operação.";
            }
            else
                response.Message = "Falha ao salvar registro.";

            return Task.FromResult(response);
        }

        public Task<DefaultResponse> Inactivate(long entityId)
        {
            var response = new DefaultResponse();
            var profileResult = _profileService.Inactivate(entityId);
            profileResult.Wait();

            if (profileResult.IsCompletedSuccessfully)
            {
                var logResult = _logAppService.Add("Inativação", JsonSerializer.Serialize(new { id = entityId, entity = "Profile" }));
                logResult.Wait();

                if (logResult.IsCompletedSuccessfully)
                    response.Success = true;
                else
                    response.Message = "Falha ao salvar o log da operação.";
            }
            else
                response.Message = "Falha ao inativar registro.";

            return Task.FromResult(response);
        }

        public Task<List<Profiles>> Get()
        {
            var result = _profileService.Get();
            return result;
        }

        public Task<List<Profiles>> GetById(long profileId)
        {
            var result = _profileService.GetById(profileId);
            return result;
        }

        public Task<DefaultResponse> Update(ProfileRequest entity)
        {
            var response = new DefaultResponse();
            var profile = _mapper.Map<Profiles>(entity);

            var profileResult = _profileService.Update(profile);
            profileResult.Wait();

            if (profileResult.IsCompletedSuccessfully)
            {
                var logResult = _logAppService.Add("Atualização", JsonSerializer.Serialize(entity));
                logResult.Wait();

                if (logResult.IsCompletedSuccessfully)
                    response.Success = true;
                else
                    response.Message = "Falha ao salvar o log da operação.";
            }
            else
                response.Message = "Falha ao atualizar registro.";

            return Task.FromResult(response);
        }
    }
}

