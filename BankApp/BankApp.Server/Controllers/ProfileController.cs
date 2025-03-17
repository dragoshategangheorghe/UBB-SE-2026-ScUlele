using Microsoft.AspNetCore.Mvc;
using BankApp.Server.Services.Interfaces;
using BankApp.Models.DTOs.Profile;
using BankApp.Models.Entities;

namespace BankApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            // TODO: implement profile controller logic
            ;
        }

        private int GetAuthenticatedUserId()
        {
            // TODO: load authenticated user id
            return default !;
        }

        // GET: api/profile
        [HttpGet]
        public IActionResult GetProfile()
        {
            // TODO: load profile
            return default !;
        }

        // PUT: api/profile
        [HttpPut]
        public IActionResult UpdateProfile([FromBody] UpdateProfileRequest request)
        {
            // TODO: implement update profile logic
            return default !;
        }

        // PUT: api/profile/password
        [HttpPut("password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordRequest request)
        {
            // TODO: implement authentication logic
            return default !;
        }

        // GET: api/profile/oauthlinks
        [HttpGet("oauthlinks")]
        public IActionResult GetOAuthLinks()
        {
            // TODO: load oauth links
            return default !;
        }

        // GET: api/profile/notifications/preferences
        [HttpGet("notifications/preferences")]
        public IActionResult GetNotificationPreferences()
        {
            // TODO: load notification preferences
            return default !;
        }

        // PUT: api/profile/notifications/preferences
        [HttpPut("notifications/preferences")]
        public IActionResult UpdateNotificationPreferences([FromBody] List<NotificationPreference> prefs)
        {
            // TODO: implement update notification preferences logic
            return default !;
        }

        // POST: api/profile/verify-password
        [HttpPost("verify-password")]
        public IActionResult VerifyPassword([FromBody] string password)
        {
            // TODO: validate password
            return default !;
        }

        // PUT: api/profile/2fa/enable
        [HttpPut("2fa/enable")]
        public IActionResult Enable2FA([FromBody] Enable2FARequest request)
        {
            // TODO: implement enable2 fa logic
            return default !;
        }

        // PUT: api/profile/2fa/disable
        [HttpPut("2fa/disable")]
        public IActionResult Disable2FA()
        {
            // TODO: implement disable2 fa logic
            return default !;
        }
    }
}