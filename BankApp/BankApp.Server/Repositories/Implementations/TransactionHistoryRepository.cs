using BankApp.Models.DTOs.Transactions;
using BankApp.Models.Entities;
using BankApp.Server.DataAccess.Interfaces;
using BankApp.Server.Repositories.Interfaces;

namespace BankApp.Server.Repositories.Implementations
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        private readonly ITransactionDAO _transactionDao;
        private readonly IAccountDAO _accountDao;
        private readonly ICardDAO _cardDao;
        public TransactionHistoryRepository(ITransactionDAO transactionDao, IAccountDAO accountDao, ICardDAO cardDao)
        {
            // TODO: implement transaction history repository logic
            ;
        }

        public List<TransactionHistoryItemDto> GetTransactionsByUserId(int userId)
        {
            // TODO: load transactions by user id
            return default !;
        }

        public TransactionHistoryItemDto? GetTransactionById(int userId, int transactionId)
        {
            // TODO: load transaction by id
            return default !;
        }

        public List<Account> GetAccountsByUserId(int userId)
        {
            // TODO: load accounts by user id
            return default !;
        }

        public List<Card> GetCardsByUserId(int userId)
        {
            // TODO: load cards by user id
            return default !;
        }
    }
}