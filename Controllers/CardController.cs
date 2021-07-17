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
    public class CardController : ControllerBase
    {

        private readonly ILogger<CardController> _logger;

        public CardController(ILogger<CardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Card>> GetAll() => new List<Card>();
    }
}
