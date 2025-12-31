using Microsoft.AspNetCore.Mvc;

namespace MVCIntro.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
