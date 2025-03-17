using System.Threading.Tasks;
using BankApp.Client.Services.Interfaces;
using BankApp.Client.Utilities;
using BankApp.Models.DTOs.Cards;

namespace BankApp.Client.Services.Implementations
{
    public class CardApiService : ICardApiService
    {
        private readonly ApiService _apiService;
        public CardApiService(ApiService apiService)
        {
            // TODO: implement card api service logic
            ;
        }

        public Task<GetCardsResponse?> GetCardsAsync()
        {
            // TODO: load cards
            return default !;
        }

        public Task<CardDetailsResponse?> GetCardAsync(int cardId)
        {
            // TODO: load card
            return default !;
        }

        public Task<RevealCardResponse?> RevealCardAsync(int cardId, RevealCardRequest request)
        {
            // TODO: implement reveal card logic
            return default !;
        }

        public Task<CardCommandResponse?> FreezeCardAsync(int cardId)
        {
            // TODO: implement freeze card logic
            return default !;
        }

        public Task<CardCommandResponse?> UnfreezeCardAsync(int cardId)
        {
            // TODO: implement unfreeze card logic
            return default !;
        }

        public Task<CardCommandResponse?> UpdateSettingsAsync(int cardId, UpdateCardSettingsRequest request)
        {
            // TODO: implement update settings logic
            return default !;
        }

        public Task<CardCommandResponse?> UpdateSortPreferenceAsync(UpdateCardSortPreferenceRequest request)
        {
            // TODO: implement update sort preference logic
            return default !;
        }
    }
}