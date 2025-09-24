﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AIssist.Application.Api.Services.Interfaces;
using AIssist.Domain.Entities;
using AIssist.Domain.Http.Request.Login;
using AIssist.Domain.Http.Response.Login;
using AIssist.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace AIssist.Application.Api.Services
{
    public class AuthService : IAuthService
	{
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IProfileService _profileService;

        public AuthService(IConfiguration configuration, IUserService userService, IProfileService profileService)
		{
            _userService = userService;
            _profileService = profileService;
            _configuration = configuration;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _userService.GetByUsername(request.Username);
            if (user is null)
            {
                return null;
            }
            if (new PasswordHasher<Users>().VerifyHashedPassword(user, user.Password, request.Password)
                == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return CreateTokenResponse(user);
        }

        public Task<LoginResponse?>? RefreshTokensAsync(RefreshTokenRequest request)
        {
            var user = ValidateRefreshToken(request.UserId, request.RefreshToken);
            if (user is null)
                return null;

            return Task.FromResult(CreateTokenResponse(user));
        }

        private Users? ValidateRefreshToken(long userId, string refreshToken)
        {
            var user = _userService.GetById(userId).Result.First();
            if (user is null || user.RefreshToken != refreshToken
                || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return null;
            }

            return user;
        }

        private LoginResponse CreateTokenResponse(Users user)
        {
            return new LoginResponse
            {
                AccessToken = CreateToken(user),
                RefreshToken = GenerateAndSaveRefreshTokenAsync(user).Result,
                Username = user.Username
            };
        }

        private string CreateToken(Users user)
        {
            var profile = _profileService.GetById(user.Profile_Id).Result.First();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, profile.Profile)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetValue<string>("token:key")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("token:issuer"),
                audience: _configuration.GetValue<string>("token:audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private async Task<string> GenerateAndSaveRefreshTokenAsync(Users user)
        {
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(3);
            await _userService.UpdateRefreshToken(user);
            return refreshToken;
        }
    }
}

