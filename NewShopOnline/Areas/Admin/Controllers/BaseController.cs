using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NewShopOnline.Common;

namespace NewShopOnline.Areas.Admin.Controllers;

[Area("Admin")]
public class BaseController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var username = HttpContext.Session.GetString(Constants.USER_SESSION);
        if (string.IsNullOrWhiteSpace(username))
        {
            context.Result = RedirectToAction("Index", "Login", new { area = "Admin" });
        }

        base.OnActionExecuting(context);
    }
}
