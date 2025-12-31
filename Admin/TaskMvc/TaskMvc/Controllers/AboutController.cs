using Microsoft.AspNetCore.Mvc;

namespace TaskMvc.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
