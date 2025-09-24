using AIssist.Domain.Entities;

namespace AIssist.Domain.Services.Interfaces
{
	public interface ITicketService
	{
        Task Add(Tickets ticket);
        Task<List<Tickets>> Get();
        Task<List<Tickets>> GetByTicketNumber(string ticketNumber);
        Task UpdateStatus(string ticketNumber, long newStatus);
        Task Update(Tickets entity);
        Task UpdateAssignee(string ticketNumber, long assigneeId);
    }
}

