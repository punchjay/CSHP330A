using Newtonsoft.Json;
using System;

namespace ProjectTwoTest.Models
{
    internal class User
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
}