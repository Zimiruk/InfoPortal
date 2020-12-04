using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using InfoPortal.WebMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InfoPortal.WebMVC.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IWebHostEnvironment _appEnvironment;

        public ArticleController(IArticleService articleService, IWebHostEnvironment appEnvironment)
        {
            _articleService = articleService;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IActionResult Create()
        {          
            return View();
        }

        [HttpPost]
        public IActionResult Add(ArticleViewModel article)
        {
            /// TODO Add validation

            Article newArticle = new Article();

            newArticle.Name = article.Name == null ? "" : article.Name;
            newArticle.Theme = article.Theme == null ? "" : article.Theme;
            newArticle.Language = article.Language == null ? "" : article.Language;

            newArticle.Files = new List<File>();

            if(article.Files != null)
            {
                foreach (var file in article.Files)
                {
                    byte[] imageData = null;  
                    using (var binaryReader = new System.IO.BinaryReader(file.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)file.Length);
                    }

                    newArticle.Files.Add(new File
                    {
                        Content = imageData
                    });
                }
            }

            int id = _articleService.Create(newArticle);    

            return Json(new { success = true, responseText = "Article added", id });
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            else
            {
                ViewBag.Id = id;
                return View();
            }
        }

        public IActionResult Content(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            else
            {
                var article = _articleService.Get(id); 
                return View(article);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var article = _articleService.Get(id);
            return View(article);
        }

        [HttpPost]
        public IActionResult Update(Article article)
        {
            _articleService.Update(article);
            return RedirectToAction("Detail", new { id = article.Id });
        }

        public IActionResult Delete(int id)
        {
            _articleService.Delete(id);
            return RedirectToAction("Index", "Home");
        }

    }
}
