using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InfoPortal.WebMVC.Controllers
{
    [Authorize(Roles = "Admin, Editor")]
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly IWebHostEnvironment _appEnvironment;

        public LanguageController(ILanguageService articleService, IWebHostEnvironment appEnvironment)
        {
            _languageService = articleService;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            var languages = _languageService.GetAll();
            return View(languages);
        }

        [HttpPost]
        public IActionResult Create(Language language)
        {

            if (ModelState.IsValid)
            {
                language.Name = language.Name == null ? "" : language.Name;

                int id = _languageService.Create(language);

                return Json(new { success = true, responseText = "Language added", id });

            }

            var errorList = (from item in ModelState
                             where item.Value.Errors.Any()
                             select item.Value.Errors[0].ErrorMessage).ToList();


            return Json(new { success = false, responseText = errorList });
        }

        [HttpPost]
        public IActionResult Update(Language language)
        {
            if (ModelState.IsValid)
            {
                _languageService.Update(language);
                return Json(new { success = true, responseText = "Language changed" });
            }

            var errorList = (from item in ModelState
                             where item.Value.Errors.Any()
                             select item.Value.Errors[0].ErrorMessage).ToList();


            return Json(new { success = false, responseText = errorList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string message = _languageService.Delete(id).Message;

            return Json(new { success = true, responseText = message });

        }
    }
}

