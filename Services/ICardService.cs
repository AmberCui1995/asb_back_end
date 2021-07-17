using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASB.Services
{
    public interface ICardService
    {
        IEnumerable<Card> GetAllCards();
        Card GetCardWithId(string id);
        Task CreateCard(Card card);
    }
}
