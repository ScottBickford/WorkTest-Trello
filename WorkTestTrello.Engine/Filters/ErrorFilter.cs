using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WorkTestTrello.Engine.Filters {
  /// <summary>
  /// If any error occured while executing an Action, write to Error to the DB, then redirect to the Error Page
  /// </summary>
  public class ErrorFilter : FilterAttribute, IExceptionFilter {

    #region IExceptionFilter Members
    private static string version;
    public static string Version {
      get {
        if (version == null) {
          version = System.Reflection.Assembly.GetAssembly(typeof(ErrorFilter)).GetName().Version.ToString();
        }
        return version;
      }
    }

    public void OnException(ExceptionContext filterContext) {      
      if (filterContext != null && filterContext.Exception != null) {
        string sControllerName = filterContext.RouteData.Values["controller"].ToString();
        string sActionName = filterContext.RouteData.Values["action"].ToString();
        // TODO: Error Log
        int? errorLogID = ErrorLog.Log(filterContext.Exception, Authentication.GetFullName(), "Website", Version, sControllerName, sActionName);

        filterContext.Result = new RedirectToRouteResult(
          // TODO: Change Reference Number
            new System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "Error", ReferenceNum = errorLogID })
        );
        filterContext.ExceptionHandled = true;
      }
    }

    #endregion
  }
}