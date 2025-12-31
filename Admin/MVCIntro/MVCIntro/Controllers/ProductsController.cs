using Microsoft.AspNetCore.Mvc;

namespace MVCIntro.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
