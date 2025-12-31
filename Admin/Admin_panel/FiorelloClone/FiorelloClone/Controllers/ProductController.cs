using FiorelloClone.Data;
using FiorelloClone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloClone.Controllers;

public class ProductController : Controller
{
    private readonly AppDbContext _context;
    public ProductController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        IEnumerable<Product> products = await _context.Products
            .Include(m => m.ProductImages)
            .Include(m => m.Category)
            .Where(m => !m.IsDeleted)
            .Skip(4)
            .Take(4)
            .ToListAsync();
        return View(products);
    }
    public async Task<IActionResult> Details(int id)
    {
        var product = await _context.Products
            .Include(p => p.ProductImages)
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

        if (product == null) return NotFound();

        return View(product);
    }
}
