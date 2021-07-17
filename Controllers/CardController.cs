using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASB.Models;

namespace ASB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {

        private readonly ILogger<CardsController> _logger;

        public CardsController(ILogger<CardsController> logger)
        {
            _logger = logger;
            Console.WriteLine("Card Controller");
        }

        [HttpGet]
        public ActionResult<List<Card>> GetAllCards()
        {
            throw new NotImplementedException();
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
