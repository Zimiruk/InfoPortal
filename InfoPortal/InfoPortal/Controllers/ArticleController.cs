using Microsoft.AspNetCore.Mvc;

namespace InfoPortal.WebMVC.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
