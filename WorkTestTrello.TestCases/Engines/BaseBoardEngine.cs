using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Engine.Engines;
using WorkTestTrello.Engine.Models;

namespace WorkTestTrello.TestCases.Engines {
  /// <summary>
  /// Base class for test cases - inherit from this class and only override the functions you want to test
  /// </summary>
  public abstract class BaseBoardEngine : IBoardEngine {

    public virtual OrganisationListViewModel GetBoards() {
      return new OrganisationListViewModel();
    }

    public virtual ListListViewModel GetBoardLists(BoardItemSubmitModel submitModel) {
      return new ListListViewModel { Board = new BoardItemViewModel { BackgroundColor = "white" } };
    }

    public virtual ActionItemViewModel GetAction(ActionItemSubmitModel submitModel) {
      return new ActionItemViewModel();
    }

    public virtual CardItemViewModel GetCardAndActions(CardItemSubmitModel submitModel) {
      return new CardItemViewModel();
    }

    public virtual string AddComment(CardActionSubmitModel submitModel) {
      return string.Empty;
    }

    public void Initialise(Microsoft.Practices.Unity.IUnityContainer container) {
      // Don't need to do anything here as we won't be resolving any dependancies
    }
  }
}
