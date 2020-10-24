using Microsoft.AspNetCore.Mvc;

namespace InfoPortal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
