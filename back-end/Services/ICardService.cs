using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASB.Services
{
    public interface ICardService
    {
        IEnumerable<UserCard> GetAllUserCard();
        UserCard GetUserCardWithId(string id);
        ValidCard GetValidCard(long cardNumber);
        Task CreateUserCard(UserCard card);
    }
}
