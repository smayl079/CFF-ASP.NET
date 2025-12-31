using Microsoft.AspNetCore.Mvc;
using PracticeProject.Data;
using PracticeProject.Models;

namespace PracticeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Sliders = _context.Sliders.ToList(),

                Categories = _context.Categories.ToList(),

                NewProducts = _context.Products
                    .Where(x => x.IsNew)
                    .Take(10)
                    .ToList(),

                BestSellerProducts = _context.Products
                    .Where(x => x.IsBestSeller)
                    .Take(10)
                    .ToList(),

                FeaturedProducts = _context.Products
                    .Where(x => x.IsFeatured)
                    .Take(10)
                    .ToList()
            };

            return View(model);
        }
    }
}
