using AIssist.Domain.Entities;
using AIssist.Domain.Http.Request.Ticket;
using AIssist.Domain.Http.Response;

namespace AIssist.Application.Services.Interfaces
{
	public interface ITicketAppService
	{
        Task<DefaultResponse> Add(TicketPostRequest entity);
        Task<List<Tickets>> Get();
        Task<List<Tickets>> GetByTicketNumber(string ticketNumber);
        Task<DefaultResponse> UpdateStatus(string ticketNumber, long newStatus);
        Task<DefaultResponse> Update(TicketPutRequest entity);
        Task<DefaultResponse> UpdateAssignee(string ticketNumber, long assigneeId);
    }
}

