using System.Threading.Tasks;
using BankApp.Client.Services.Interfaces;
using BankApp.Client.Utilities;
using BankApp.Models.DTOs.Statistics;

namespace BankApp.Client.Services.Implementations
{
    public class StatisticsApiService : IStatisticsApiService
    {
        private readonly ApiService _apiService;
        public StatisticsApiService(ApiService apiService)
        {
            // TODO: implement statistics api service logic
            ;
        }

        public Task<SpendingByCategoryResponse?> GetSpendingByCategoryAsync()
        {
            // TODO: load spending by category
            return default !;
        }

        public Task<IncomeVsExpensesResponse?> GetIncomeVsExpensesAsync()
        {
            // TODO: load income vs expenses
            return default !;
        }

        public Task<BalanceTrendsResponse?> GetBalanceTrendsAsync()
        {
            // TODO: load balance trends
            return default !;
        }

        public Task<TopRecipientsResponse?> GetTopRecipientsAsync()
        {
            // TODO: load top recipients
            return default !;
        }
    }
}