using BankApp.Models.DTOs.Statistics;
using BankApp.Models.DTOs.Transactions;
using BankApp.Server.Configuration;
using BankApp.Server.Repositories.Interfaces;
using BankApp.Server.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace BankApp.Server.Services.Implementations
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ITransactionHistoryRepository _transactionHistoryRepository;
        private readonly TeamCOptions _options;
        public StatisticsService(ITransactionHistoryRepository transactionHistoryRepository, IOptions<TeamCOptions> options)
        {
            // TODO: implement statistics service logic
            ;
        }

        public SpendingByCategoryResponse GetSpendingByCategory(int userId)
        {
            // TODO: load spending by category
            return default !;
        }

        public IncomeVsExpensesResponse GetIncomeVsExpenses(int userId)
        {
            // TODO: load income vs expenses
            return default !;
        }

        public BalanceTrendsResponse GetBalanceTrends(int userId)
        {
            // TODO: load balance trends
            return default !;
        }

        public TopRecipientsResponse GetTopRecipients(int userId)
        {
            // TODO: load top recipients
            return default !;
        }

        private List<TransactionHistoryItemDto> GetAnalyticsTransactions(int userId)
        {
            // TODO: load analytics transactions
            return default !;
        }

        private static bool IsDebit(string? direction)
        {
            // TODO: implement is debit logic
            return default !;
        }

        private static bool IsCredit(string? direction)
        {
            // TODO: implement is credit logic
            return default !;
        }

        private static bool IsFailed(string? status)
        {
            // TODO: implement is failed logic
            return default !;
        }
    }
}