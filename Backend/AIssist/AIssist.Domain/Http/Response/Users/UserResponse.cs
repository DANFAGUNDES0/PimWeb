﻿namespace AIssist.Domain.Http.Response.Users
{
	public class UserResponse
	{
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Profile { get; set; }
        public bool Active { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}