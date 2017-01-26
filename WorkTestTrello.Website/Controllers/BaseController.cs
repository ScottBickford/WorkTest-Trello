using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

using WorkTestTrello.Engine.Engines;
using WorkTestTrello.Engine.Models;
using WorkTestTrello.Engine.Filters;

namespace WorkTestTrello.Website.Controllers {
  /// <summary>
  /// A Base Class to be used by the controllers. The Class expects a type interface for an engine, where the logic will sit. (Helps keep the Controller thin)
  /// </summary>
  /// <typeparam name="T">A type interface that inherits from IBaseEngine, where the logic will sit.</typeparam>
  [LoginFilter]
  [ErrorFilter]  
  public abstract class BaseController<T> : Controller where T : IBaseEngine {
    #region Properties
    private T engine;
    /// <summary>
    /// Create (if needed) and return a the Engine Class based on the interface type associated with this Class.
    /// </summary>
    protected T Engine {
      get {
        if (engine == null) {
          var container = App_Start.UnityConfig.GetConfiguredContainer();
          engine = (T)container.Resolve(typeof(T));
          engine.Initialise(container);
        }
        return engine;
      }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Checks if the Model State is valid - if yes call actionMethod and send result to client, else return an error to client
    /// </summary>
    /// <typeparam name="In">The Type of Parameter for model</typeparam>
    /// <typeparam name="Out">The Output Type of this function</typeparam>
    /// <param name="actionMethod">The Method to Call if the Model State is valid</param>
    /// <param name="model">The model to pass through to the actionMethod</param>
    /// <returns>Returns a Json result for the client</returns>
    protected ActionResult JsonResult<In, Out>(Func<In, Out> actionMethod, In model) {
      if (ModelState.IsValid) {
        Out returnID = actionMethod(model);
        return Json(JsonResultSuccess(returnID.ToString()));
      }
      return Json(JsonResultError());
    }

    /// <summary>
    /// Checks if the Model State is valid - if yes call actionMethod and send the returnID parameter to the client, else return an error to client
    /// </summary>
    /// <typeparam name="In">The Type of Parameter for model</typeparam>
    /// <param name="actionMethod">The Method to Call if the Model State is valid</param>
    /// <param name="model">The model to pass through to the actionMethod</param>
    /// <param name="returnID">What to return to the client if the Model State is valie</param>
    /// <returns>Returns a Json result for the client</returns>
    protected ActionResult JsonResult<In>(Action<In> actionMethod, In model, string returnID) {
      if (ModelState.IsValid) {
        actionMethod(model);
        return Json(JsonResultSuccess(returnID));
      }
      return Json(JsonResultError());
    }

    /// <summary>
    /// Checks if the Model State is valid - if yes call actionMethod and sends true the client, else return an error to client
    /// </summary>
    /// <typeparam name="In">The Type of Parameter for model</typeparam>
    /// <param name="actionMethod">The Method to Call if the Model State is valid</param>
    /// <param name="model">The model to pass through to the actionMethod</param>
    /// <returns>Returns a Json result for the client</returns>
    protected ActionResult JsonResult<In>(Action<In> actionMethod, In model) {
      if (ModelState.IsValid) {
        actionMethod(model);
        return Json(JsonResultSuccess(true.ToString()));  // Result it success
      }
      return Json(JsonResultError());
    }

    private JsonResultModel JsonResultSuccess(int value) {
      return JsonResultSuccess(value.ToString());
    }

    private JsonResultModel JsonResultSuccess(string value) {
      return new JsonResultModel {
        Value = value,
        ErrorOccurred = false
      };
    }

    private JsonResultModel JsonResultError() {
      return new JsonResultModel {
        ErrorOccurred = true,
        ErrorDescription = GetModelStateErrors()
      };
    }

    private string GetModelStateErrors() {
      List<string> errors = new List<string>();
      foreach (var value in ModelState.Values) {
        foreach (var error in value.Errors) {
          errors.Add(error.ErrorMessage);
        }
      }
      return string.Format("Please correct the following errors and try again<ul>{0}</ul>",
        string.Join(string.Empty,
        (from e in errors select string.Format("<li>{0}</li>", e)).ToList()
        ));
    }
    #endregion
  }
}