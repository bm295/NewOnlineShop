using System.Web.Mvc;
using Model.DAO;
using Model.EntityFramework;

namespace NewShopOnline.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var contentService = new ContentService();
            var content = contentService.GetContentBy(id);
            SetViewBag(content.CategoryId);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {
            }
            SetViewBag(model.CategoryId);
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Content model)
        {
            if (ModelState.IsValid)
            {
            }
            SetViewBag();
            return View();
        }

        public void SetViewBag(long? selectedId = null)
        {
            var categoryService = new CategoryService();
            ViewBag.CategoryId = new SelectList(categoryService.ListAll(), "Id", "Name", selectedId);
        }
    }
}