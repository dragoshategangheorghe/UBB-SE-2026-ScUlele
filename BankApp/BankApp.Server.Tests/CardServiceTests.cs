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
        Mock<ICardRepository> cardRepositoryMock = new ();
        Mock<IUserRepository> userRepositoryMock = new ();
        Mock<IHashService> hashServiceMock = new ();
        Mock<IOTPService> otpServiceMock = new ();
        Mock<IEmailService> emailServiceMock = new ();

        Card card = CreateCard();
        User user = CreateUser(isTwoFactorEnabled: false);

        cardRepositoryMock.Setup(repository => repository.GetCardById(card.Id)).Returns(card);
        userRepositoryMock.Setup(repository => repository.FindById(user.Id)).Returns(user);
        hashServiceMock.Setup(service => service.Verify("secret", user.PasswordHash)).Returns(true);

        CardService service = CreateService(
            cardRepositoryMock,
            userRepositoryMock,
            hashServiceMock,
            otpServiceMock,
            emailServiceMock);

        RevealCardResponse response = service.RevealSensitiveDetails(user.Id, card.Id, new RevealCardRequest
        {
            Password = "secret"
        });

        Assert.True(response.Success);
        Assert.NotNull(response.SensitiveDetails);
        Assert.Equal(card.CardNumber, response.SensitiveDetails!.CardNumber);
        Assert.Equal(card.CVV, response.SensitiveDetails.Cvv);
    }

    [Fact]
    public void RevealSensitiveDetails_RequiresOtp_WhenTwoFactorEnabledAndOtpMissing()
    {
        Mock<ICardRepository> cardRepositoryMock = new ();
        Mock<IUserRepository> userRepositoryMock = new ();
        Mock<IHashService> hashServiceMock = new ();
        Mock<IOTPService> otpServiceMock = new ();
        Mock<IEmailService> emailServiceMock = new ();

        Card card = CreateCard();
        User user = CreateUser(isTwoFactorEnabled: true);

        cardRepositoryMock.Setup(repository => repository.GetCardById(card.Id)).Returns(card);
        userRepositoryMock.Setup(repository => repository.FindById(user.Id)).Returns(user);
        hashServiceMock.Setup(service => service.Verify("secret", user.PasswordHash)).Returns(true);
        otpServiceMock.Setup(service => service.GenerateTOTP(user.Id)).Returns("123456");

        CardService service = CreateService(
            cardRepositoryMock,
            userRepositoryMock,
            hashServiceMock,
            otpServiceMock,
            emailServiceMock);

        RevealCardResponse response = service.RevealSensitiveDetails(user.Id, card.Id, new RevealCardRequest
        {
            Password = "secret"
        });

        Assert.False(response.Success);
        Assert.True(response.RequiresOtp);
        emailServiceMock.Verify(service => service.SendOTPCode(user.Email, "123456"), Times.Once);
    }

    [Fact]
    public void RevealSensitiveDetails_ReturnsFailure_WhenPasswordDoesNotMatch()
    {
        Mock<ICardRepository> cardRepositoryMock = new ();
        Mock<IUserRepository> userRepositoryMock = new ();
        Mock<IHashService> hashServiceMock = new ();
        Mock<IOTPService> otpServiceMock = new ();
        Mock<IEmailService> emailServiceMock = new ();

        Card card = CreateCard();
        User user = CreateUser(isTwoFactorEnabled: false);

        cardRepositoryMock.Setup(repository => repository.GetCardById(card.Id)).Returns(card);
        userRepositoryMock.Setup(repository => repository.FindById(user.Id)).Returns(user);
        hashServiceMock.Setup(service => service.Verify("wrong-secret", user.PasswordHash)).Returns(false);

        CardService service = CreateService(
            cardRepositoryMock,
            userRepositoryMock,
            hashServiceMock,
            otpServiceMock,
            emailServiceMock);

        RevealCardResponse response = service.RevealSensitiveDetails(user.Id, card.Id, new RevealCardRequest
        {
            Password = "wrong-secret"
        });

        Assert.False(response.Success);
        Assert.False(response.RequiresOtp);
        Assert.Null(response.SensitiveDetails);
        Assert.Contains("Password verification failed", response.Message);
        otpServiceMock.Verify(service => service.VerifyTOTP(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        emailServiceMock.Verify(service => service.SendOTPCode(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void RevealSensitiveDetails_ReturnsSensitiveDetails_WhenTwoFactorEnabledAndOtpMatches()
    {
        Mock<ICardRepository> cardRepositoryMock = new ();
        Mock<IUserRepository> userRepositoryMock = new ();
        Mock<IHashService> hashServiceMock = new ();
        Mock<IOTPService> otpServiceMock = new ();
        Mock<IEmailService> emailServiceMock = new ();

        Card card = CreateCard();
        User user = CreateUser(isTwoFactorEnabled: true);

        cardRepositoryMock.Setup(repository => repository.GetCardById(card.Id)).Returns(card);
        userRepositoryMock.Setup(repository => repository.FindById(user.Id)).Returns(user);
        hashServiceMock.Setup(service => service.Verify("secret", user.PasswordHash)).Returns(true);
        otpServiceMock.Setup(service => service.VerifyTOTP(user.Id, "654321")).Returns(true);

        CardService service = CreateService(
            cardRepositoryMock,
            userRepositoryMock,
            hashServiceMock,
            otpServiceMock,
            emailServiceMock);

        RevealCardResponse response = service.RevealSensitiveDetails(user.Id, card.Id, new RevealCardRequest
        {
            Password = "secret",
            OtpCode = "654321"
        });

        Assert.True(response.Success);
        Assert.NotNull(response.SensitiveDetails);
        Assert.Equal(card.CardNumber, response.SensitiveDetails!.CardNumber);
        Assert.Equal(card.CVV, response.SensitiveDetails.Cvv);
        otpServiceMock.Verify(service => service.VerifyTOTP(user.Id, "654321"), Times.Once);
        otpServiceMock.Verify(service => service.InvalidateOTP(user.Id), Times.Once);
        emailServiceMock.Verify(service => service.SendOTPCode(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void FreezeCard_UpdatesStatus_WhenOwnedCardExists()
    {
        Mock<ICardRepository> cardRepositoryMock = new ();
        Mock<IUserRepository> userRepositoryMock = new ();
        Mock<IHashService> hashServiceMock = new ();
        Mock<IOTPService> otpServiceMock = new ();
        Mock<IEmailService> emailServiceMock = new ();

        Card card = CreateCard();
        cardRepositoryMock.Setup(repository => repository.GetCardById(card.Id)).Returns(card);
        cardRepositoryMock.Setup(repository => repository.UpdateStatus(card.Id, "Frozen")).Returns(true);
        cardRepositoryMock.SetupSequence(repository => repository.GetCardById(card.Id))
            .Returns(card)
            .Returns(new Card
            {
                Id = card.Id,
                UserId = card.UserId,
                AccountId = card.AccountId,
                CardNumber = card.CardNumber,
                CardholderName = card.CardholderName,
                ExpiryDate = card.ExpiryDate,
                CVV = card.CVV,
                CardType = card.CardType,
                CardBrand = card.CardBrand,
                Status = "Frozen"
            });

        CardService service = CreateService(
            cardRepositoryMock,
            userRepositoryMock,
            hashServiceMock,
            otpServiceMock,
            emailServiceMock);

        CardCommandResponse response = service.FreezeCard(card.UserId, card.Id);

        Assert.True(response.Success);
        Assert.Equal("Frozen", response.Card!.Status);
    }

    [Fact]
    public void UnfreezeCard_UpdatesStatus_WhenOwnedFrozenCardExists()
    {
        Mock<ICardRepository> cardRepositoryMock = new ();
        Mock<IUserRepository> userRepositoryMock = new ();
        Mock<IHashService> hashServiceMock = new ();
        Mock<IOTPService> otpServiceMock = new ();
        Mock<IEmailService> emailServiceMock = new ();

        Card frozenCard = CreateCard();
        frozenCard.Status = "Frozen";

        cardRepositoryMock.SetupSequence(repository => repository.GetCardById(frozenCard.Id))
            .Returns(frozenCard)
            .Returns(new Card
            {
                Id = frozenCard.Id,
                UserId = frozenCard.UserId,
                AccountId = frozenCard.AccountId,
                CardNumber = frozenCard.CardNumber,
                CardholderName = frozenCard.CardholderName,
                ExpiryDate = frozenCard.ExpiryDate,
                CVV = frozenCard.CVV,
                CardType = frozenCard.CardType,
                CardBrand = frozenCard.CardBrand,
                Status = "Active",
                MonthlySpendingCap = frozenCard.MonthlySpendingCap,
                IsOnlineEnabled = frozenCard.IsOnlineEnabled,
                IsContactlessEnabled = frozenCard.IsContactlessEnabled
            });
        cardRepositoryMock.Setup(repository => repository.UpdateStatus(frozenCard.Id, "Active")).Returns(true);

        CardService service = CreateService(
            cardRepositoryMock,
            userRepositoryMock,
            hashServiceMock,
            otpServiceMock,
            emailServiceMock);

        CardCommandResponse response = service.UnfreezeCard(frozenCard.UserId, frozenCard.Id);

        Assert.True(response.Success);
        Assert.Equal("Active", response.Card!.Status);
    }

    [Fact]
    public void UpdateSettings_ReturnsFailure_WhenSpendingLimitIsNegative()
    {
        Mock<ICardRepository> cardRepositoryMock = new ();
        Mock<IUserRepository> userRepositoryMock = new ();
        Mock<IHashService> hashServiceMock = new ();
        Mock<IOTPService> otpServiceMock = new ();
        Mock<IEmailService> emailServiceMock = new ();

        Card card = CreateCard();
        cardRepositoryMock.Setup(repository => repository.GetCardById(card.Id)).Returns(card);

        CardService service = CreateService(
            cardRepositoryMock,
            userRepositoryMock,
            hashServiceMock,
            otpServiceMock,
            emailServiceMock);

        CardCommandResponse response = service.UpdateSettings(card.UserId, card.Id, new UpdateCardSettingsRequest
        {
            SpendingLimit = -5m
        });

        Assert.False(response.Success);
        Assert.Contains("non-negative", response.Message);
    }

    [Fact]
    public void UpdateSettings_ReturnsFailure_WhenSpendingLimitExceedsConfiguredMaximum()
    {
        Mock<ICardRepository> cardRepositoryMock = new ();
        Mock<IUserRepository> userRepositoryMock = new ();
        Mock<IHashService> hashServiceMock = new ();
        Mock<IOTPService> otpServiceMock = new ();
        Mock<IEmailService> emailServiceMock = new ();

        Card card = CreateCard();
        cardRepositoryMock.Setup(repository => repository.GetCardById(card.Id)).Returns(card);

        CardService service = new (
            cardRepositoryMock.Object,
            userRepositoryMock.Object,
            hashServiceMock.Object,
            otpServiceMock.Object,
            emailServiceMock.Object,
            Options.Create(new TeamCOptions
            {
                MaximumSpendingLimit = 1000m
            }));

        CardCommandResponse response = service.UpdateSettings(card.UserId, card.Id, new UpdateCardSettingsRequest
        {
            SpendingLimit = 1500m
        });

        Assert.False(response.Success);
        Assert.Contains("cannot exceed 1000", response.Message);
        cardRepositoryMock.Verify(
            repository => repository.UpdateSettings(It.IsAny<int>(), It.IsAny<decimal?>(), It.IsAny<bool>(), It.IsAny<bool>()),
            Times.Never);
    }

    private static CardService CreateService(
        Mock<ICardRepository> cardRepositoryMock,
        Mock<IUserRepository> userRepositoryMock,
        Mock<IHashService> hashServiceMock,
        Mock<IOTPService> otpServiceMock,
        Mock<IEmailService> emailServiceMock)
    {
        return new CardService(
            cardRepositoryMock.Object,
            userRepositoryMock.Object,
            hashServiceMock.Object,
            otpServiceMock.Object,
            emailServiceMock.Object,
            Options.Create(new TeamCOptions()));
    }

    private static Card CreateCard()
    {
        return new Card
        {
            Id = 7,
            UserId = 3,
            AccountId = 11,
            CardNumber = "5555444433331111",
            CardholderName = "Ada Lovelace",
            ExpiryDate = new DateTime(2030, 12, 1),
            CVV = "123",
            CardType = "Debit",
            CardBrand = "Mastercard",
            Status = "Active",
            MonthlySpendingCap = 2500m,
            IsOnlineEnabled = true,
            IsContactlessEnabled = true
        };
    }

    private static User CreateUser(bool isTwoFactorEnabled)
    {
        return new User
        {
            Id = 3,
            Email = "ada@example.com",
            PasswordHash = "hashed",
            FullName = "Ada Lovelace",
            Is2FAEnabled = isTwoFactorEnabled,
            Preferred2FAMethod = "Email"
        };
    }
}
