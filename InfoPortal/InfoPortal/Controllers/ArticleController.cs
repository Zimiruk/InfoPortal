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

        [HttpGet("{id}")]
        public IActionResult Detail(int id)
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
    }
}
