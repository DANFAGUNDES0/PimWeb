using System;
namespace AIssist.Domain.Http.Request.Login
{
	public class RefreshTokenRequest
	{
        public long UserId { get; set; }
        public required string RefreshToken { get; set; }
    }
}

