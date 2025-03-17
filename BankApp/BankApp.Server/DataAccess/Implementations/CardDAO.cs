using BankApp.Models.Entities;
using BankApp.Server.DataAccess.Interfaces;

namespace BankApp.Server.DataAccess.Implementations
{
    public class CardDAO : ICardDAO
    {
        private readonly AppDbContext _dbContext;
        public CardDAO(AppDbContext dbContext)
        {
            // TODO: implement card dao logic
            ;
        }

        public Card? FindById(int id)
        {
            // TODO: implement find by id logic
            return default !;
        }

        public List<Card> FindByUserId(int userId)
        {
            // TODO: implement find by user id logic
            return default !;
        }

        public bool UpdateStatus(int cardId, string status)
        {
            // TODO: implement update status logic
            return default !;
        }

        public bool UpdateSettings(int cardId, decimal? spendingLimit, bool isOnlinePaymentsEnabled, bool isContactlessPaymentsEnabled)
        {
            // TODO: implement update settings logic
            return default !;
        }

        private static Card MapToCard(System.Data.IDataReader reader)
        {
            // TODO: implement map to card logic
            return default !;
        }
    }
}