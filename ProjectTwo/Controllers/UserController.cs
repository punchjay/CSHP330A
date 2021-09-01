using Microsoft.AspNetCore.Mvc;
using ProjectTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly List<User> Users = new List<User>();
        private Guid guidId = Guid.NewGuid();

        // GET api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Users;
        }

        // GET {guid} to get a single user
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return Ok(user);
            }
        }

        // POST to add a user
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            if (value == null)
            {
                return new BadRequestResult();
            }

            if (value.Email == null)
            {
                return BadRequest(new ErrorResponse
                {
                    Message = "Email field is null",
                    DBCode = 9000,
                    Data = value
                });
            }

            if (value.Password == null)
            {
                return BadRequest(new ErrorResponse
                {
                    Message = "Password field is null",
                    DBCode = 800,
                    Data = value
                });
            }

            value.Id = guidId;
            value.DateCreated = DateTime.UtcNow;
            Users.Add(value);

            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        // PUT {guid} to update a user
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] User value)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.Email = value.Email;
            user.Password = value.Password;

            return Ok(user);
        }

        // DELETE {guid} to delete a single user
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var userDelete = Users.RemoveAll(u => u.Id == id);

            if (userDelete == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}