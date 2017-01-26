using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Engine.Models;

namespace WorkTestTrello.Engine.Engines {
  /// <summary>
  /// Interface for the Board Controller Logic
  /// </summary>
  public interface IBoardEngine : IBaseEngine {
    /// <summary>
    /// Get a list of Trello Boards
    /// </summary>
    /// <returns></returns>
    OrganisationListViewModel GetBoards();

    /// <summary>
    /// Get a list of Trello Board Lists and Cards in each List
    /// </summary>
    /// <param name="submitModel"></param>
    /// <returns></returns>
    ListListViewModel GetBoardLists(BoardItemSubmitModel submitModel);

    /// <summary>
    /// Get the selected Trello card and the actions associated with this card
    /// </summary>
    /// <param name="submitModel"></param>
    /// <returns></returns>
    CardItemViewModel GetCardAndActions(CardItemSubmitModel submitModel);

    /// <summary>
    /// Post a comment for this card to Trello
    /// </summary>
    /// <param name="submitModel"></param>
    /// <returns></returns>
    string AddComment(CardActionSubmitModel submitModel);

    /// <summary>
    /// Get the Trello action
    /// </summary>
    /// <param name="submitModel"></param>
    /// <returns></returns>
    ActionItemViewModel GetAction(ActionItemSubmitModel submitModel);
  }
}