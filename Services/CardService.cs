using ASB.Models;
using JsonFlatFileDataStore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ASB.Services

{

    public class CardService : ICardService 
    {
        private readonly IDataStore _dataStore;

        public CardService( IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public IEnumerable<Card> GetAllCards()
        {
            var collection = _dataStore.GetCollection<Card>();
            return collection.AsQueryable();
        }

        public Card GetCardWithId(string id)
        {
            var collection = _dataStore.GetCollection<Card>();
            return collection
                    .AsQueryable()
                    .FirstOrDefault(p => p.ID == id);
        }

        public async Task CreateCard(Card card)
        {
            card.ID = Guid.NewGuid().ToString();
            var collection = _dataStore.GetCollection<Card>();
            await collection.InsertOneAsync(card);
        }
    }

}

