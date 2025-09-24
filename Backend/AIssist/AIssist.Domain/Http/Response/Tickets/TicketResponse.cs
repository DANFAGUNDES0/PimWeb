namespace AIssist.Domain.Http.Response.Tickets
{
	public class TicketResponse
	{
		public long Id { get; set; }
		public string? Description { get; set; }
		public string? Solution { get; set; }
		public string? TicketNumber { get; set; }
		public string? Status { get; set; }
		public long StatusId { get; set; }
		public string? Criticality { get; set; }
		public long CriticalityId { get; set; }
        public string? RootCause { get; set; }
        public long RootCauseId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

