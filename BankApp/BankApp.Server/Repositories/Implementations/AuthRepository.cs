using BankApp.Server.Repositories.Interfaces;
using BankApp.Server.DataAccess.Interfaces;
using BankApp.Models.Entities;
using BankApp.Models.Enums;
using BankApp.Models.Extensions;

namespace BankApp.Server.Repositories.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IUserDAO _userDao;
        private readonly ISessionDAO _sessionDao;
        private readonly IOAuthLinkDAO _oAuthLinkDao;
        private readonly IPasswordResetTokenDAO _passwordResetTokenDao;
        private readonly INotificationPreferenceDAO _notificationPreferenceDao;
        public AuthRepository(IUserDAO userDao, ISessionDAO sessionDao, IOAuthLinkDAO oAuthLinkDao, IPasswordResetTokenDAO passwordResetTokenDao, INotificationPreferenceDAO notificationPreferenceDao)
        {
            // TODO: implement auth repository logic
            ;
        }

        // USER 
        public User? FindUserByEmail(string email)
        {
            // TODO: implement find user by email logic
            return default !;
        }

        public bool CreateUser(User user)
        {
            // TODO: implement create user logic
            return default !;
        }

        // OAUTH
        public OAuthLink? FindOAuthLink(string provider, string providerUserId)
        {
            // TODO: implement authentication logic
            return default !;
        }

        public bool CreateOAuthLink(OAuthLink link)
        {
            // TODO: implement authentication logic
            return default !;
        }

        // SESSIONS
        public Session CreateSession(int userId, string token, string? deviceInfo, string? browser, string? ip)
        {
            // TODO: implement create session logic
            return default !;
        }

        public Session? FindSessionByToken(string token)
        {
            // TODO: implement find session by token logic
            return default !;
        }

        public void InvalidateAllSessions(int userId)
        {
            // TODO: implement invalidate all sessions logic
            ;
        }

        public List<Session> FindSessionsByUserId(int userId)
        {
            // TODO: implement find sessions by user id logic
            return default !;
        }

        public bool UpdateSessionToken(int sessionId)
        {
            // TODO: implement update session token logic
            return default !;
        }

        public void SavePasswordResetToken(PasswordResetToken token)
        {
            // TODO: implement save password reset token logic
            ;
        }

        public PasswordResetToken? FindPasswordResetToken(string tokenHash)
        {
            // TODO: implement authentication logic
            return default !;
        }

        // ACCOUNT SECURITY
        public void IncrementFailedAttempts(int userId)
        {
            // TODO: implement increment failed attempts logic
            ;
        }

        public void ResetFailedAttempts(int userId)
        {
            // TODO: implement reset failed attempts logic
            ;
        }

        public void LockAccount(int userId, DateTime lockoutEnd)
        {
            // TODO: implement lock account logic
            ;
        }

        public User? FindUserById(int id)
        {
            // TODO: implement find user by id logic
            return default !;
        }

        public bool UpdatePassword(int userId, string newPasswordHash)
        {
            // TODO: implement update password logic
            return default !;
        }
    }
}