namespace AIssist.Domain.Entities
{
    public class Logs
    {
        public long Id { get; set; }

        public string Action { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTimeOffset CreatedAt { get; set; }
    }
}

