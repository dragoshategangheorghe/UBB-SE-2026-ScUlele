using System.Data;
using BankApp.Models.Entities;
using BankApp.Server.DataAccess.Interfaces;

namespace BankApp.Server.DataAccess.Implementations
{
    public class UserCardPreferenceDAO : IUserCardPreferenceDAO
    {
        private readonly AppDbContext _dbContext;
        public UserCardPreferenceDAO(AppDbContext dbContext)
        {
            // TODO: implement user card preference dao logic
            ;
        }

        public UserCardPreference? FindByUserId(int userId)
        {
            // TODO: implement find by user id logic
            return default !;
        }

        public bool Upsert(int userId, string sortOption)
        {
            // TODO: implement upsert logic
            return default !;
        }

        private static UserCardPreference MapPreference(IDataReader reader)
        {
            // TODO: implement map preference logic
            return default !;
        }
    }
}