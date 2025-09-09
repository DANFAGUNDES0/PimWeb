namespace AIssist.Domain.Http.Request.RootCause
{
	public class RootCausePostRequest
	{
        public string? RootCause { get; set; }
        public long CriticalityId { get; set; }
        public string? CreatedBy { get; set; }
    }
}

