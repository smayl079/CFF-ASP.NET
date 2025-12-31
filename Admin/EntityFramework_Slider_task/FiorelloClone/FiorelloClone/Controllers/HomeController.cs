using FiorelloClone.Data;
using FiorelloClone.Models;
using FiorelloClone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //HttpContext.Session.SetString("name", "Fiorello");
            //HttpContext.Response.Cookies.Append("surname", "Clone", new CookieOptions
            //{
            //    MaxAge = TimeSpan.FromMinutes(10)
            //});

            //ViewBag.SessionName = HttpContext.Session.GetString("name");
            //ViewBag.CookieSurname = HttpContext.Request.Cookies["surname"];

            IEnumerable<Slider> sliders = await _context.Sliders
                .Where(m => !m.IsDeleted)
                .ToListAsync();

            SliderDetail sliderDetail = await _context.SliderDetails
                .FirstOrDefaultAsync(m => !m.IsDeleted);

            IEnumerable<Product> products = await _context.Products
                .Where(m => !m.IsDeleted)
                .Include(m => m.ProductImages)
                .Include(m => m.Category)
                .Take(4)
                .ToListAsync();

            IEnumerable<Category> categories = await _context.Categories
                .Where(m => !m.IsDeleted)
                .ToListAsync();

            HomeVM homeVM = new()
            {
                Sliders = sliders,
                SliderDetail = sliderDetail,
                Products = products,
                Categories = categories
            };

            ViewBag.ProductCount = await _context.Products.CountAsync(m => !m.IsDeleted);

            return View(homeVM);
        }

        public async Task<IActionResult> LoadMore(int skip)
        {
            IEnumerable<Product> products = await _context.Products
                .Where(m => !m.IsDeleted)
                .Include(m => m.ProductImages)
                .Include(m => m.Category)
                .Skip(skip)
                .Take(4)
                .ToListAsync();
            return PartialView("_ProductPartial", products);
        }
    }
}
