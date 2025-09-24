using System;
namespace AIssist.Domain.Http.Request.Ticket
{
	public class TicketPutRequest
	{
		public string TicketNumber { get; set; }
		public string Description { get; set; }
		public string Solution { get; set; }
	}
}

