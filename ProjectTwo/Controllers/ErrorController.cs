using Microsoft.AspNetCore.Mvc;

namespace HelloWorldService.Controllers
{
    /// <summary>
    /// Error controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        /// <summary>
        /// This is the primary Error route
        /// </summary>
        /// <param name="code">Http Status code (Integer*32)</param>
        [Route("/error/{code}")]
        [HttpGet]
        public IActionResult Error(int code) => new ObjectResult(new ApiResponse(code));
    }
}