using Microsoft.AspNetCore.Mvc;

namespace InfoPortal.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
