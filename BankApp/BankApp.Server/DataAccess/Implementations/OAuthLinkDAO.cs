using BankApp.Models.Entities;
using BankApp.Server.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BankApp.Server.DataAccess.Implementations
{
    public class OAuthLinkDAO : IOAuthLinkDAO
    {
        private readonly AppDbContext _context;
        public OAuthLinkDAO(AppDbContext context)
        {
            // TODO: implement authentication logic
            ;
        }

        public bool Create(int userId, string provider, string providerUserId, string? providerEmail)
        {
            // TODO: implement create logic
            return default !;
        }

        public void Delete(int id)
        {
            // TODO: implement delete logic
            ;
        }

        public OAuthLink? FindByProvider(string provider, string providerUserId)
        {
            // TODO: implement find by provider logic
            return default !;
        }

        public List<OAuthLink> FindByUserId(int userId)
        {
            // TODO: implement find by user id logic
            return default !;
        }

        private OAuthLink MapToOAuthLink(IDataReader reader)
        {
            // TODO: implement authentication logic
            return default !;
        }
    }
}