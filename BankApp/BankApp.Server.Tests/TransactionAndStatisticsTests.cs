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
        // TODO: load history_filters and sorts transactions_by search status direction and amount
        ;
    }

    [Fact]
    public void GetSpendingByCategory_ComputesTotalsAndShares()
    {
        // TODO: load spending by category_computes totals and shares
        ;
    }

    [Fact]
    public void GetIncomeVsExpenses_ComputesNetBalance()
    {
        // TODO: load income vs expenses_computes net balance
        ;
    }

    [Fact]
    public void GetFilterMetadata_ReturnsSortedDistinctOptions()
    {
        // TODO: load filter metadata_returns sorted distinct options
        ;
    }

    [Fact]
    public void GetBalanceTrends_ReturnsLatestDailyBalance_ForConfiguredWindow()
    {
        // TODO: load balance trends_returns latest daily balance_for configured window
        ;
    }

    [Fact]
    public void GetTopRecipients_ExcludesFailedAndReversedTransactions_AndLimitsResultCount()
    {
        // TODO: load top recipients_excludes failed and reversed transactions_and limits result count
        ;
    }

    private static List<TransactionHistoryItemDto> CreateTransactions()
    {
        // TODO: implement create transactions logic
        return default !;
    }

    private static List<TransactionHistoryItemDto> CreateTransactionsForBalanceTrends()
    {
        // TODO: implement create transactions for balance trends logic
        return default !;
    }

    private static List<TransactionHistoryItemDto> CreateTransactionsForTopRecipients()
    {
        // TODO: implement create transactions for top recipients logic
        return default !;
    }
}