using InfoPortal.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using InfoPortal.Common.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace InfoPortal.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;

        public HomeController(IArticleService articleService)
        {
            _articleService = articleService;
        }
    
        public IActionResult Index()
        {
            var articles = _articleService.GetAll();  
            return View(articles);
        }
    }
}
