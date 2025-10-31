using AIssist.Domain.Entities;

namespace AIssist.Domain.Services.Interfaces
{
	public interface ITicketService
	{
        Task<bool> Add(Tickets ticket);
        Task<List<Tickets>> Get();
        Task<Tickets?> GetByTicketNumber(string ticketNumber);
        Task<bool> UpdateStatus(string ticketNumber, long newStatus);
        Task<bool> Update(Tickets entity);
        Task<bool> UpdateAssignee(string ticketNumber, long assigneeId);
    }
}

