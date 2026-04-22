using BankApp.Models.DTOs.Transactions;
using BankApp.Models.DTOs.Statistics;
using BankApp.Server.Configuration;
using BankApp.Server.Repositories.Interfaces;
using BankApp.Server.Services.Implementations;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;

namespace BankApp.Server.Tests
{
    [TestFixture]
    public class StatisticsServiceTests
    {
        private ITransactionHistoryRepository mockTransactionHistoryRepository;
        private IOptions<TeamCOptions> options;
        private StatisticsService statisticsService;

        [SetUp]
        public void SetUp()
        {
            mockTransactionHistoryRepository = Substitute.For<ITransactionHistoryRepository>();
            options = Options.Create(new TeamCOptions());

            statisticsService = new StatisticsService(mockTransactionHistoryRepository, options);
        }

        [Test]
        public void GetSpendingByCategory_CalculatesCorrectly()
        {
            int userId = 1;
            mockTransactionHistoryRepository.GetTransactionsByUserId(userId).Returns(new List<TransactionHistoryItemDto>
            {
                new TransactionHistoryItemDto { Amount = 100, Direction = "Debit", Status = "Completed", CategoryName = "Food" },
                new TransactionHistoryItemDto { Amount = 50, Direction = "Credit", Status = "Completed", CategoryName = "Food" },
                new TransactionHistoryItemDto { Amount = 30, Direction = "Debit", Status = "Completed", CategoryName = "Transport" },
                new TransactionHistoryItemDto { Amount = 90, Direction = "Credit", Status = "Completed", CategoryName = "Ignored" }
            });

            var result = statisticsService.GetSpendingByCategory(userId);

            Assert.That(result.Success, Is.True);
            Assert.That(result.TotalSpending, Is.EqualTo(130));
            Assert.That(result.Categories.Count, Is.EqualTo(2));

            Assert.That(result.Categories[0].CategoryName, Is.EqualTo("Food"));
            Assert.That(result.Categories[0].Amount, Is.EqualTo(100));

            Assert.That(result.Categories[1].CategoryName, Is.EqualTo("Transport"));
            Assert.That(result.Categories[1].Amount, Is.EqualTo(30));
        }

        [Test]
        public void GetSpendingByCategory_HandlesEmptyCategory_AsUncategorized()
        {
            int userId = 1;
            mockTransactionHistoryRepository.GetTransactionsByUserId(userId).Returns(new List<TransactionHistoryItemDto>
            {
                new TransactionHistoryItemDto { Amount = 10, Direction = "Debit", Status = "Completed", CategoryName = " " },
                new TransactionHistoryItemDto { Amount = 50, Direction = "Debit", Status = "Completed", CategoryName = "   " }
            });

            SpendingByCategoryResponse result = statisticsService.GetSpendingByCategory(userId);

            Assert.That(result.Categories.Count, Is.EqualTo(1));
            Assert.That(result.Categories[0].CategoryName, Is.EqualTo("Uncategorized"));
            Assert.That(result.Categories[0].Amount, Is.EqualTo(60));
        }

        [Test]
        public void GetSpendingByCategory_ShareOfTotalOfCategories_IsCalculatedCorrectly()
        {
            int userId = 1;
            mockTransactionHistoryRepository.GetTransactionsByUserId(userId).Returns(new List<TransactionHistoryItemDto>
            {
                new TransactionHistoryItemDto { Amount = 67, Direction = "Debit", Status = "Completed", CategoryName = "Food" },
                new TransactionHistoryItemDto { Amount = 33, Direction = "Debit", Status = "Completed", CategoryName = "Transport" }
            });

            SpendingByCategoryResponse result = statisticsService.GetSpendingByCategory(userId);

            Assert.That(result.TotalSpending, Is.EqualTo(100));
            Assert.That(result.Categories[0].ShareOfTotal, Is.EqualTo(0.67m));
            Assert.That(result.Categories[1].ShareOfTotal, Is.EqualTo(0.33m));
        }

        [Test]
        public void GetSpendingByCategory_ShareOfTotalOfCategories_SetToZero_IfTotalSpendingIsZero()
        {
            int userId = 1;
            mockTransactionHistoryRepository.GetTransactionsByUserId(userId).Returns(new List<TransactionHistoryItemDto>
            {
                new TransactionHistoryItemDto { Amount = 0, Direction = "Debit", Status = "Completed", CategoryName = "Food" },
                new TransactionHistoryItemDto { Amount = 0, Direction = "Debit", Status = "Completed", CategoryName = "Transport" }
            });

            SpendingByCategoryResponse result = statisticsService.GetSpendingByCategory(userId);

            Assert.That(result.TotalSpending, Is.EqualTo(0));
            Assert.That(result.Categories[0].ShareOfTotal, Is.Zero);
            Assert.That(result.Categories[1].ShareOfTotal, Is.Zero);
        }

        [Test]
        public void GetIncomeVsExpenses_ComputesIncomeExpensesAndNet()
        {
            int userId = 1;
            mockTransactionHistoryRepository.GetTransactionsByUserId(userId).Returns(new List<TransactionHistoryItemDto>
            {
                new TransactionHistoryItemDto { Amount = 94, Direction = "Credit", Status = "Completed" },
                new TransactionHistoryItemDto { Amount = 53, Direction = "Debit", Status = "Completed" },
                new TransactionHistoryItemDto { Amount = 138, Direction = "Debit", Status = "Failed" }
            });

            IncomeVsExpensesResponse result = statisticsService.GetIncomeVsExpenses(userId);

            Assert.That(result.Income, Is.EqualTo(94));
            Assert.That(result.Expenses, Is.EqualTo(53));
            Assert.That(result.Net, Is.EqualTo(41));
        }

        [Test]
        public void GetBalanceTrends_SelectsLatestPerDay()
        {
            int userId = 1;
            var cutoff = new DateTime(2026, 3, 24);
            mockTransactionHistoryRepository.GetTransactionsByUserId(userId).Returns(new List<TransactionHistoryItemDto>
            {
                new TransactionHistoryItemDto { Id = 1, Timestamp = cutoff.AddHours(3), RunningBalanceAfterTransaction = 100, Status = "Completed" },
                new TransactionHistoryItemDto { Id = 2, Timestamp = cutoff.AddHours(2), RunningBalanceAfterTransaction = 200, Status = "Completed" },
                new TransactionHistoryItemDto { Id = 3, Timestamp = cutoff.AddDays(1), RunningBalanceAfterTransaction = 300, Status = "Completed" }
            });

            BalanceTrendsResponse result = statisticsService.GetBalanceTrends(userId);

            Assert.That(result.Points.Count, Is.EqualTo(2));
            Assert.That(result.Points[0].Balance, Is.EqualTo(100));
            Assert.That(result.Points[1].Balance, Is.EqualTo(300));
        }

        [Test]
        public void GetTopRecipients_RespectsTopCountAndOrdering()
        {
            int userId = 1;
            mockTransactionHistoryRepository.GetTransactionsByUserId(userId).Returns(new List<TransactionHistoryItemDto>
            {
                new TransactionHistoryItemDto { Amount = 100, Direction = "Debit", Status = "Completed", CounterpartyOrMerchant = "A" },
                new TransactionHistoryItemDto { Amount = 110, Direction = "Debit", Status = "Completed", CounterpartyOrMerchant = "B" },
                new TransactionHistoryItemDto { Amount = 50, Direction = "Debit", Status = "Completed", CounterpartyOrMerchant = "C" },
                new TransactionHistoryItemDto { Amount = 32, Direction = "Debit", Status = "Completed", CounterpartyOrMerchant = "D" },
                new TransactionHistoryItemDto { Amount = 32, Direction = "Debit", Status = "Completed", CounterpartyOrMerchant = "D" },
                new TransactionHistoryItemDto { Amount = 102, Direction = "Debit", Status = "Failed", CounterpartyOrMerchant = "E" },
                new TransactionHistoryItemDto { Amount = 93, Direction = "Debit", Status = "Completed", CounterpartyOrMerchant = "E" },
                new TransactionHistoryItemDto { Amount = 120, Direction = "Debit", Status = "Completed", CounterpartyOrMerchant = "F" }
            });

            TopRecipientsResponse result = statisticsService.GetTopRecipients(userId);

            Assert.That(result.Recipients.Count, Is.EqualTo(5));
            Assert.That(result.Recipients[0].Name, Is.EqualTo("F"));
            Assert.That(result.Recipients[1].Name, Is.EqualTo("B"));
            Assert.That(result.Recipients[2].Name, Is.EqualTo("A"));
            Assert.That(result.Recipients[3].Name, Is.EqualTo("E"));
            Assert.That(result.Recipients[4].Name, Is.EqualTo("D"));
        }

        [Test]
        public void GetTopRecipients_IgnoresEmptyNames()
        {
            int userId = 1;
            mockTransactionHistoryRepository.GetTransactionsByUserId(userId).Returns(new List<TransactionHistoryItemDto>
            {
                new TransactionHistoryItemDto { Amount = 123, Direction = "Debit", Status = "Completed", CounterpartyOrMerchant = " " }
            });

            TopRecipientsResponse result = statisticsService.GetTopRecipients(userId);

            Assert.That(result.Recipients, Is.Empty);
        }

        [Test]
        public void GetTopRecipients_CountsTransactionsCorrectly()
        {
            int userId = 1;
            mockTransactionHistoryRepository.GetTransactionsByUserId(userId).Returns(new List<TransactionHistoryItemDto>
            {
                new TransactionHistoryItemDto { Amount = 74, Direction = "Debit", Status = "Completed", CounterpartyOrMerchant = "A" },
                new TransactionHistoryItemDto { Amount = 50, Direction = "Debit", Status = "Completed", CounterpartyOrMerchant = "A" }
            });

            TopRecipientsResponse result = statisticsService.GetTopRecipients(userId);

            Assert.That(result.Recipients[0].TransactionCount, Is.EqualTo(2));
            Assert.That(result.Recipients[0].TotalAmount, Is.EqualTo(124));
        }
    }
}
