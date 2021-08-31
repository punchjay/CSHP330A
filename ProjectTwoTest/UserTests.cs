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

        private HttpResponseMessage CreateUser(string email, string password)
        {
            var newUser = new User
            {
                Email = email,
                Password = password,
            };

            var newJson = JsonConvert.SerializeObject(newUser);
            var postContent = new StringContent(newJson, Encoding.UTF8, "application/json");
            var postResult = client.PostAsync("user", postContent).Result;

            return postResult;
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
            var postResult = CreateUser("new-client@uw.org", "clientPassword");
            //Assert.AreEqual(HttpStatusCode.Created, postResult.StatusCode);
            postResult.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void DeleteUserById_Valid()
        {
            var postResult = CreateUser("new-client@uw.org", "clientPassword");
            var json = postResult.Content.ReadAsStringAsync().Result;
            var user = JsonConvert.DeserializeObject<User>(json);
            var result = client.DeleteAsync("user/" + user.Id).Result;
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        //[Test]
        //public void TestDelete_InvalidContactStringId()
        //{
        //    var result = client.DeleteAsync("contacts/abc").Result;

        //    result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        //}

        //[Test]
        //public void TestDelete_InvalidContactId()
        //{
        //    var result = client.DeleteAsync("contacts/1").Result;

        //    result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        //}

        //[Test]
        //public void TestGetSpecific_Good()
        //{
        //    var postResult = CreateContact("TestGetSpecific_Good");

        //    var json = postResult.Content.ReadAsStringAsync().Result;

        //    var contact = JsonConvert.DeserializeObject<Contact>(json);

        //    var result = client.GetAsync("contacts/" + contact.Id).Result;

        //    result.StatusCode.Should().Be(HttpStatusCode.OK);
        //}

        //[Test]
        //public void TestGetSpecific_Bad()
        //{
        //    var result = client.GetAsync("contacts/10211").Result;

        //    result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        //}
    }
}