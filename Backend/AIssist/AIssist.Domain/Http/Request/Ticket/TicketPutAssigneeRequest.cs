using System;
namespace AIssist.Domain.Http.Request.Ticket
{
	public class TicketPutAssigneeRequest
	{
		public string TicketNumber { get; set; }
		public long AssigneeId { get; set; }
	}
}

