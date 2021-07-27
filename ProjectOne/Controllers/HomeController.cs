using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectOne.Models;
using System.Diagnostics;

namespace ProjectOne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult RegisterForm()
        //{
        //    return View(new RegisterModel());
        //}

        [HttpPost]
        public IActionResult RegisterForm(Models.RegisterModel registerModelResponse)
        {
            if (ModelState.IsValid)
            {
                return View("EnrollInClass");
            }
            else
            {
                return View("Register", registerModelResponse);
            }
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ClassList()
        {
            var context = new Db.minicstructorContext();

            var classes = context.Class
                        .Include(t => t.UserClass)
                        .ThenInclude(t => t.User);

            return View(classes);
        }

        public IActionResult StudentClasses()
        {
            return View();
        }

        public IActionResult EnrollInClass()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
