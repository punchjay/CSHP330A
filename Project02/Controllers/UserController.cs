using Microsoft.AspNetCore.Mvc;
using ProjectTwo.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly List<User> Users = new List<User>();
        private static int currentId = 101;

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Users;
        }

        // GET api/<UserController>/5 ****GET {guid} to get a single user
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);

            return user;
        }

        // POST api/<UserController> ****POST to add a user
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            if (value == null)
            {
                return new BadRequestResult();
            }
            Users.Add(value);

            return null;
        }

        // PUT api/<UserController>/5 ****PUT {guid} to update a user
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
        }

        // DELETE api/<UserController>/5 ****DELETE {guid} to delete a single user
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
