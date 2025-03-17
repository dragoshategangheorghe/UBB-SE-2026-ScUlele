using Microsoft.AspNetCore.Mvc;
using BankApp.Server.Services.Interfaces;
using BankApp.Models.DTOs.Auth;
using BankApp.Server.DataAccess;
using Microsoft.AspNetCore.Connections.Features;

namespace BankApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            // TODO: implement auth controller logic
            ;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // TODO: implement authentication logic
            return default !;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            // TODO: implement authentication logic
            return default !;
        }

        [HttpPost("verify-otp")]
        public IActionResult VerifyOTP([FromBody] VerifyOTPRequest request)
        {
            // TODO: validate otp
            return default !;
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            // TODO: implement authentication logic
            return default !;
        }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            // TODO: implement authentication logic
            return default !;
        }

        [HttpPost("logout")]
        public IActionResult Logout([FromHeader(Name = "Authorization")] string authorization)
        {
            // TODO: implement authentication logic
            return default !;
        }

        [HttpPost("resend-otp")]
        public IActionResult ResendOTP([FromQuery] int userId, [FromQuery] string method = "email")
        {
            // TODO: implement authentication logic
            return default !;
        }

        [HttpPost("oauth-login")]
        public async Task<IActionResult> OAuthLogin([FromBody] OAuthLoginRequest request)
        {
            // TODO: implement authentication logic
            return default !;
        }

        public class VerifyTokenDto
        {
            public string Token { get; set; } = string.Empty;
        }

        [HttpPost("verify-reset-token")]
        public IActionResult VerifyResetToken([FromBody] VerifyTokenDto request)
        {
            // TODO: validate token
            return default !;
        }
    }
}