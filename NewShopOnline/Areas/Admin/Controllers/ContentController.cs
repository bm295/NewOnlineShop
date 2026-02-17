using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.DAO;
using Model.EntityFramework;

namespace NewShopOnline.Areas.Admin.Controllers;

[Area("Admin")]
public class ContentController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        SetViewBag();
        return View();
    }

    [HttpGet]
    public IActionResult Edit(long id)
    {
        var contentService = new ContentService();
        var content = contentService.GetContentBy(id);
        SetViewBag(content.CategoryId);
        return View();
    }

    [HttpPost]
    public IActionResult Edit(Content model)
    {
        SetViewBag(model.CategoryId);
        return View();
    }

    [HttpPost]
    public IActionResult Create(Content model)
    {
        SetViewBag();
        return View();
    }

    public void SetViewBag(long? selectedId = null)
    {
        var categoryService = new CategoryService();
        ViewBag.CategoryId = new SelectList(categoryService.ListAll(), "Id", "Name", selectedId);
    }
}
