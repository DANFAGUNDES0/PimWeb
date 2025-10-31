namespace AIssist.Domain.Entities
{
    public class Users
    {
        public long Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime UpdatedAt { get; set; }

        public long ProfileId { get; set; }

        public bool Active { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

        public Profiles? Profile { get; set; }
    }
}

