using Model.DAO;
using NewShopOnline.Areas.Admin.Models;
using NewShopOnline.Common;
using System.Web.Mvc;

namespace NewShopOnline.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var userService = new UserService();
                var result = userService.Login(loginModel.Username, loginModel.Password);

                if (result)
                {
                    var user = userService.GetUserBy(loginModel.Username);
                    var userSession = new UserLoginSession()
                    {
                        UserId = user.Id,
                        Username = user.Username
                    };
                    Session.Add(Constants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login");
                }
            }
            return View("Index");
        }
    }
}