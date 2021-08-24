using Newtonsoft.Json;
using System;

namespace ProjectTwo.Models
{
    public class User
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("DateCreated")]
        public DateTime DateCreated { get; set; }
    }
}