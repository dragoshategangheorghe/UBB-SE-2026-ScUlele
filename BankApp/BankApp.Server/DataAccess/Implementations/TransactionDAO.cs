using System.Data;
using BankApp.Models.DTOs.Transactions;
using BankApp.Models.Entities;
using BankApp.Server.DataAccess.Interfaces;

namespace BankApp.Server.DataAccess.Implementations
{
    public class TransactionDAO : ITransactionDAO
    {
        private readonly AppDbContext _dbContext;
        public TransactionDAO(AppDbContext dbContext)
        {
            // TODO: implement transaction dao logic
            ;
        }

        public List<Transaction> FindRecentByAccountId(int accountId, int limit = 10)
        {
            // TODO: implement find recent by account id logic
            return default !;
        }

        public List<TransactionHistoryItemDto> FindByUserId(int userId)
        {
            // TODO: implement find by user id logic
            return default !;
        }

        public TransactionHistoryItemDto? FindById(int userId, int transactionId)
        {
            // TODO: implement find by id logic
            return default !;
        }

        private static Transaction MapToTransaction(IDataReader reader)
        {
            // TODO: implement map to transaction logic
            return default !;
        }

        private static TransactionHistoryItemDto MapToTransactionHistoryItem(IDataReader reader)
        {
            // TODO: implement map to transaction history item logic
            return default !;
        }
    }
}