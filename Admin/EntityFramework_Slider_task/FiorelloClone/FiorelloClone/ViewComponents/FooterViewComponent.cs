using FiorelloClone.Services;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloClone.ViewComponents;

public class FooterViewComponent : ViewComponent
{
    private readonly LayoutService _layoutService;
    public FooterViewComponent(LayoutService layoutService)
    {
        _layoutService = layoutService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var footerData = await _layoutService.GetAllSetting();
        return await Task.FromResult(View(footerData));
    }
}
