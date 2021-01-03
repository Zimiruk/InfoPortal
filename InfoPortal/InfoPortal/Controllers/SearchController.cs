using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Enum;
using InfoPortal.Common.Models;
using InfoPortal.WebMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InfoPortal.WebMVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly IArticleService _articleService;

        private readonly IWebHostEnvironment _appEnvironment;

        public SearchController(IArticleService articleService, IWebHostEnvironment appEnvironment)
        {
            _articleService = articleService;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index(string expression, SearchParameter parameter)
        {
            if (expression == null)
            {
                return View();
            }

            List<Article> articles = new List<Article>();

            switch (parameter)
            {
                case SearchParameter.Name:
                    articles = _articleService.GetAllByName(expression);
                    break;
                case SearchParameter.Theme:
                    articles = _articleService.GetAllByThemeName(expression);
                    break;
                case SearchParameter.Date:
                    DateTime date = DateTime.Parse(expression);
                    articles = _articleService.GetAllByDate(date);
                    break;
            }

            return View(articles);
        }
    }
}
