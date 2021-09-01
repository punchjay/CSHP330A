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
        private Guid guidId = Guid.NewGuid();

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
        public void AddNewUser()
        {
            var postResult = CreateUser("AddNewUser@uw.org", "AddNewUser");
            postResult.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void DeleteUserById_BadRequest()
        {
            var result = client.DeleteAsync("user/BadGuid").Result;
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public void DeleteUserById_NotFound()
        {
            var result = client.DeleteAsync($"user/{guidId}").Result;
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Test]
        public void DeleteUserById_OK()
        {
            var postResult = CreateUser("DeleteUserById_OK@uw.org", "DeleteUserById_OK");
            var json = postResult.Content.ReadAsStringAsync().Result;
            var user = JsonConvert.DeserializeObject<User>(json);
            var result = client.DeleteAsync("user/" + user.Id).Result;

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void GetAllUsers()
        {
            var result = client.GetAsync("user").Result;

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void GetUserById_BadRequest()
        {
            var result = client.GetAsync("user/BadGuid").Result;

            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public void GetUserById_NoContent()
        {
            var result = client.GetAsync($"user/{guidId}").Result;

            result.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Test]
        public void GetUserById_OK()
        {
            var postResult = CreateUser("GetUserById_OK@uw.org", "GetUserById_OK");
            var json = postResult.Content.ReadAsStringAsync().Result;
            var user = JsonConvert.DeserializeObject<User>(json);
            var result = client.GetAsync("user/" + user.Id).Result;

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void PutUserById_OK()
        {
            var postResult = CreateUser("AddNewUser@uw.org", "AddNewUser");
            var json = postResult.Content.ReadAsStringAsync().Result;
            var user = JsonConvert.DeserializeObject<User>(json);

            var updateUser = new User
            {
                Email = "PutUserById_OK@uw.org",
                Password = "PutUserById_OK",
            };

            var updateJson = JsonConvert.SerializeObject(updateUser);
            var postContent = new StringContent(updateJson, Encoding.UTF8, "application/json");
            var result = client.PutAsync("user/" + user.Id, postContent).Result;

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}