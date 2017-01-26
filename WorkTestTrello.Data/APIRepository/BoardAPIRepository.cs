using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Data.APIModel;

namespace WorkTestTrello.Data.APIRepository {
  public class BoardAPIRepository : BaseAPIRepository, IBoardAPIRepository {
    public OrganisationListAPIModel GetOrganisations() {
      return Get<OrganisationListAPIModel>(string.Format("1/members/me/organizations?key={0}&token={1}", c_application_key, c_auth_token));
    }

    public BoardListAPIModel GetBoards() {
      return Get<BoardListAPIModel>(string.Format("1/members/me/boards?key={0}&token={1}", c_application_key, c_auth_token));
    }

    public BoardItemAPIModel GetBoard(string boardID) {
      return Get<BoardItemAPIModel>(string.Format("1/boards/{0}?key={1}&token={2}", boardID, c_application_key, c_auth_token));
    }

    public ListListAPIModel GetLists(string boardID) {
      return Get<ListListAPIModel>(string.Format("1/boards/{0}/lists?cards=open&card_fields=name&fields=name&key={1}&token={2}", boardID, c_application_key, c_auth_token));
    }

    public CardItemAPIModel GetCard(string cardID) {
      return Get<CardItemAPIModel>(string.Format("1/cards/{0}?fields=name&key={1}&token={2}", cardID, c_application_key, c_auth_token));
    }

    public ActionListAPIModel GetCardActions(string cardID) {
      return Get<ActionListAPIModel>(string.Format("1/cards/{0}/actions?key={1}&token={2}", cardID, c_application_key, c_auth_token));
    }

    public ActionItemAPIModel GetAction(string actionID) {
      return Get<ActionItemAPIModel>(string.Format("1/actions/{0}?key={1}&token={2}", actionID, c_application_key, c_auth_token));
    }

    public ActionItemAPIModel PostAction(string cardID, PostActionAPIModel postAPIModel) {
      return Post<PostActionAPIModel, ActionItemAPIModel>(string.Format("1/cards/{0}/actions/comments?key={1}&token={2}", cardID, c_application_key, c_auth_token), postAPIModel);
    }
  }
}
