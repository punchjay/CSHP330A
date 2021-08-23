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
        private static List<User> Users = new List<User>();
        private static int currentId = 101;

        // GET api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Users;
        }

        // GET {guid} to get a single user
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);

            return user;
        }

        // POST to add a user
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            if (value == null)
            {
                return new BadRequestResult();
            }

            value.Id = currentId;
            Users.Add(value);

            return null;
        }

        // PUT {guid} to update a user
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);

            user = value;
        }

        // DELETE {guid} to delete a single user
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = Users.RemoveAll(u => u.Id == id);

            return Ok();
        }
    }
}
