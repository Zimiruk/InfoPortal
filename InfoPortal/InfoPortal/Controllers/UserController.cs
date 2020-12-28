using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace InfoPortal.WebMVC.Controllers
{
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
    }
}

