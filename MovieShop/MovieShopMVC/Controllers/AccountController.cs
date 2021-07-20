using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.ServiceInterfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService) {
            _userService = userService;
        }
        //method for registration
        // show the empty view use get have boxes and submit button
        // localhost/account/register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var createdUser =await _userService.RegisterUser(model);
            //redirect to login
            return RedirectToAction("Login");

        }
        [HttpGet]
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestModel model)
        {
            if (!ModelState.IsValid) {
                return View();
            }
            var user = await _userService.Login(model.Email,model.Password);
            if (user == null)
            {
                //wrong password
                ModelState.AddModelError(string.Empty, "Invalid password");
                return View();
            }
            var claims = new List<Claim> {
                //all claims are string!!
                new Claim (ClaimTypes.Email, user.Email),
                new Claim (ClaimTypes.GivenName, user.FirstName),
                new Claim (ClaimTypes.Surname, user.LastName),
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return LocalRedirect("~/");
            //go back to homepage
        }
    }
}
