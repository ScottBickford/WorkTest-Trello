using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Data.APIModel;
using WorkTestTrello.Data.APIRepository;

namespace WorkTestTrello.TestCases.APIRepository {
  /// <summary>
  /// Base class for test cases - inherit from this class and only override the functions you want to test
  /// </summary>
  public abstract class BaseBoardAPIRepository : IBoardAPIRepository {
    public string Token { get; set; }
    public virtual OrganisationListAPIModel GetOrganisations() {
      return new OrganisationListAPIModel();
    }

    public virtual BoardListAPIModel GetBoards() {
      return new BoardListAPIModel();
    }

    public virtual BoardItemAPIModel GetBoard(string boardID) {
      return new BoardItemAPIModel();
    }

    public virtual ListListAPIModel GetLists(string boardID) {
      return new ListListAPIModel();
    }

    public virtual CardItemAPIModel GetCard(string cardID) {
      return new CardItemAPIModel();
    }

    public virtual ActionListAPIModel GetCardActions(string cardID) {
      return new ActionListAPIModel();
    }

    public virtual ActionItemAPIModel PostAction(string cardID, PostActionAPIModel postAPIModel) {
      return new ActionItemAPIModel { id = 1.ToString() };
    }

    public virtual ActionItemAPIModel GetAction(string actionID) {
      return new ActionItemAPIModel();
    }
  }
}
