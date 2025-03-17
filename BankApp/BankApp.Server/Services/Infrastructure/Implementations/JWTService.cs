using BankApp.Server.Services.Infrastructure.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankApp.Server.Services.Infrastructure.Implementations
{
    public class JWTService : IJWTService
    {
        private readonly string _secret;
        public JWTService(string secret)
        {
            // TODO: implement jwtservice logic
            ;
        }

        public string GenerateToken(int userId)
        {
            // TODO: implement generate token logic
            return default !;
        }

        public ClaimsPrincipal? ValidateToken(string token)
        {
            // TODO: validate token
            return default !;
        }

        public int? ExtractUserId(string token)
        {
            // TODO: implement extract user id logic
            return default !;
        }
    }
}