using System.Data;
using BankApp.Models.Entities;
using BankApp.Server.DataAccess.Interfaces;

namespace BankApp.Server.DataAccess.Implementations
{
    public class PasswordResetTokenDAO : IPasswordResetTokenDAO
    {
        private readonly AppDbContext _context;
        public PasswordResetTokenDAO(AppDbContext context)
        {
            // TODO: implement authentication logic
            ;
        }

        public PasswordResetToken Create(int userId, string tokenHash, DateTime expiresAt)
        {
            // TODO: implement create logic
            return default !;
        }

        public void DeleteExpired()
        {
            // TODO: implement delete expired logic
            ;
        }

        public PasswordResetToken? FindByToken(string tokenHash)
        {
            // TODO: implement find by token logic
            return default !;
        }

        public void MarkAsUsed(int tokenId)
        {
            // TODO: implement mark as used logic
            ;
        }

        private PasswordResetToken MapToPRT(IDataReader reader)
        {
            // TODO: implement map to prt logic
            return default !;
        }
    }
}