using InfoPortal.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InfoPortal.WebMVC.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Index()
        {/*
            var articles = _articleService.GetAll();
            return View(articles);
            */

            List<Theme> themes = new List<Theme>
            {
                new Theme
                {
                    Id = 1,
                    Name = "Theme"
                }
            };
           

            return View(themes);
        }
    }
}
 