using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WorkTestTrello.Engine.Engines;
using WorkTestTrello.Engine.Models;
using WorkTestTrello.Engine.Filters;

namespace WorkTestTrello.Website.Controllers {
  [LoginFilter(Ignore = true)]
  public class HomeController : BaseController<IHomeEngine> {
    #region Index
    /// <summary>
    /// Used for the Index View
    /// </summary>
    /// <returns>View(HomeViewModel)</returns>
    public ActionResult Index() {
      var viewModel = Engine.GetHomeViewModel();
      return View(viewModel);
    }
    #endregion

    #region Authorise
    /// <summary>
    /// Called from the Authorise Submit Button on the Index Page
    /// </summary>
    /// <param name="submitModel">The Model containing the information</param>
    /// <returns>Json result</returns>
    [HttpPost]
    public ActionResult Authorise(AuthoriseSubmitModel submitModel) {
      return JsonResult(Engine.Authorise, submitModel);
    }
    #endregion

    #region Error
    /// <summary>
    /// Used for the Error View
    /// </summary>
    /// <param name="viewModel">The Model containing a reference number if any</param>
    /// <returns>View(ErrorViewModel)</returns>
    public ActionResult Error(ErrorViewModel viewModel) {
      return View(viewModel);
    }
    #endregion
  }
}