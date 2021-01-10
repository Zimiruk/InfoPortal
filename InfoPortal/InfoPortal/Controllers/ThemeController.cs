using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InfoPortal.WebMVC.Controllers
{
    [Authorize(Roles = "Admin, Editor")]
    public class ThemeController : Controller
    {
        private readonly IThemeService _themeService;
        private readonly IWebHostEnvironment _appEnvironment;

        public ThemeController(IThemeService articleService, IWebHostEnvironment appEnvironment)
        {
            _themeService = articleService;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            var themes = _themeService.GetAll();  
            return View(themes);
        }

        [HttpPost]
        public IActionResult Create(Theme theme)
        {

            if (ModelState.IsValid)
            {
                theme.Name = theme.Name == null ? "" : theme.Name;

                int id = _themeService.Create(theme);
                return Json(new { success = true, responseText = "Theme added", id });
            }

            var errorList = (from item in ModelState
                             where item.Value.Errors.Any()
                             select item.Value.Errors[0].ErrorMessage).ToList();

            return Json(new { success = false, responseText = errorList });


        }

        [HttpPost]
        public IActionResult Update(Theme theme)
        {
            if (ModelState.IsValid)
            {
                _themeService.Update(theme);
                return Json(new { success = true, responseText = "Theme changed" });
            }

            var errorList = (from item in ModelState
                             where item.Value.Errors.Any()
                             select item.Value.Errors[0].ErrorMessage).ToList();

            return Json(new { success = false, responseText = errorList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string message = _themeService.Delete(id).Message;

            return Json(new { success = true, responseText = message });            

        }
    }
}
 