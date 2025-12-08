


// File: Controllers/ContactController.cs
using Microsoft.AspNetCore.Mvc;


namespace MyWebApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            // This will render Views/Contact/Index.cshtml
            return View();
        }
    }
}


// File: Controllers/ProductsController.cs



namespace MyWebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            // This will render Views/Products/Index.cshtml
            return View();
        }


        // Example of another action
        public IActionResult Details(int id)
        {
            ViewBag.ProductId = id;
            return View(); // Views/Products/Details.cshtml
        }
    }
}





namespace MyWebApp.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Views/Services/Index.cshtml
        }
    }
}