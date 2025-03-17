using BankApp.Models.Entities;
using BankApp.Server.DataAccess.Interfaces;
using BankApp.Server.Repositories.Interfaces;

namespace BankApp.Server.Repositories.Implementations
{
    public class CardRepository : ICardRepository
    {
        private readonly ICardDAO _cardDao;
        private readonly IAccountDAO _accountDao;
        private readonly IUserCardPreferenceDAO _userCardPreferenceDao;
        public CardRepository(ICardDAO cardDao, IAccountDAO accountDao, IUserCardPreferenceDAO userCardPreferenceDao)
        {
            // TODO: implement card repository logic
            ;
        }

        public List<Card> GetCardsByUserId(int userId)
        {
            // TODO: load cards by user id
            return default !;
        }

        public Card? GetCardById(int cardId)
        {
            // TODO: load card by id
            return default !;
        }

        public Account? GetAccountById(int accountId)
        {
            // TODO: load account by id
            return default !;
        }

        public UserCardPreference? GetSortPreference(int userId)
        {
            // TODO: load sort preference
            return default !;
        }

        public bool SaveSortPreference(int userId, string sortOption)
        {
            // TODO: implement save sort preference logic
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
    }
}