using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Data.APIModel;

namespace WorkTestTrello.Data.APIRepository {
  /// <summary>
  /// Interface for getting Board information from the Trello Api
  /// </summary>
  public interface IBoardAPIRepository : IBaseAPIRepository {
    /// <summary>
    /// Get a list of Organisations for the logged in user
    /// </summary>
    /// <returns></returns>
    OrganisationListAPIModel GetOrganisations();

    /// <summary>
    /// Get the Boards for the logged in user
    /// </summary>
    /// <returns></returns>
    BoardListAPIModel GetBoards();

    /// <summary>
    /// Get a specific Board
    /// </summary>
    /// <param name="boardID">The id of the Board</param>
    /// <returns></returns>
    BoardItemAPIModel GetBoard(string boardID);

    /// <summary>
    /// Get the Lists for a specific Board
    /// </summary>
    /// <param name="boardID">The id of the Board</param>
    /// <returns></returns>
    ListListAPIModel GetLists(string boardID);

    /// <summary>
    /// Get the Card Details for a specific Card
    /// </summary>
    /// <param name="cardID">The id of the Card</param>
    /// <returns></returns>
    CardItemAPIModel GetCard(string cardID);

    /// <summary>
    /// Get the Actions for a specific Card
    /// </summary>
    /// <param name="cardID">The id of the Card</param>
    /// <returns></returns>
    ActionListAPIModel GetCardActions(string cardID);

    /// <summary>
    /// Get the Action details for a specific Action
    /// </summary>
    /// <param name="actionID">The id of the Action</param>
    /// <returns></returns>
    ActionItemAPIModel GetAction(string actionID);

    /// <summary>
    /// Post a comment to Trello for a card
    /// </summary>
    /// <param name="cardID">The id of the Card</param>
    /// <param name="postAPIModel">The model containing the comment information</param>
    /// <returns>The model containing the Action Details of the comment after posting</returns>
    ActionItemAPIModel PostAction(string cardID, PostActionAPIModel postAPIModel);
  }
}