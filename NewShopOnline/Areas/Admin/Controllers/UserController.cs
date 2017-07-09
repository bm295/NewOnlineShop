using Model.DAO;
using Model.EntityFramework;
using NewShopOnline.Common;
using System.Web.Mvc;

namespace NewShopOnline.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var userService = new UserService();
            var model = userService.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var user = new UserService().GetUserBy(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Encryptor.MD5Hash(user.Password);
                var userService = new UserService();
                var userId = userService.Insert(user);
                if (userId > 0)
                    return RedirectToAction("Index", "User");
                else
                    ModelState.AddModelError(string.Empty, "Create user failed");
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(user.Password))
                    user.Password = Encryptor.MD5Hash(user.Password);

                var userService = new UserService();
                var result = userService.Update(user);
                if (result)
                    return RedirectToAction("Index", "User");
                else
                    ModelState.AddModelError(string.Empty, "Edit user failed");
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserService().Delete(id);
            return RedirectToAction("Index");
        }
    }
}