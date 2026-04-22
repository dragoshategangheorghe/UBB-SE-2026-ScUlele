using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Server.Services.Implementations;
using NUnit.Framework;
using NSubstitute;
using BankApp.Server.Repositories.Interfaces;
using BankApp.Models.Entities;
using BankApp.Models.DTOs.Dashboard;

namespace BankApp.Server.Tests
{
    [TestFixture]
    public class DashboardServiceTests
    {
        private IDashboardRepository mockDashboardRepository;
        private IUserRepository mockUserRepository;
        private DashboardService dashboardService;

        [SetUp]
        public void SetUp()
        {
            mockDashboardRepository = Substitute.For<IDashboardRepository>();
            mockUserRepository = Substitute.For<IUserRepository>();

            dashboardService = new DashboardService(mockDashboardRepository, mockUserRepository);
        }

        [Test]
        public void GetDashboardData_NoUserWithID_ReturnsNull()
        {
            int userId = 1;
            mockUserRepository.FindById(userId).Returns((User)null!);

            DashboardResponse response = dashboardService.GetDashboardData(userId);

            Assert.That(response, Is.Null);
        }

        [Test]
        public void GetDashboardData_UserWithID_ReturnsFullDashboardResponse()
        {
            int userId = 1;
            User testUser = new User { Id = userId };
            mockUserRepository.FindById(userId).Returns(testUser);
            mockDashboardRepository.GetCardsByUser(userId).Returns(new List<Card>());
            mockDashboardRepository.GetRecentTransactions(userId).Returns(new List<Transaction>());
            mockDashboardRepository.GetUnreadNotificationCount(userId).Returns(3);

            DashboardResponse response = dashboardService.GetDashboardData(userId);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.CurrentUser, Is.EqualTo(testUser));
            Assert.That(response.Cards, Is.EqualTo(new List<Card>()));
            Assert.That(response.RecentTransactions, Is.EqualTo(new List<Transaction>()));
            Assert.That(response.UnreadNotificationCount, Is.EqualTo(3));
        }
    }
}
