using FiorelloClone.Data;
using FiorelloClone.Models;
using FiorelloClone.ViewModels.BasketVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FiorelloClone.Controllers;

public class BasketController : Controller
{
    private readonly AppDbContext _context;

    public BasketController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<BasketVM> basket = Request.Cookies["basket"] != null
            ? JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"])
            : new List<BasketVM>();

        List<BasketDetailVM> basketDetails = new();

        foreach (var item in basket)
        {
            Product product = await _context.Products
                .Include(m => m.ProductImages)
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == item.Id && !m.IsDeleted);

            if (product == null) continue;

            basketDetails.Add(new BasketDetailVM
            {
                Id = item.Id,
                Count = item.Count,
                Image = product.ProductImages.FirstOrDefault(m => m.IsMain)?.Image,
                Name = product.Name,
                Category = product.Category.Name,
                Price = product.Price,
                TotalPrice = product.Price * item.Count
            });
        }

        return View(basketDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Add(int? id)
    {
        if (id is null) return BadRequest();

        var product = await _context.Products
            .Include(p => p.ProductImages)
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

        if (product is null) return NotFound();

        List<BasketVM> basket = Request.Cookies["basket"] != null
            ? JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"])
            : new List<BasketVM>();

        var exist = basket.FirstOrDefault(x => x.Id == id);

        if (exist == null)
        {
            basket.Add(new BasketVM
            {
                Id = product.Id,
                Count = 1,
                Price = product.Price
            });
        }
        else
        {
            exist.Count++;
            exist.Price = product.Price;
        }

        Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

        int currentCount = basket.First(x => x.Id == product.Id).Count;

        var detail = new BasketDetailVM
        {
            Id = product.Id,
            Count = currentCount,
            Image = product.ProductImages.FirstOrDefault(x => x.IsMain)?.Image,
            Name = product.Name,
            Category = product.Category.Name,
            Price = product.Price,
            TotalPrice = product.Price * currentCount
        };

        int totalCount = basket.Sum(x => x.Count);
        decimal totalPrice = basket.Sum(x => x.Count * x.Price);

        return Ok(new { totalCount, totalPrice, item = detail });
    }
}
