using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using InfoPortal.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace InfoPortal.WebMVC.Controllers
{

    [Authorize(Roles = "Admin, Editor")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IThemeService _themeService;
        private readonly ILanguageService _languageService;

        private readonly IWebHostEnvironment _appEnvironment;

        public ArticleController(IArticleService articleService, IThemeService themeService, IWebHostEnvironment appEnvironment, ILanguageService languageService)
        {
            _articleService = articleService;
            _themeService = themeService;
            _languageService = languageService;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IActionResult Create()
        {
            SelectList languages = new SelectList(_languageService.GetAll(), "Id", "Name");

            ViewBag.Themes = _themeService.GetAll();
            ViewBag.Languages = languages;

            ArticleViewModel articleViewModel = new ArticleViewModel();

            return View(articleViewModel);
        }

        [HttpPost]
        public IActionResult Add(ArticleViewModel article)
        {
            if (ModelState.IsValid)
            {
                Article newArticle = new Article();

                newArticle.ThemesId = article.ThemesId;
                newArticle.Name = article.Name;
                newArticle.LanguageId = article.LanguageId;
                newArticle.Text = article.Text;

                byte[] imageData = null;
                using (var binaryReader = new System.IO.BinaryReader(article.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)article.Image.Length);
                }

                newArticle.Image = imageData;

                byte[] videoData = null;
                using (var binaryReader = new System.IO.BinaryReader(article.Video.OpenReadStream()))
                {
                    videoData = binaryReader.ReadBytes((int)article.Video.Length);
                }

                newArticle.Video = videoData;

                int id = _articleService.Create(newArticle);

                return RedirectToAction("Detail", new { newArticle.Id });

            }

            var errorList = (from item in ModelState
                             where item.Value.Errors.Any()
                             select item.Value.Errors[0].ErrorMessage).ToList();


            return Json(new { success = false, responseText = errorList });
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
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

            UpdateArticleViewModel model = new UpdateArticleViewModel();

            model.Id = article.Id;
            model.Name = article.Name;
            model.ThemesId = article.ThemesId;
            model.LanguageId = article.LanguageId;
            model.Text = article.Text;

            model.ImageContent = article.Image;
            model.VideoContent = article.Video;

            SelectList languages = new SelectList(_languageService.GetAll(), "Id", "Name");

            ViewBag.Themes = _themeService.GetAll();
            ViewBag.Languages = languages;

            return View(model);
        }


        [HttpPost]
        public IActionResult Update(UpdateArticleViewModel article)
        {

            if (ModelState.IsValid)
            {
                Article newArticle = new Article();

                newArticle.Id = article.Id;
                newArticle.ThemesId = article.ThemesId;
                newArticle.Name = article.Name;
                newArticle.LanguageId = article.LanguageId;
                newArticle.Text = article.Text;

                if (article.Image != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new System.IO.BinaryReader(article.Image.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)article.Image.Length);
                    }

                    newArticle.Image = imageData;
                }

                else
                {
                    newArticle.Image = _articleService.Get(newArticle.Id).Image;
                }

                if (article.Video != null)
                {

                    byte[] videoData = null;
                    using (var binaryReader = new System.IO.BinaryReader(article.Video.OpenReadStream()))
                    {
                        videoData = binaryReader.ReadBytes((int)article.Video.Length);
                    }

                    newArticle.Video = videoData;

                }

                else
                {
                    newArticle.Video = _articleService.Get(newArticle.Id).Video;
                }

                _articleService.Update(newArticle);

                return RedirectToAction("Detail", new { newArticle.Id });


            }

            var errorList = (from item in ModelState
                             where item.Value.Errors.Any()
                             select item.Value.Errors[0].ErrorMessage).ToList();


            return Json(new { success = false, responseText = errorList });
        }


        public IActionResult Delete(int id)
        {
            _articleService.Delete(id);
            return RedirectToAction("Index", "Home");
        }

    }
}
