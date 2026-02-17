using Microsoft.AspNetCore.Mvc;

namespace NewShopOnline.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    public IActionResult Index() => View();

    public IActionResult Create() => View();
}
