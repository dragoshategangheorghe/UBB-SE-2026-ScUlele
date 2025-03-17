using BankApp.Server.Repositories.Interfaces;
using BankApp.Server.Services.Infrastructure.Interfaces;

namespace BankApp.Server.Middleware
{
    public class SessionValidationMiddleware
    {
        private readonly RequestDelegate _next;
        public SessionValidationMiddleware(RequestDelegate next)
        {
            // TODO: implement session validation middleware logic
            ;
        }

        public async Task Invoke(HttpContext context, IAuthRepository authRepository, IJWTService jwtService)
        {
            // TODO: implement invoke logic
            ;
        }

        private bool IsPublicEndpoint(string? path)
        {
            // TODO: implement is public endpoint logic
            return default !;
        }

        private async Task RejectRequest(HttpContext context, string error)
        {
            // TODO: implement reject request logic
            ;
        }
    }
}