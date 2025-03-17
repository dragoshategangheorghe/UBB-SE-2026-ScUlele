using Xunit;
using Moq;
using System.Collections.Generic;
using BankApp.Server.Repositories.Implementations;
using BankApp.Server.DataAccess.Interfaces;
using BankApp.Models.Entities;

public class UserRepositoryTests
{
    private readonly Mock<IUserDAO> _userDaoMock;
    private readonly Mock<ISessionDAO> _sessionDaoMock;
    private readonly Mock<IOAuthLinkDAO> _oauthDaoMock;
    private readonly Mock<INotificationPreferenceDAO> _notifDaoMock;
    private readonly UserRepository _userRepository;
    public UserRepositoryTests()
    {
        // TODO: implement user repository tests logic
        ;
    }

    [Fact]
    public void UpdateUser_ReturnsTrue_WhenSuccessful()
    {
        // TODO: implement update user_returns true_when successful logic
        ;
    }

    [Fact]
    public void UpdateUser_ReturnFalse_WhenSuccess()
    {
        // TODO: implement update user_return false_when success logic
        ;
    }

    //Session
    [Fact]
    public void GetActiveSessions_ReturnsSessions()
    {
        // TODO: load active sessions_returns sessions
        ;
    }

    [Fact]
    public void DeleteOAuthLink_CallsDao()
    {
        // TODO: implement authentication logic
        ;
    }

    //Notification Preferences
    [Fact]
    public void GetNotificationPreferences_ReturnsPreferences()
    {
        // TODO: load notification preferences_returns preferences
        ;
    }

    [Fact]
    public void UpdateNotificationPreferences_ReturnsTrue()
    {
        // TODO: implement update notification preferences_returns true logic
        ;
    }
}