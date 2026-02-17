using Microsoft.AspNetCore.Mvc;
using Model.DAO;
using NewShopOnline.Areas.Admin.Models;
using NewShopOnline.Common;

namespace NewShopOnline.Areas.Admin.Controllers;

[Area("Admin")]
public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginModel loginModel)
    {
        if (ModelState.IsValid)
        {
            var userService = new UserService();
            var result = userService.Login(loginModel.Username, Encryptor.MD5Hash(loginModel.Password));

            if (result == 1)
            {
                var user = userService.GetUserBy(loginModel.Username);
                HttpContext.Session.SetString(Constants.USER_SESSION, user.Username);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            var error = result switch
            {
                0 => "Account not exist",
                -1 => "Account is locked",
                -2 => "Wrong password",
                _ => "Invalid Login"
            };

            ModelState.AddModelError(string.Empty, error);
        }

        return View("Index");
    }
}
