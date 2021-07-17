using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASB.Models;
using ASB.Services;

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

        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetAllCards()
        {
            return Ok(_cardService.GetAllCards().ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Card> GetCardWithId(int id)
        {
            throw new NotImplementedException();
            
        }

        [HttpPost]
        public IActionResult CreateCard(Card card)
        {
            throw new NotImplementedException();
        }
    }
}
