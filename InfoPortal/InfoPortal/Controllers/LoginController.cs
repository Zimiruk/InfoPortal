using Microsoft.AspNetCore.Mvc;

namespace InfoPortal.WebMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
