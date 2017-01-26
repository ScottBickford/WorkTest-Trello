using System;
using System.Web.Mvc;

namespace WorkTestTrello.Engine.Filters {
  /// <summary>
  /// Check if the user is logged in, if not redirect them to Home/Index, where they can login
  /// </summary>
  public class LoginFilter : ActionFilterAttribute {
    public bool Ignore { get; set; }

    public override void OnActionExecuting(ActionExecutingContext filterContext) {
      if (!Ignore && !Authentication.IsLoggedIn()) {
        filterContext.Result = new RedirectToRouteResult(
            new System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "Index" })
        );

        filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
        return;
      }
      base.OnActionExecuting(filterContext);
    }
  }
}
