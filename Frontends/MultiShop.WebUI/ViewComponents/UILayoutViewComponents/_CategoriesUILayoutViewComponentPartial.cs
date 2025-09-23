using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents;

public class _CategoriesUILayoutViewComponentPartial: ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
