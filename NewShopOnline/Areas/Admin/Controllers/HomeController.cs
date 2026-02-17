using Microsoft.AspNetCore.Mvc;

namespace NewShopOnline.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
