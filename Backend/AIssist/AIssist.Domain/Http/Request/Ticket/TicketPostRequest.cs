﻿namespace AIssist.Domain.Http.Request.Ticket
{
	public class TicketPostRequest
	{
		public string? Description { get; set; }
		public string? Solution { get; set; }		
		public long ReporterId { get; set; }
		public long RootCauseId { get; set; }
	}
}

