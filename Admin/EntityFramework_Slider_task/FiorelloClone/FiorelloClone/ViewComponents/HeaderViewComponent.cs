using FiorelloClone.Services;
using FiorelloClone.ViewModels;
using FiorelloClone.ViewModels.BasketVMs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FiorelloClone.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
    private readonly LayoutService _layoutService;

    public HeaderViewComponent(LayoutService layoutService)
    {
        _layoutService = layoutService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var basketCookie = HttpContext.Request.Cookies["basket"];

        int count = 0;
        decimal price = 0;

        if (!string.IsNullOrEmpty(basketCookie))
        {
            List<BasketVM> basket = JsonConvert.DeserializeObject<List<BasketVM>>(basketCookie);

            count = basket.Sum(x => x.Count);

            price = basket.Sum(x => x.Count * x.Price);
        }

        var settings = await _layoutService.GetAllSetting();

        HeaderVM headerVM = new()
        {
            Settings = settings,
            BasketCount = count,
            BasketPrice = price
        };

        return View(headerVM);
    }
}
