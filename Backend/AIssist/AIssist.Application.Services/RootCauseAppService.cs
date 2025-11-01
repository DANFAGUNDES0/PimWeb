using AIssist.Application.Services.Interfaces;
using AIssist.Domain.Entities;
using AIssist.Domain.Http.Request.RootCause;
using AIssist.Domain.Services.Interfaces;
using System.Text.Json;
using AutoMapper;
using AIssist.Domain.Http.Response;

namespace AIssist.Application.Services
{
    public class RootCauseAppService : IRootCauseAppService
    {
        private readonly IRootCauseService _rootCauseService;
        private readonly ILogAppService _logAppService;
        private readonly IMapper _mapper;

        public RootCauseAppService(IRootCauseService rootCauseService, IMapper mapper, ILogAppService logAppService)
        {
            _rootCauseService = rootCauseService;
            _logAppService = logAppService;
            _mapper = mapper;
        }

        public Task<DefaultResponse> Add(RootCausePostRequest entity)
        {
            var response = new DefaultResponse();
            var rootCause = _mapper.Map<RootCause>(entity);
            var RootCauseresult = _rootCauseService.Add(rootCause);
            RootCauseresult.Wait();

            if (RootCauseresult.IsCompletedSuccessfully)
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
            var rootCauseResult = _rootCauseService.Inactivate(entityId);
            rootCauseResult.Wait();

            if (rootCauseResult.IsCompletedSuccessfully)
            {
                var logResult = _logAppService.Add("Inativação", JsonSerializer.Serialize(new {id = entityId, entity = "RootCause"}));
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

        public Task<List<RootCause>> Get()
        {
            var result = _rootCauseService.Get();
            return result;
        }

        public Task<RootCause?> GetById(long rootCauseId)
        {
            var result = _rootCauseService.GetById(rootCauseId);
            return result;
        }

        public Task<DefaultResponse> Update(RootCausePutRequest entity)
        {
            var response = new DefaultResponse();
            var rootCause = _mapper.Map<RootCause>(entity);
            var rootCauseResult = _rootCauseService.Update(rootCause);
            rootCauseResult.Wait();

            if (rootCauseResult.IsCompletedSuccessfully)
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

