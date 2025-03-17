using BankApp.Models.Entities;
using BankApp.Server.DataAccess.Interfaces;
using System.Data;

namespace BankApp.Server.DataAccess.Implementations
{
    public class AccountDAO : IAccountDAO
    {
        private readonly AppDbContext _dbContext;
        public AccountDAO(AppDbContext dbContext)
        {
            // TODO: implement account dao logic
            ;
        }

        public Account? FindById(int id)
        {
            // TODO: implement find by id logic
            return default !;
        }

        public List<Account> FindByUserId(int userId)
        {
            // TODO: implement find by user id logic
            return default !;
        }

        private Account MapToAccount(IDataReader r)
        {
            // TODO: implement map to account logic
            return default !;
        }
    }
}