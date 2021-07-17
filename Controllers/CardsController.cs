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
        public ActionResult<IEnumerable<Card>> GetAllCards()
        {
            return Ok(_cardService.GetAllCards());
        }

        [HttpGet("{id}")]
        public ActionResult<Card> GetCardWithId(string id)
        {
            var result = _cardService.GetCardWithId(id);
            if (result == null)
            {
                return NotFound();
            } 
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Card>> CreateCard(Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _cardService.CreateCard(card);
            return Ok();
        }
    }
}
