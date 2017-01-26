using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WorkTestTrello.Engine.Engines;
using WorkTestTrello.Engine.Models;

namespace WorkTestTrello.Website.Controllers {
  public class BoardController : BaseController<IBoardEngine> {

    #region Index
    /// <summary>
    /// Used for the Index View
    /// </summary>
    /// <returns>View(OrganisationListViewModel)</returns>
    public ActionResult Index() {
      var viewModel = Engine.GetBoards();
      return View(viewModel);
    }
    #endregion

    #region BoardItem
    /// <summary>
    /// Used for the BoardItem View
    /// </summary>
    /// <param name="submitModel">The Model containing which Board Item to show</param>
    /// <returns>View(ListListViewModel)</returns>
    public ActionResult BoardItem(BoardItemSubmitModel submitModel) {
      var viewModel = Engine.GetBoardLists(submitModel);
      return View(viewModel);
    }
    #endregion

    #region PopupCardItem
    /// <summary>
    /// Used for the PopupCardItem
    /// </summary>
    /// <param name="submitModel">The Model containing which Card Item to show</param>
    /// <returns>View(CardItemViewModel)</returns>
    public ActionResult PopupCardItem(CardItemSubmitModel submitModel) {
      var viewModel = Engine.GetCardAndActions(submitModel);
      return View(viewModel);
    }
    #endregion

    #region AddComment
    /// <summary>
    /// The callback from Adding a Comment
    /// </summary>
    /// <param name="submitModel">The information to post to Trello</param>
    /// <returns>Json result</returns>
    [HttpPost]
    public ActionResult AddComment(CardActionSubmitModel submitModel) {
      return JsonResult(Engine.AddComment, submitModel);
    }
    #endregion

    #region _LoadCardAction
    /// <summary>
    /// Used to get just 1 action for the _LoadCardAction partial view
    /// </summary>
    /// <param name="submitModel">A Model containing which action to load</param>
    /// <returns>View(ActionItemViewModel)</returns>
    public ActionResult _LoadCardAction(ActionItemSubmitModel submitModel) {
      var viewModel = Engine.GetAction(submitModel);
      return View(viewModel);
    }
    #endregion
  }
}