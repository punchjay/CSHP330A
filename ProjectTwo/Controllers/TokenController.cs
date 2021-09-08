using Microsoft.AspNetCore.Mvc;
using ProjectTwo.Models;

namespace ProjectTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public dynamic Post([FromBody] TokenRequest tokenRequest)
        {
            var token = TokenHelper.GetToken(tokenRequest.UserName, tokenRequest.Password);
            return new { Token = token };
        }

        [HttpGet]
        public dynamic Get(string userName, string password)
        {
            var token = TokenHelper.GetToken(userName, password);
            return new { Token = token };
        }
    }
}