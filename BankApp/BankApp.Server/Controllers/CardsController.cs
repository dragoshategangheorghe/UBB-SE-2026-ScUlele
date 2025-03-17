using BankApp.Models.DTOs.Cards;
using BankApp.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardsController(ICardService cardService)
        {
            // TODO: implement cards controller logic
            ;
        }

        private int GetAuthenticatedUserId()
        {
            // TODO: load authenticated user id
            return default !;
        }

        [HttpGet]
        public IActionResult GetCards()
        {
            // TODO: load cards
            return default !;
        }

        [HttpGet("{cardId:int}")]
        public IActionResult GetCard(int cardId)
        {
            // TODO: load card
            return default !;
        }

        [HttpPost("{cardId:int}/reveal")]
        public IActionResult RevealCard(int cardId, [FromBody] RevealCardRequest request)
        {
            // TODO: implement reveal card logic
            return default !;
        }

        [HttpPut("{cardId:int}/freeze")]
        public IActionResult FreezeCard(int cardId)
        {
            // TODO: implement freeze card logic
            return default !;
        }

        [HttpPut("{cardId:int}/unfreeze")]
        public IActionResult UnfreezeCard(int cardId)
        {
            // TODO: implement unfreeze card logic
            return default !;
        }

        [HttpPut("{cardId:int}/settings")]
        public IActionResult UpdateSettings(int cardId, [FromBody] UpdateCardSettingsRequest request)
        {
            // TODO: implement update settings logic
            return default !;
        }

        [HttpPut("preferences/sort")]
        public IActionResult UpdateSortPreference([FromBody] UpdateCardSortPreferenceRequest request)
        {
            // TODO: implement update sort preference logic
            return default !;
        }
    }
}