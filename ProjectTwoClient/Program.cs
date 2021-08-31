using Newtonsoft.Json;
using ProjectTwoClient.Models;
using System;
using System.Collections.Generic;
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

            var result = client.GetAsync("user").Result;
            var json = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine(json);

            var list = JsonConvert.DeserializeObject<List<User>>(json);
            Console.ReadLine();
        }
    }
}