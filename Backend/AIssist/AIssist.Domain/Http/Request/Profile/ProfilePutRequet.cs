using System;
namespace AIssist.Domain.Http.Request.Profile
{
    public class ProfilePutRequest
    {
        public long Id { get; set; }
        public string? ProfileName { get; set; }
        public bool Active { get; set; }
        public string? Username { get; set; }
    }
}

