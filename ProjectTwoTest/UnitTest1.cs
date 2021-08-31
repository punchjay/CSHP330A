using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ProjectTwoTest
{
    public class User
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("DateCreated")]
        public DateTime DateCreated { get; set; }
    }

    public class Tests
    {
        private HttpClient client;

        // Called before every Test
        [SetUp]
        public void Setup()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9628/api/")
            };
        }

        [Test]
        public void AddNewContact()
        {
            var newUser = new User
            {
                Email = "new-client@uw.org",
                Password = "clientPassword",
            };

            var newJson = JsonConvert.SerializeObject(newUser);

            var postContent = new StringContent(newJson, Encoding.UTF8, "application/json");

            var postResult = client.PostAsync("user", postContent).Result;

            Assert.AreEqual(HttpStatusCode.Created, postResult.StatusCode);
        }
    }
}