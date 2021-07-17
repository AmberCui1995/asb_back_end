using System;
using System.Collections.Generic;
using ASB.Models;

namespace ASB.Services 
{
  public interface ICardService
  {
      IEnumerable<Card> GetAllCards();
  }
}
