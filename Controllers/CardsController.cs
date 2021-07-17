using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASB.Models;
using ASB.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ASB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {

        private readonly ILogger<CardsController> _logger;
        private readonly ICardService _cardService;

        public CardsController(ILogger<CardsController> logger, ICardService cardService)
        {
            _logger = logger;
            _cardService = cardService;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<UserCard>> GetAllCards()
        {
            return Ok(_cardService.GetAllUserCard());
        }

        [HttpGet("{id}")]
        public ActionResult<UserCard> GetCardWithId(string id)
        {
            var result = _cardService.GetUserCardWithId(id);
            if (result == null)
            {
                return NotFound();
            } 
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserCard>> CreateCard(UserCard card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var validCard = _cardService.GetValidCard(card.CardNumber);
            if (validCard == null)
            {
                return BadRequest();
            }

            await _cardService.CreateUserCard(card);
            return Ok();
        }
    }
}
