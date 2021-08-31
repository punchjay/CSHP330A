using Newtonsoft.Json;
using ProjectTwoClient.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace ProjectTwoClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9628/api/")
            };

            var newUser = new User
            {
                Email = "new-client@uw.org",
                Password = "clientPassword",
            };

            var newJson = JsonConvert.SerializeObject(newUser);
            var postContent = new StringContent(newJson, System.Text.Encoding.UTF8, "application/json");
            var postResult = client.PostAsync("user", postContent).Result;
            if (postResult.StatusCode == HttpStatusCode.Created)
            {
                Console.WriteLine(postResult.StatusCode);
            }
            else
            {
                Console.WriteLine($"{postResult.StatusCode} - PostAsync Failure.");
            }

            var result = client.GetAsync("user").Result;
            var json = result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(json);
            Console.WriteLine();

            var list = JsonConvert.DeserializeObject<List<User>>(json);
            var idToDelete = list[0].Id;
            var deleteResult = client.DeleteAsync("contacts/" + idToDelete).Result;
            if (deleteResult.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine($"{deleteResult.StatusCode} - User '{idToDelete}' Deleted");
            }
            else
            {
                Console.WriteLine($"{deleteResult.StatusCode} - DeleteAsync Failure.");
            }

            Console.ReadLine();
        }
    }
}