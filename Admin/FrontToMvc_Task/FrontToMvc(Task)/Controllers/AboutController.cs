using Microsoft.AspNetCore.Mvc;

namespace FrontToMvc_Task_.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


