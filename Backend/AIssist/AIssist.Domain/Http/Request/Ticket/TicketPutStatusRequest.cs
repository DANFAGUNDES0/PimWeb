using System;
namespace AIssist.Domain.Http.Request.Ticket
{
	public class TicketPutStatusRequest
	{
		public string TicketNumber { get; set; }
		public long Status { get; set; }
	}
}

