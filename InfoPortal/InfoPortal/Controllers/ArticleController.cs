using Microsoft.AspNetCore.Mvc;

namespace InfoPortal.WebMVC.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Detail(int id)
        {
           if (id == 0)
            {
                return NotFound();
            }

            return View();           
        }
    }
}
