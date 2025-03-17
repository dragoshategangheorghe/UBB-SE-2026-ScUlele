using BankApp.Models.Entities;
using BankApp.Server.Repositories.Interfaces;
using BankApp.Server.DataAccess.Interfaces;

namespace BankApp.Server.Repositories.Implementations
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IAccountDAO _accountDAO;
        private readonly ICardDAO _cardDAO;
        private readonly ITransactionDAO _transactionDAO;
        private readonly INotificationDAO _notificationDAO;
        public DashboardRepository(IAccountDAO accountDAO, ICardDAO cardDAO, ITransactionDAO transactionDAO, INotificationDAO notificationDAO)
        {
            // TODO: implement dashboard repository logic
            ;
        }

        public List<Account> GetAccountsByUser(int userId)
        {
            // TODO: load accounts by user
            return default !;
        }

        public List<Card> GetCardsByUser(int userId)
        {
            // TODO: load cards by user
            return default !;
        }

        public List<Transaction> GetRecentTransactions(int accountId, int limit = 10)
        {
            // TODO: load recent transactions
            return default !;
        }

        public int GetUnreadNotificationCount(int userId)
        {
            // TODO: load unread notification count
            return default !;
        }
    }
}