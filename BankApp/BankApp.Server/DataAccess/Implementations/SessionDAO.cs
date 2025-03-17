using BankApp.Models.Entities;
using BankApp.Server.DataAccess.Interfaces;

namespace BankApp.Server.DataAccess
{
    public class SessionDAO : ISessionDAO
    {
        private readonly AppDbContext _db;
        public SessionDAO(AppDbContext db)
        {
            // TODO: implement session dao logic
            ;
        }

        public Session Create(int userId, string token, string? deviceInfo, string? browser, string? ip)
        {
            // TODO: implement create logic
            return default !;
        }

        public Session? FindByToken(string token)
        {
            // TODO: implement find by token logic
            return default !;
        }

        public List<Session> FindByUserId(int userId)
        {
            // TODO: implement find by user id logic
            return default !;
        }

        public void Revoke(int sessionId)
        {
            // TODO: implement revoke logic
            ;
        }

        public void RevokeAll(int userId)
        {
            // TODO: implement revoke all logic
            ;
        }

        private Session MapSession(System.Data.IDataReader r)
        {
            // TODO: implement map session logic
            return default !;
        }
    }
}