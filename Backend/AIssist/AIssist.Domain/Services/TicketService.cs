using AIssist.Domain.Entities;
using AIssist.Domain.Services.Interfaces;
using Supabase;

namespace AIssist.Domain.Services
{
	public class TicketService : ITicketService
	{
        private readonly Client _supabaseclient;

        public TicketService(Client supabaseclient)
        {
            _supabaseclient = supabaseclient;
        }

        public async Task Add(Tickets entity)
        {
            await _supabaseclient
                .From<Tickets>()
                .Insert(entity);
        }

        public async Task<List<Tickets>> Get()
        {
            var result = await _supabaseclient
                .From<Tickets>()
                .Get();

            return result.Models;
        }

        public async Task<List<Tickets>> GetByTicketNumber(string ticketNumber)
        {
            var result = await _supabaseclient
                .From<Tickets>()
                .Where(w => w.Ticket_Number == ticketNumber)
                .Get();

            return result.Models;
        }

        public async Task UpdateStatus(string ticketNumber, long newStatus)
        {
            await _supabaseclient
                .From<Tickets>()
                .Where(w => w.Ticket_Number == ticketNumber)
                .Set(s => s.Status_id, newStatus)
                .Set(s => s.Updated_At, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
                .Update();
        }

        public async Task UpdateAssignee(string ticketNumber, long assigneeId)
        {
            await _supabaseclient
                .From<Tickets>()
                .Where(w => w.Ticket_Number == ticketNumber)
                .Set(s => s.Assignee_Id, assigneeId)
                .Set(s => s.Updated_At, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
                .Update();
        }

        public async Task Update(Tickets entity)
        {
            await _supabaseclient
                .From<Tickets>()
                .Where(w => w.Ticket_Number == entity.Ticket_Number)
                .Set(s => s.Description, entity.Description)
                .Set(s => s.Solution, entity.Solution)
                .Set(s => s.Updated_At, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
                .Update();
        }
    }
}

