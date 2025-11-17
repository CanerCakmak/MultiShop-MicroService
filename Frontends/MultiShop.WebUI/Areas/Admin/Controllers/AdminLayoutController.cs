using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

public class AdminLayoutController : Controller
{
    public IActionResult _AdminLayout()
    {
        return View();
    }
}
