using System.Text.Json;
using AIssist.Application.Services.Interfaces;
using AIssist.Domain.Entities;
using AIssist.Domain.Http.Request.Ticket;
using AIssist.Domain.Http.Response;
using AIssist.Domain.Services.Interfaces;
using AutoMapper;

namespace AIssist.Application.Services
{
    public class TicketAppService : ITicketAppService
    {
        private readonly ITicketService _ticketService;
        private readonly ILogAppService _logAppService;
        private readonly IMapper _mapper;

        public TicketAppService(ITicketService ticketService, ILogAppService logAppService, IMapper mapper)
        {
            _ticketService = ticketService;
            _logAppService = logAppService;
            _mapper = mapper;
        }

        public Task<DefaultResponse> Add(TicketPostRequest entity)
        {
            var response = new DefaultResponse();
            var ticket = _mapper.Map<Tickets>(entity);
            var ticketResult = _ticketService.Add(ticket);
            ticketResult.Wait();

            if (ticketResult.IsCompletedSuccessfully)
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

        public Task<List<Tickets>> Get()
        {
            var result = _ticketService.Get();
            return result;
        }

        public Task<Tickets?> GetByTicketNumber(string ticketNumber)
        {
            var result = _ticketService.GetByTicketNumber(ticketNumber);
            return result;
        }

        public Task<DefaultResponse> Update(TicketPutRequest entity)
        {            
            var response = new DefaultResponse();
            var ticket = _mapper.Map<Tickets>(entity);
            var ticketResult = _ticketService.Update(ticket);
            ticketResult.Wait();

            if (ticketResult.IsCompletedSuccessfully)
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

        public Task<DefaultResponse> UpdateStatus(string ticketNumber, long newStatus)
        {
            var response = new DefaultResponse();
            var ticketResult = _ticketService.UpdateStatus(ticketNumber, newStatus);
            ticketResult.Wait();

            if (ticketResult.IsCompletedSuccessfully)
            {
                var logResult = _logAppService.Add("Atualização Status", JsonSerializer.Serialize( new { ticketNumber, Status = newStatus }));
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
        public Task<DefaultResponse> UpdateAssignee(string ticketNumber, long assigneeId)
        {
            var response = new DefaultResponse();
            var ticketResult = _ticketService.UpdateAssignee(ticketNumber, assigneeId);
            ticketResult.Wait();

            if (ticketResult.IsCompletedSuccessfully)
            {
                var logResult = _logAppService.Add("Atualização Assignee", JsonSerializer.Serialize(new { ticketNumber, Assignee = assigneeId }));
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

