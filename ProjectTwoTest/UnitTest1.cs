using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using ProjectTwoTest.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ProjectTwoTest
{
    public class UserTests
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
        public void GetAllUsers()
        {
            var result = client.GetAsync("user").Result;
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void AddNewUser()
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