using ASB;
using ASB.Models;
using ASB.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Text;

namespace ASBIntegrationTests
{


    [TestClass]
    public class APITests
    {
        private static WebApplicationFactory<Startup> _factory;

        [TestClass]
        public class StudentsControllerTests
        {
            private static TestContext _testContext;
            private static WebApplicationFactory<Startup> _factory;

            [ClassInitialize]
            public static void ClassInit(TestContext testContext)
            {
                _testContext = testContext;
                _factory = new WebApplicationFactory<Startup>();

            }

            [TestMethod]
            public async Task TestGetAllUserCards()
            {
                var client = _factory.CreateClient();
                var response = await client.GetAsync("/Cards");
                var responseResult = await response.Content.ReadAsStringAsync();
                var result = responseResult.Replace(System.Environment.NewLine, string.Empty).Replace(" ", string.Empty);

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
                Assert.AreEqual(LoadDBUserCard(), result);
            }

            [TestMethod]
            public async Task TestGetUserCardWithID_returnOk()
            {
                var client = _factory.CreateClient();
                var cardId = "e7ba18b9-9e7e-4243-8172-78e97ea62b4d";
                var response = await client.GetAsync($"/Cards/{HttpUtility.UrlEncode(cardId)}");

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());            
            }

            [TestMethod]
            public async Task TestGetUserCardWithID_returnNotFound()
            {
                var client = _factory.CreateClient();
                var cardId = "wrongid";
                var response = await client.GetAsync($"/Cards/{HttpUtility.UrlEncode(cardId)}");

                Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            }

            [TestMethod]
            public async Task TestPostUserCard_InvalidCardName_BadRequest()
            {
                var client = _factory.CreateClient();
                var card = new UserCard {  Name ="sd*(&* ", CardNumber= 7808690766884117, CVC =2};
                var json = JsonConvert.SerializeObject(card);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"/Cards", data);

                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }

            [TestMethod]
            public async Task TestPostUserCard_InvalidCardNumber_BadRequest()
            {
                var client = _factory.CreateClient();
                var card = new UserCard { Name = "sd", CardNumber = 8690766884117, CVC = 2 };
                var json = JsonConvert.SerializeObject(card);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"/Cards", data);

                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }

            [TestMethod]
            public async Task TestPostUserCard_validCardName()
            {
                var client = _factory.CreateClient();
                var card = new UserCard { Name = "sd", CardNumber = 7808690766884117, CVC = 2 };
                var json = JsonConvert.SerializeObject(card);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"/Cards", data);

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }



    public static string LoadDBUserCard()
        {
            using (StreamReader r = new StreamReader("data.json"))
            {
                var json = r.ReadToEnd();
                var dbData = (JObject)JsonConvert.DeserializeObject(json);
                var usercards = dbData.Children().First().First().ToString();
                return usercards.Replace(System.Environment.NewLine, string.Empty).Replace(" ", string.Empty);
            }
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }

}

