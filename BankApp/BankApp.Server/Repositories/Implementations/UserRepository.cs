using BankApp.Models.Enums;

namespace BankApp.Server.Repositories.Implementations;
using BankApp.Models.Entities;
using BankApp.Server.DataAccess.Interfaces;
using BankApp.Server.Repositories.Interfaces;

public class UserRepository : IUserRepository
{
    private readonly IUserDAO _userDao;
    private readonly ISessionDAO _sessionDao;
    private readonly IOAuthLinkDAO _oAuthLinkDao;
    private readonly INotificationPreferenceDAO _notificationPreferenceDao;
    public UserRepository(IUserDAO userDao, ISessionDAO sessionDao, IOAuthLinkDAO oAuthLinkDao, INotificationPreferenceDAO notificationPreferenceDao)
    {
        // TODO: implement user repository logic
        ;
    }

    public User? FindById(int id)
    {
        // TODO: implement find by id logic
        return default !;
    }

    public bool UpdateUser(User user)
    {
        // TODO: implement update user logic
        return default !;
    }

    public bool UpdatePassword(int userId, string newPasswordHash)
    {
        // TODO: implement update password logic
        return default !;
    }

    public List<Session> GetActiveSessions(int userId)
    {
        // TODO: load active sessions
        return default !;
    }

    public void RevokeSession(int sessionId)
    {
        // TODO: implement revoke session logic
        ;
    }

    public List<OAuthLink> GetLinkedProviders(int userId)
    {
        // TODO: load linked providers
        return default !;
    }

    public bool SaveOAuthLink(int userId, string provider, string providerUserId, string? email)
    {
        // TODO: implement save oauth link logic
        return default !;
    }

    public void DeleteOAuthLink(int linkId)
    {
        // TODO: implement authentication logic
        ;
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
}