using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoPortal.WebMVC.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult Create()
        {          
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            int id = _articleService.Create(article);
            return RedirectToAction("Detail", new { id });
        }

        [HttpGet("{id}")]
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
            var article = _articleService.Get(id);
            return View(article);
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
