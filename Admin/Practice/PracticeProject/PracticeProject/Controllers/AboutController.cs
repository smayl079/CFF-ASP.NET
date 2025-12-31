using Microsoft.AspNetCore.Mvc;
using PracticeProject.Data;
using PracticeProject.Models;

public class AboutController : Controller
{
    private readonly AppDbContext _context;

    public AboutController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var model = new AboutViewModel
        {
            Sliders = _context.Sliders.ToList()
        };

        return View(model);
    }
    public IActionResult About()
    {
        return View();
    }
}
