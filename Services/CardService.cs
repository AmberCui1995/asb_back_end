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

        public IEnumerable<UserCard> GetAllUserCard()
        {
            var collection = _dataStore.GetCollection<UserCard>();
            return collection.AsQueryable();
        }

        public UserCard GetUserCardWithId(string id)
        {
            var collection = _dataStore.GetCollection<UserCard>();
            return collection
                    .AsQueryable()
                    .FirstOrDefault(p => p.ID == id);
        }
        public ValidCard GetValidCard(long cardNumber)
        {
            var collection = _dataStore.GetCollection<ValidCard>();
            return collection
                    .AsQueryable()
                    .FirstOrDefault(p => p.CardNumber == cardNumber);
        }

        public async Task CreateUserCard(UserCard card)
        {
            card.ID = Guid.NewGuid().ToString();
            var collection = _dataStore.GetCollection<UserCard>();
            await collection.InsertOneAsync(card);
        }
    }

}

