using BankApp.Models.DTOs.Cards;
using BankApp.Models.Entities;
using BankApp.Server.Configuration;
using BankApp.Server.Repositories.Interfaces;
using BankApp.Server.Services.Implementations;
using BankApp.Server.Services.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace BankApp.Server.Tests;
public class CardServiceTests
{
    [Fact]
    public void RevealSensitiveDetails_ReturnsCardNumberAndCvv_WhenPasswordMatchesAndTwoFactorDisabled()
    {
        // TODO: implement authentication logic
        ;
    }

    [Fact]
    public void RevealSensitiveDetails_RequiresOtp_WhenTwoFactorEnabledAndOtpMissing()
    {
        // TODO: implement authentication logic
        ;
    }

    [Fact]
    public void RevealSensitiveDetails_ReturnsFailure_WhenPasswordDoesNotMatch()
    {
        // TODO: implement authentication logic
        ;
    }

    [Fact]
    public void RevealSensitiveDetails_ReturnsSensitiveDetails_WhenTwoFactorEnabledAndOtpMatches()
    {
        // TODO: implement authentication logic
        ;
    }

    [Fact]
    public void FreezeCard_UpdatesStatus_WhenOwnedCardExists()
    {
        // TODO: implement freeze card_updates status_when owned card exists logic
        ;
    }

    [Fact]
    public void UnfreezeCard_UpdatesStatus_WhenOwnedFrozenCardExists()
    {
        // TODO: implement unfreeze card_updates status_when owned frozen card exists logic
        ;
    }

    [Fact]
    public void UpdateSettings_ReturnsFailure_WhenSpendingLimitIsNegative()
    {
        // TODO: implement update settings_returns failure_when spending limit is negative logic
        ;
    }

    [Fact]
    public void UpdateSettings_ReturnsFailure_WhenSpendingLimitExceedsConfiguredMaximum()
    {
        // TODO: implement update settings_returns failure_when spending limit exceeds configured maximum logic
        ;
    }

    private static CardService CreateService(Mock<ICardRepository> cardRepositoryMock, Mock<IUserRepository> userRepositoryMock, Mock<IHashService> hashServiceMock, Mock<IOTPService> otpServiceMock, Mock<IEmailService> emailServiceMock)
    {
        // TODO: implement create service logic
        return default !;
    }

    private static Card CreateCard()
    {
        // TODO: implement create card logic
        return default !;
    }

    private static User CreateUser(bool isTwoFactorEnabled)
    {
        // TODO: implement create user logic
        return default !;
    }
}