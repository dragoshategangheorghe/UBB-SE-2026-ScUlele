using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models.DTOs.Cards;
using BankApp.Models.DTOs.Dashboard;
using BankApp.Models.Entities;
using BankApp.Server.Configuration;
using BankApp.Server.Repositories.Interfaces;
using BankApp.Server.Services.Implementations;
using BankApp.Server.Services.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using NSubstitute;
using NUnit.Framework;

namespace BankApp.Server.Tests
{
    [TestFixture]
    public class CardServiceTests2
    {
        private ICardRepository mockCardRepository;
        private IUserRepository mockUserRepository;
        private IHashService mockHashService;
        private IOTPService mockOtpService;
        private IEmailService mockEmailService;

        private CardService cardService;

        [SetUp]
        public void SetUp()
        {
             mockCardRepository = Substitute.For<ICardRepository>();
             mockUserRepository = Substitute.For<IUserRepository>();
             mockHashService = Substitute.For<IHashService>();
             mockOtpService = Substitute.For<IOTPService>();
             mockEmailService = Substitute.For<IEmailService>();

             cardService = new CardService(
                 mockCardRepository,
                 mockUserRepository,
                 mockHashService,
                 mockOtpService,
                 mockEmailService,
                 Options.Create(new TeamCOptions()));
        }

        [Test]
        public void UpdateSettings_CardDoesNotExist_ReturnsFailure()
        {
            int cardId = 1;
            mockCardRepository.GetCardById(cardId).Returns((Card)null!);
            CardCommandResponse cardCommandResponse =
                cardService.UpdateSettings(2, cardId, new UpdateCardSettingsRequest());

            Assert.That(cardCommandResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cardCommandResponse.Success, Is.False);
                Assert.That(cardCommandResponse.Message, Is.EqualTo("Card not found."));
            }
        }

        [Test]
        public void UpdateSettings_CardSettingsFailToUpdateInCardRepository_ReturnsFailure()
        {
            Card card = CardServiceTests.CreateCard();
            mockCardRepository.GetCardById(card.Id).Returns(card);
            mockCardRepository
                .UpdateSettings(card.Id, card.MonthlySpendingCap, card.IsOnlineEnabled, card.IsContactlessEnabled)
                .Returns(false);

            CardCommandResponse cardCommandResponse =
                cardService.UpdateSettings(card.UserId, card.Id, new UpdateCardSettingsRequest());

            Assert.That(cardCommandResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cardCommandResponse.Success, Is.False);
                Assert.That(cardCommandResponse.Message, Is.EqualTo("Failed to update card settings."));
            }
        }

        [Test]
        public void UpdateSettings_CardExistsAndRepositoryUpdates_ReturnsSuccess()
        {
            Card card = CardServiceTests.CreateCard();
            mockCardRepository.GetCardById(card.Id).Returns(card);
            mockCardRepository
                .UpdateSettings(card.Id, 1000m, true, true)
                .Returns(true);

            CardCommandResponse cardCommandResponse =
                cardService.UpdateSettings(card.UserId, card.Id, new UpdateCardSettingsRequest
                {
                SpendingLimit = 1000m,
                IsOnlinePaymentsEnabled = true,
                IsContactlessPaymentsEnabled = true
            });

            Assert.That(cardCommandResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cardCommandResponse.Success, Is.True);
                Assert.That(cardCommandResponse.Message, Is.EqualTo("Card settings updated successfully."));
            }
        }

        [Test]
        public void UpdateSortPreference_InvalidSortOption_ReturnsFailure()
        {
            User user = CardServiceTests.CreateUser(false);
            UpdateCardSortPreferenceRequest sortRequest = new UpdateCardSortPreferenceRequest { SortOption = "wrong" };

            CardCommandResponse cardCommandResponse = cardService.UpdateSortPreference(user.Id, sortRequest);

            Assert.That(cardCommandResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cardCommandResponse.Success, Is.False);
                Assert.That(cardCommandResponse.Message, Is.EqualTo("Unsupported card sort option."));
            }
        }
        [Test]
        public void UpdateSortPreference_SortOptionsFailToUpdateInCardRepositor_ReturnsFailure()
        {
            User user = CardServiceTests.CreateUser(false);
            string validSortOption = CardSortOptions.ExpiryDate;
            UpdateCardSortPreferenceRequest sortRequest = new UpdateCardSortPreferenceRequest { SortOption = validSortOption };

            mockCardRepository.SaveSortPreference(user.Id, validSortOption).Returns(false);

            CardCommandResponse cardCommandResponse = cardService.UpdateSortPreference(user.Id, sortRequest);

            Assert.That(cardCommandResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cardCommandResponse.Success, Is.False);
                Assert.That(cardCommandResponse.Message, Is.EqualTo("Failed to update card sort preference."));
            }
        }
        [Test]
        public void UpdateSortPreference_ValidSortOptionAndRepositoryUpdates_ReturnsSuccess()
        {
            User user = CardServiceTests.CreateUser(false);
            string validSortOption = CardSortOptions.ExpiryDate;
            UpdateCardSortPreferenceRequest sortRequest = new UpdateCardSortPreferenceRequest { SortOption = validSortOption };

            mockCardRepository.SaveSortPreference(user.Id, validSortOption).Returns(true);

            CardCommandResponse cardCommandResponse = cardService.UpdateSortPreference(user.Id, sortRequest);

            Assert.That(cardCommandResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cardCommandResponse.Success, Is.True);
                Assert.That(cardCommandResponse.Message, Is.EqualTo("Card sort preference updated successfully."));
            }
        }

        [Test]
        public void FreezeCard_OwnedUnfrozenCardExists_UpdatesStatus()
        {
            Card activeCard = CardServiceTests.CreateCard();
            Card frozenCard = CardServiceTests.CreateCard(); // same data! Only status is changed
            frozenCard.Status = "Frozen";

            mockCardRepository.GetCardById(activeCard.Id).Returns(activeCard, frozenCard); // returns active then on the next call frozen
            mockCardRepository.UpdateStatus(activeCard.Id, "Frozen").Returns(true);

            CardCommandResponse cardCommandResponse = cardService.FreezeCard(activeCard.UserId, activeCard.Id);
            Assert.That(cardCommandResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cardCommandResponse.Success, Is.True);
                Assert.That(cardCommandResponse.Message, Is.EqualTo("Card frozen successfully."));
                Assert.That(cardCommandResponse.Card?.Status, Is.EqualTo("Frozen"));
            }
        }

        [Test]
        public void UnfreezeCard_OwnedUnfrozenCardExists_UpdatesStatus()
        {
            Card activeCard = CardServiceTests.CreateCard();

            mockCardRepository.GetCardById(activeCard.Id).Returns(activeCard, activeCard); // returns active then on the next call frozen
            mockCardRepository.UpdateStatus(activeCard.Id, "Active").Returns(true);

            CardCommandResponse cardCommandResponse = cardService.UnfreezeCard(activeCard.UserId, activeCard.Id);
            Assert.That(cardCommandResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cardCommandResponse.Success, Is.True);
                Assert.That(cardCommandResponse.Message, Is.EqualTo("Card unfrozen successfully."));
                Assert.That(cardCommandResponse.Card?.Status, Is.EqualTo("Active"));
            }
        }
        [Test]
        public void FreezeCard_CardDoesNotExist_ReturnsFailure()
        {
            Card card = CardServiceTests.CreateCard();

            mockCardRepository.GetCardById(card.Id).Returns((Card)null!);

            CardCommandResponse cardCommandResponse = cardService.FreezeCard(card.UserId, card.Id);
            Assert.That(cardCommandResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cardCommandResponse.Success, Is.False);
                Assert.That(cardCommandResponse.Message, Is.EqualTo("Card not found."));
            }
        }

        [Test]
        public void UnreezeCard_CardDoesNotExist_ReturnsFailure()
        {
            Card card = CardServiceTests.CreateCard();

            mockCardRepository.GetCardById(card.Id).Returns((Card)null!);

            CardCommandResponse cardCommandResponse = cardService.UnfreezeCard(card.UserId, card.Id);
            Assert.That(cardCommandResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cardCommandResponse.Success, Is.False);
                Assert.That(cardCommandResponse.Message, Is.EqualTo("Card not found."));
            }
        }
        [Test]
        public void FreezeCard_RepositoryFailsToUpdate_ReturnsFailure()
        {
            Card card = CardServiceTests.CreateCard();

            mockCardRepository.GetCardById(card.Id).Returns(card);
            mockCardRepository.UpdateStatus(card.Id, "Frozen").Returns(false);

            CardCommandResponse cardCommandResponse = cardService.FreezeCard(card.UserId, card.Id);
            Assert.That(cardCommandResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cardCommandResponse.Success, Is.False);
                Assert.That(cardCommandResponse.Message, Is.EqualTo("Failed to update card status."));
            }
        }
        [Test]
        public void UnfreezeCard_RepositoryFailsToUpdate_ReturnsFailure()
        {
            Card card = CardServiceTests.CreateCard();
            card.Status = "Frozen";

            mockCardRepository.GetCardById(card.Id).Returns(card);
            mockCardRepository.UpdateStatus(card.Id, "Active").Returns(false);

            CardCommandResponse cardCommandResponse = cardService.UnfreezeCard(card.UserId, card.Id);
            Assert.That(cardCommandResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(cardCommandResponse.Success, Is.False);
                Assert.That(cardCommandResponse.Message, Is.EqualTo("Failed to update card status."));
            }
        }

        [Test]
        public void RevealSensitiveDetails_TwoFactorEnabledAndOtpDoesNotMatch_ReturnsSensitiveDetails()
        {
            Card card = CardServiceTests.CreateCard();
            User user = CardServiceTests.CreateUser(isTwoFactorEnabled: true);

            mockCardRepository.GetCardById(card.Id).Returns(card);
            mockUserRepository.FindById(user.Id).Returns(user);
            mockHashService.Verify("secret", user.PasswordHash).Returns(true);
            mockOtpService.VerifyTOTP(user.Id, "67420").Returns(false);

            RevealCardResponse revealCardResponse =
            cardService.RevealSensitiveDetails(user.Id, card.Id, new RevealCardRequest
            {
                Password = "secret",
                OtpCode = "654321"
            });

            Assert.That(revealCardResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(revealCardResponse.Success, Is.False);
                Assert.That(revealCardResponse.Message, Is.EqualTo("Invalid or expired OTP code."));
            }
        }

        [Test]
        public void RevealSensitiveDetails_UserDoesNotExist_ReturnsSensitiveDetails()
        {
            Card card = CardServiceTests.CreateCard();
            User user = CardServiceTests.CreateUser(isTwoFactorEnabled: true);

            mockCardRepository.GetCardById(card.Id).Returns(card);
            mockUserRepository.FindById(user.Id).Returns((User)null!);
            mockHashService.Verify("secret", user.PasswordHash).Returns(true);
            mockOtpService.VerifyTOTP(user.Id, "67420").Returns(false);

            RevealCardResponse revealCardResponse =
                cardService.RevealSensitiveDetails(user.Id, card.Id, new RevealCardRequest
                {
                    Password = "secret",
                    OtpCode = "654321"
                });

            Assert.That(revealCardResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(revealCardResponse.Success, Is.False);
                Assert.That(revealCardResponse.Message, Is.EqualTo("User not found."));
            }
        }

        [Test]
        public void RevealSensitiveDetails_CardDoesNotExist_ReturnsSensitiveDetails()
        {
            Card card = CardServiceTests.CreateCard();
            User user = CardServiceTests.CreateUser(isTwoFactorEnabled: true);

            mockCardRepository.GetCardById(card.Id).Returns((Card)null!);
            mockUserRepository.FindById(user.Id).Returns(user);
            mockHashService.Verify("secret", user.PasswordHash).Returns(true);
            mockOtpService.VerifyTOTP(user.Id, "67420").Returns(false);

            RevealCardResponse revealCardResponse =
                cardService.RevealSensitiveDetails(user.Id, card.Id, new RevealCardRequest
                {
                    Password = "secret",
                    OtpCode = "654321"
                });

            Assert.That(revealCardResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(revealCardResponse.Success, Is.False);
                Assert.That(revealCardResponse.Message, Is.EqualTo("Card not found."));
            }
        }
    }
}
