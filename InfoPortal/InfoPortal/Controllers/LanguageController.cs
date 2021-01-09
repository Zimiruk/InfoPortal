using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace InfoPortal.WebMVC.Controllers
{
    [Authorize(Roles = "Admin, User")]

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
            /// TODO Add validation
            /// 

            language.Name = language.Name == null ? "" : language.Name;

            int id = _languageService.Create(language);
            return Json(new { success = true, responseText = "Language added", id });
        }

        [HttpPost]
        public IActionResult Update(Language language)
        {
            _languageService.Update(language);
            return Json(new { success = true, responseText = "Language changed" });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string message = _languageService.Delete(id).Message;

            return Json(new { success = true, responseText = message });

        }
    }
}

