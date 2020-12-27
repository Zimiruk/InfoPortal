﻿using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InfoPortal.WebMVC.Controllers
{
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
            /// TODO Add validation
            /// 

            theme.Name = theme.Name == null ? "" : theme.Name;

            int id = _themeService.Create(theme);
            return Json(new { success = true, responseText = "Theme added", id });
        }

        [HttpPost]
        public IActionResult Update(Theme theme)
        {
            _themeService.Update(theme);
            return Json(new { success = true, responseText = "Theme chenged"});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string message = _themeService.Delete(id).Message;

            return Json(new { success = true, responseText = message });            

        }
    }
}
 