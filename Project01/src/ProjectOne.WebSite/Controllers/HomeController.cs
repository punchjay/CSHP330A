using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectOne.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace ProjectOne.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClassListManager classListManager;
        private readonly IEnrollClassManager enrollClassManager;
        private readonly IStudentClassManager studentClassManager;
        private readonly IUserManager userManager;

        public HomeController(IClassListManager classListManager,
            IEnrollClassManager enrollClassManager,
            IStudentClassManager studentClassManager,
            IUserManager userManager)
        {
            this.classListManager = classListManager;
            this.enrollClassManager = enrollClassManager;
            this.studentClassManager = studentClassManager;
            this.userManager = userManager;
        }

        public ActionResult Index() => View();

        [HttpGet]
        public ActionResult ClassList()
        {
            var classList = classListManager
                .ClassList
                .Select(t => new Models.ClassListModel
                {
                    ClassId = t.ClassId,
                    ClassDescription = t.ClassDescription,
                    ClassName = t.ClassName,
                    ClassPrice = t.ClassPrice,
                })
                .ToArray();

            return View(classList);
        }

        public IActionResult StudentClass()
        {
            var userClasses = studentClassManager
                .UserClasses
                .Select(t => new Models.UserClassModel
                {
                    ClassId = t.ClassId,
                    UserId = t.UserId,
                }).ToArray();

            return View(userClasses);
        }

        [HttpGet]
        public ActionResult EnrollClass()
        {
            var enrollClassList = enrollClassManager
                .EnrollClass
                .Select(t => new Models.EnrollClassModel
                {
                    ClassId = t.ClassId,
                    ClassName = t.ClassName,
                })
                .ToArray();

            return View(enrollClassList);
        }

        [HttpPost]
        public ActionResult EnrollClassForm(Models.EnrollClassModel enrollClassModel)
        {
            if (ModelState.IsValid)
            {
                return View("StudentClass", enrollClassModel);
            }
            else
            {
                return View(enrollClassModel);
            }
        }

        public ActionResult LogIn()
        {
            ViewData["ReturnUrl"] = Request.Query["returnUrl"];

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.LogIn(loginModel.UserName, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    var json = JsonConvert.SerializeObject(new Models.UserModel
                    {
                        Id = user.Id,
                        Name = user.Name
                    });

                    HttpContext.Session.SetString("User", json);

                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, "User"),
                };

                    var claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = false,
                        // Refreshing the authentication session should be allowed.

                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        IsPersistent = false,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        IssuedUtc = DateTimeOffset.UtcNow,
                        // The time at which the authentication ticket was issued.
                    };

                    HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        claimsPrincipal,
                        authProperties).Wait();

                    return Redirect(returnUrl ?? "~/");
                }
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View(loginModel);
        }

        public ActionResult LogOff()
        {
            HttpContext.Session.Remove("User");

            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("~/");
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Register(registerModel.UserName, registerModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("msg", "The email is already in use.");
                    return View();
                }
                return View("LogIn");
            }

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
