using Azure.Core;
using BankApp.Models.DTOs.Profile;
using BankApp.Models.Entities;
using BankApp.Models.Enums;
using BankApp.Server.Repositories;
using BankApp.Server.Repositories.Interfaces;
using BankApp.Server.Services.Infrastructure.Implementations;
using BankApp.Server.Services.Infrastructure.Interfaces;
using BankApp.Server.Services.Interfaces;
using BankApp.Server.Utilities;

namespace BankApp.Server.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashService _hashService;
        public ProfileService(IUserRepository userRepository, IHashService hashService)
        {
            // TODO: implement profile service logic
            ;
        }

        public User? GetUserById(int userId)
        {
            // TODO: load user by id
            return default !;
        }

        public UpdateProfileResponse UpdatePersonalInfo(UpdateProfileRequest request)
        {
            // TODO: implement update personal info logic
            return default !;
        }

        public ChangePasswordResponse ChangePassword(ChangePasswordRequest request)
        {
            // TODO: implement authentication logic
            return default !;
        }

        public bool Enable2FA(int userId, TwoFactorMethod method)
        {
            // TODO: implement enable2 fa logic
            return default !;
        }

        public bool Disable2FA(int userId)
        {
            // TODO: implement disable2 fa logic
            return default !;
        }

        public List<OAuthLink> GetOAuthLinks(int userId)
        {
            // TODO: load oauth links
            return default !;
        }

        public bool LinkOAuth(int userId, string provider)
        {
            // TODO: implement authentication logic
            return default !;
        }

        public bool UnlinkOAuth(int userId, string provider)
        {
            // TODO: implement authentication logic
            return default !;
        }

        public List<NotificationPreference> GetNotificationPreferences(int userId)
        {
            // TODO: load notification preferences
            return default !;
        }

        public bool UpdateNotificationPreferences(int userId, List<NotificationPreference> prefs)
        {
            // TODO: implement update notification preferences logic
            return default !;
        }

        public bool VerifyPassword(int userId, string password)
        {
            // TODO: validate password
            return default !;
        }
    }
}