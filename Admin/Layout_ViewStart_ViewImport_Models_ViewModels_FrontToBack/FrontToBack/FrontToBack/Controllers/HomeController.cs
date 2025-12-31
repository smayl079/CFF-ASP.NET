using FrontToBack.Data;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.Controllers
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
            IEnumerable<OurWork> ourWorks = await _context.OurWorks.Where(m => !m.IsDeleted).Include(m => m.Category).ToListAsync();
            IEnumerable<Category> categories = await _context.Categories.Where(m => !m.IsDeleted).ToListAsync();

            HomeVM homeVM = new()
            {
                OurWorks = ourWorks,
                Categories = categories
            };

            return View(homeVM);
        }
    }
}
