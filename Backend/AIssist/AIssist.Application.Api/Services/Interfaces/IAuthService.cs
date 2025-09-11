using AIssist.Domain.Http.Request.Login;
using AIssist.Domain.Http.Response.Login;

namespace AIssist.Application.Api.Services.Interfaces
{
    public interface IAuthService
	{
        Task<LoginResponse?> LoginAsync(LoginRequest request);
        Task<LoginResponse?> RefreshTokensAsync(RefreshTokenRequest request);
    }
}

