using Microsoft.AspNetCore.Mvc;

namespace InfoPortal.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
