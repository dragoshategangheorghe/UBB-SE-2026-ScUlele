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
        public void UpdateSettings_ReturnsFailure_WhenCardIsNull()
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
    }
}
