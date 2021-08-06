using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult RegisterForm()
        {
            return View(new RegisterModel());
        }

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

        [HttpGet]
        public IActionResult LogIn()
        {
            return View(new LogInModel());
        }

        [HttpPost]
        public IActionResult LogInForm(Models.LogInModel logInModelResponse)
        {
            if (ModelState.IsValid)
            {
                return View("EnrollInClass");
            }
            else
            {
                return View("StudentClasses", logInModelResponse);
            }
        }

        [HttpGet]
        public IActionResult ClassList()
        {
            var classListRepo = new ClassListRepository();
            var classList = classListRepo.ClassList;

            return View(classList);
        }

        public IActionResult StudentClasses()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnrollInClass()
        {
            var classListRepo = new ClassListRepository();
            var classList = classListRepo.ClassList;

            return View(classList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
