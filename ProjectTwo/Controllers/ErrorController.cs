﻿using Microsoft.AspNetCore.Mvc;

namespace HelloWorldService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error/{code}")]
        public IActionResult Error(int code) => new ObjectResult(new ApiResponse(code));
    }
}