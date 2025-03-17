using BankApp.Models.Entities;
using BankApp.Server.DataAccess.Interfaces;

namespace BankApp.Server.DataAccess.Implementations
{
    public class UserDAO : IUserDAO
    {
        private readonly AppDbContext _db;
        public UserDAO(AppDbContext db)
        {
            // TODO: implement user dao logic
            ;
        }

        public User? FindByEmail(string email)
        {
            // TODO: implement find by email logic
            return default !;
        }

        public User? FindById(int id)
        {
            // TODO: implement find by id logic
            return default !;
        }

        public bool Create(User user)
        {
            // TODO: implement create logic
            return default !;
        }

        public bool Update(User user)
        {
            // TODO: implement update logic
            return default !;
        }

        public bool UpdatePassword(int userId, string newPasswordHash)
        {
            // TODO: implement update password logic
            return default !;
        }

        public void IncrementFailedAttempts(int userId)
        {
            // TODO: implement increment failed attempts logic
            ;
        }

        public void ResetFailedAttempts(int userId)
        {
            // TODO: implement reset failed attempts logic
            ;
        }

        public void LockAccount(int userId, DateTime lockoutEnd)
        {
            // TODO: implement lock account logic
            ;
        }

        private User MapUser(System.Data.IDataReader r)
        {
            // TODO: implement map user logic
            return default !;
        }
    }
}