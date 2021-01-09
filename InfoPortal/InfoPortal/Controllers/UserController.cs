using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using InfoPortal.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace InfoPortal.WebMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _appEnvironment;

        public UserController(IUserService articleService, IWebHostEnvironment appEnvironment)
        {
            _userService = articleService;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SelectList roles = new SelectList(_userService.GetRoles(), "Id", "Name");
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            int id = _userService.Create(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = _userService.Get(id);
            SelectList roles = new SelectList(_userService.GetRoles(), "Id", "Name");
            ViewBag.Roles = roles;
            return View(user);
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            _userService.Update(user);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);

            return Json(new { success = true, responseText = "" });

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            var user = _userService.CheckUser(model.Email, model.Password);

            if (user != null)
            {
                await Authenticate(model.Email, user.Role);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(string email, Role role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name),
            };

            var id = new ClaimsIdentity(claims, "AuthCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}

