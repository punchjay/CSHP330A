using System;

namespace ProjectTwo.Database
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
    }
}