using BankApp.Models.DTOs.Transactions;
using BankApp.Models.Entities;
using BankApp.Server.Configuration;
using BankApp.Server.Repositories.Interfaces;
using BankApp.Server.Services.Implementations;
using BankApp.Server.Services.Interfaces;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace BankApp.Server.Tests;

public class TransactionAndStatisticsTests
{
    [Fact]
    public void GetHistory_FiltersAndSortsTransactions_BySearchStatusDirectionAndAmount()
    {
        Mock<ITransactionHistoryRepository> repositoryMock = new ();
        Mock<ITransactionExportService> exportServiceMock = new ();

        repositoryMock
            .Setup(repository => repository.GetTransactionsByUserId(10))
            .Returns(CreateTransactions());

        TransactionHistoryService service = new (repositoryMock.Object, exportServiceMock.Object);

        TransactionHistoryResponse response = service.GetHistory(10, new TransactionHistoryRequest
        {
            SearchTerm = "market",
            Status = "Completed",
            Direction = "Debit",
            SortField = TransactionSortFields.Amount,
            SortDirection = SortDirections.Asc
        });

        Assert.True(response.Success);
        Assert.Equal(2, response.Transactions.Count);
        Assert.Equal("REF-002", response.Transactions[0].ReferenceNumber);
        Assert.Equal("REF-001", response.Transactions[1].ReferenceNumber);
    }

    [Fact]
    public void GetSpendingByCategory_ComputesTotalsAndShares()
    {
        Mock<ITransactionHistoryRepository> repositoryMock = new ();

        repositoryMock
            .Setup(repository => repository.GetTransactionsByUserId(10))
            .Returns(CreateTransactions());

        StatisticsService service = new (repositoryMock.Object, Options.Create(new TeamCOptions()));

        var response = service.GetSpendingByCategory(10);

        Assert.True(response.Success);
        Assert.Equal(1, response.Categories.Count);
        Assert.Equal(50m, response.TotalSpending);
        Assert.Equal("Groceries", response.Categories[0].CategoryName);
        Assert.Equal(50m, response.Categories[0].Amount);
    }

    [Fact]
    public void GetIncomeVsExpenses_ComputesNetBalance()
    {
        Mock<ITransactionHistoryRepository> repositoryMock = new ();

        repositoryMock
            .Setup(repository => repository.GetTransactionsByUserId(10))
            .Returns(CreateTransactions());

        StatisticsService service = new (repositoryMock.Object, Options.Create(new TeamCOptions()));

        var response = service.GetIncomeVsExpenses(10);

        Assert.True(response.Success);
        Assert.Equal(100m, response.Income);
        Assert.Equal(50m, response.Expenses);
        Assert.Equal(50m, response.Net);
    }

    [Fact]
    public void GetFilterMetadata_ReturnsSortedDistinctOptions()
    {
        Mock<ITransactionHistoryRepository> repositoryMock = new ();
        Mock<ITransactionExportService> exportServiceMock = new ();

        repositoryMock
            .Setup(repository => repository.GetTransactionsByUserId(10))
            .Returns(CreateTransactions());
        repositoryMock
            .Setup(repository => repository.GetAccountsByUserId(10))
            .Returns(new List<Account>
            {
                new () { Id = 2, AccountName = "Savings", IBAN = "RO49AAAA1B31007593840000" },
                new () { Id = 1, AccountName = "Everyday", IBAN = "RO49AAAA1B31007593840001" }
            });
        repositoryMock
            .Setup(repository => repository.GetCardsByUserId(10))
            .Returns(new List<Card>
            {
                new () { Id = 8, CardBrand = "Visa", CardType = "Debit", CardNumber = "4111111111111111" },
                new () { Id = 7, CardBrand = "Mastercard", CardType = "Debit", CardNumber = "5555444433331111" }
            });

        TransactionHistoryService service = new (repositoryMock.Object, exportServiceMock.Object);

        TransactionFilterMetadataResponse response = service.GetFilterMetadata(10);

        Assert.True(response.Success);
        Assert.Equal(new[] { "Everyday", "Savings" }, response.Accounts.Select(account => account.Name).ToArray());
        Assert.Equal(new[] { "Completed", "Reversed" }, response.AvailableStatuses.ToArray());
        Assert.Equal(new[] { "Credit", "Debit" }, response.AvailableDirections.ToArray());
        Assert.Contains(response.Cards, card => card.Label == "Mastercard **** 1111");
        Assert.Contains(response.Cards, card => card.Label == "Visa **** 1111");
    }

    [Fact]
    public void GetBalanceTrends_ReturnsLatestDailyBalance_ForConfiguredWindow()
    {
        Mock<ITransactionHistoryRepository> repositoryMock = new ();

        repositoryMock
            .Setup(repository => repository.GetTransactionsByUserId(10))
            .Returns(CreateTransactionsForBalanceTrends());

        StatisticsService service = new (
            repositoryMock.Object,
            Options.Create(new TeamCOptions
            {
                BalanceTrendDays = 7
            }));

        var response = service.GetBalanceTrends(10);

        Assert.True(response.Success);
        Assert.Equal(2, response.Points.Count);
        Assert.Equal(new DateTime(2026, 3, 24), response.Points[0].Date);
        Assert.Equal(700m, response.Points[0].Balance);
        Assert.Equal(new DateTime(2026, 3, 25), response.Points[1].Date);
        Assert.Equal(650m, response.Points[1].Balance);
    }

    [Fact]
    public void GetTopRecipients_ExcludesFailedAndReversedTransactions_AndLimitsResultCount()
    {
        Mock<ITransactionHistoryRepository> repositoryMock = new ();

        repositoryMock
            .Setup(repository => repository.GetTransactionsByUserId(10))
            .Returns(CreateTransactionsForTopRecipients());

        StatisticsService service = new (
            repositoryMock.Object,
            Options.Create(new TeamCOptions
            {
                TopRecipientsCount = 2
            }));

        var response = service.GetTopRecipients(10);

        Assert.True(response.Success);
        Assert.Equal(2, response.Recipients.Count);
        Assert.Equal("Rent", response.Recipients[0].Name);
        Assert.Equal(500m, response.Recipients[0].TotalAmount);
        Assert.Equal("Grocer", response.Recipients[1].Name);
        Assert.Equal(150m, response.Recipients[1].TotalAmount);
        Assert.DoesNotContain(response.Recipients, recipient => recipient.Name == "Rejected Merchant");
        Assert.DoesNotContain(response.Recipients, recipient => recipient.Name == "Refunded Shop");
    }

    private static List<TransactionHistoryItemDto> CreateTransactions()
    {
        return new List<TransactionHistoryItemDto>
        {
            new ()
            {
                Id = 1,
                AccountId = 1,
                ReferenceNumber = "REF-001",
                Timestamp = new DateTime(2026, 3, 20, 10, 0, 0),
                TransactionType = "CardPayment",
                CounterpartyOrMerchant = "Central Market",
                Amount = 35m,
                Currency = "EUR",
                Direction = "Debit",
                RunningBalanceAfterTransaction = 465m,
                Status = "Completed",
                CategoryName = "Groceries"
            },
            new ()
            {
                Id = 2,
                AccountId = 1,
                ReferenceNumber = "REF-002",
                Timestamp = new DateTime(2026, 3, 19, 12, 0, 0),
                TransactionType = "CardPayment",
                CounterpartyOrMerchant = "Weekend Market",
                Amount = 15m,
                Currency = "EUR",
                Direction = "Debit",
                RunningBalanceAfterTransaction = 500m,
                Status = "Completed",
                CategoryName = "Groceries"
            },
            new ()
            {
                Id = 3,
                AccountId = 1,
                ReferenceNumber = "REF-003",
                Timestamp = new DateTime(2026, 3, 18, 8, 0, 0),
                TransactionType = "Salary",
                CounterpartyOrMerchant = "Employer Inc",
                Amount = 100m,
                Currency = "EUR",
                Direction = "Credit",
                RunningBalanceAfterTransaction = 515m,
                Status = "Completed",
                CategoryName = "Income"
            },
            new ()
            {
                Id = 4,
                AccountId = 1,
                ReferenceNumber = "REF-004",
                Timestamp = new DateTime(2026, 3, 17, 8, 0, 0),
                TransactionType = "Transfer",
                CounterpartyOrMerchant = "Refunded Merchant",
                Amount = 25m,
                Currency = "EUR",
                Direction = "Debit",
                RunningBalanceAfterTransaction = 415m,
                Status = "Reversed",
                CategoryName = "Shopping"
            }
        };
    }

    private static List<TransactionHistoryItemDto> CreateTransactionsForBalanceTrends()
    {
        return new List<TransactionHistoryItemDto>
        {
            new ()
            {
                Id = 10,
                Timestamp = new DateTime(2026, 3, 24, 9, 0, 0, DateTimeKind.Utc),
                RunningBalanceAfterTransaction = 680m,
                Direction = "Credit",
                Status = "Completed",
                CounterpartyOrMerchant = "Employer",
                TransactionType = "Salary",
                ReferenceNumber = "BAL-001",
                Currency = "EUR"
            },
            new ()
            {
                Id = 11,
                Timestamp = new DateTime(2026, 3, 24, 18, 30, 0, DateTimeKind.Utc),
                RunningBalanceAfterTransaction = 700m,
                Direction = "Debit",
                Status = "Completed",
                CounterpartyOrMerchant = "Store",
                TransactionType = "CardPayment",
                ReferenceNumber = "BAL-002",
                Currency = "EUR"
            },
            new ()
            {
                Id = 12,
                Timestamp = new DateTime(2026, 3, 25, 12, 0, 0, DateTimeKind.Utc),
                RunningBalanceAfterTransaction = 650m,
                Direction = "Debit",
                Status = "Completed",
                CounterpartyOrMerchant = "Utilities",
                TransactionType = "Transfer",
                ReferenceNumber = "BAL-003",
                Currency = "EUR"
            }
        };
    }

    private static List<TransactionHistoryItemDto> CreateTransactionsForTopRecipients()
    {
        return new List<TransactionHistoryItemDto>
        {
            new ()
            {
                Id = 20,
                Timestamp = new DateTime(2026, 3, 20, 10, 0, 0),
                CounterpartyOrMerchant = "Rent",
                Amount = 500m,
                Direction = "Debit",
                Status = "Completed",
                TransactionType = "Transfer",
                ReferenceNumber = "TOP-001",
                Currency = "EUR"
            },
            new ()
            {
                Id = 21,
                Timestamp = new DateTime(2026, 3, 21, 10, 0, 0),
                CounterpartyOrMerchant = "Grocer",
                Amount = 150m,
                Direction = "Debit",
                Status = "Completed",
                TransactionType = "CardPayment",
                ReferenceNumber = "TOP-002",
                Currency = "EUR"
            },
            new ()
            {
                Id = 22,
                Timestamp = new DateTime(2026, 3, 22, 10, 0, 0),
                CounterpartyOrMerchant = "Rejected Merchant",
                Amount = 300m,
                Direction = "Debit",
                Status = "Failed",
                TransactionType = "CardPayment",
                ReferenceNumber = "TOP-003",
                Currency = "EUR"
            },
            new ()
            {
                Id = 23,
                Timestamp = new DateTime(2026, 3, 23, 10, 0, 0),
                CounterpartyOrMerchant = "Refunded Shop",
                Amount = 220m,
                Direction = "Debit",
                Status = "Reversed",
                TransactionType = "CardPayment",
                ReferenceNumber = "TOP-004",
                Currency = "EUR"
            },
            new ()
            {
                Id = 24,
                Timestamp = new DateTime(2026, 3, 24, 10, 0, 0),
                CounterpartyOrMerchant = "Savings",
                Amount = 50m,
                Direction = "Credit",
                Status = "Completed",
                TransactionType = "Transfer",
                ReferenceNumber = "TOP-005",
                Currency = "EUR"
            }
        };
    }
}
