using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using WorkTestTrello.Engine.Models;
using WorkTestTrello.Data.APIRepository;

namespace WorkTestTrello.Engine.Engines {
  public class BoardEngine : BaseEngine, IBoardEngine {
    #region Properties
    protected IBoardAPIRepository Repository {
      get {
        return GetRepository<IBoardAPIRepository>();
      }      
    }
    #endregion

    #region GetBoards
    public OrganisationListViewModel GetBoards() {
      var organisationsApiModel = Repository.GetOrganisations();
      var boardsApiModel = Repository.GetBoards();

      var viewModel = new OrganisationListViewModel {
        Organisations = organisationsApiModel.Select(o => new OrganisationItemViewModel {          
          Name = o.displayName,
          Boards = boardsApiModel
            .Where(b => !b.closed && string.Compare(b.idOrganization, o.id) == 0)
            .Select(b => GetBoardItemModel(b)).OrderBy(b => b.Name).ToList()
        }).ToList()
      };

      // Insert the boards that didn't match an organisation, under a general organisation called Personal Boards
      var organisationIDs = organisationsApiModel.Select(o => o.id).ToList();
      var unassinedBoards = boardsApiModel.Where(b => !b.closed && !organisationIDs.Contains(b.idOrganization)).ToList();
      if (unassinedBoards.Count > 0) {
        viewModel.Organisations.Insert(0, new Models.OrganisationItemViewModel {
          Name = "Personal Boards",
          Boards = unassinedBoards
            .Select(b => GetBoardItemModel(b)).OrderBy(b => b.Name).ToList()
        });
      }

      return viewModel;
    }

    private BoardItemViewModel GetBoardItemModel(Data.APIModel.BoardItemAPIModel apiModel) {
      var model = new BoardItemViewModel {
        ID = apiModel.id,
        Name = apiModel.name,
        Description = apiModel.desc,
        BackgroundColor = apiModel.prefs != null ? apiModel.prefs.backgroundColor ?? apiModel.prefs.background ?? "silver" : "silver"
      };
      // Set the Foreground Color - if the background color is white, make the foreground color black, else make it white
      model.Color = (new string[] { "WHITE", "#FFFFFF" }).Contains(model.BackgroundColor.ToUpper()) ? "black" : "white";
      return model;
    }
    #endregion

    #region GetBoardLists
    public ListListViewModel GetBoardLists(BoardItemSubmitModel submitModel) {
      var boardApiModel = Repository.GetBoard(submitModel.ID);
      var listApiModel = Repository.GetLists(submitModel.ID);

      return new ListListViewModel {
        Board = GetBoardItemModel(boardApiModel),
        Lists = listApiModel.Select(l => new ListItemViewModel {
          ID = l.id,
          Name = l.name,
          Cards = l.cards.Select(c => new CardItemViewModel {
            ID = c.id,
            Name = c.name
          }).ToList()
        }).ToList()
      };
    }
    #endregion

    #region GetCardAndActions
    public CardItemViewModel GetCardAndActions(CardItemSubmitModel submitModel) {
      var cardApiModel = Repository.GetCard(submitModel.ID);
      var actionsApiModel = Repository.GetCardActions(submitModel.ID);

      return new CardItemViewModel {
        ID = cardApiModel.id,
        Name = cardApiModel.name,
        Actions = actionsApiModel
          .Where(a => string.Compare(a.type, "commentCard", true) == 0 && a.data != null && !string.IsNullOrEmpty(a.data.text))
          .Select(a => GetActionItemModel(a)).ToList()
      };
    }

    private ActionItemViewModel GetActionItemModel(Data.APIModel.ActionItemAPIModel apiModel) {
      var model = new ActionItemViewModel {
        Comment = apiModel.data != null ? apiModel.data.text : null,
        Date = apiModel.date,
        FullName = apiModel.memberCreator != null ? apiModel.memberCreator.fullName : null,
        Initials = apiModel.memberCreator != null ? apiModel.memberCreator.initials : null
      };
      model.Comment = HttpUtility.HtmlEncode(model.Comment).Replace("\r\n", "<br />").Replace("\r", "<br />").Replace("\n", "<br />");
      return model;
    }
    #endregion

    #region AddComment
    public string AddComment(CardActionSubmitModel submitModel) {
      var apiModel = Repository.PostAction(submitModel.ID, new Data.APIModel.PostActionAPIModel {
        text = submitModel.Comment
      });
      return apiModel.id;
    }

    public ActionItemViewModel GetAction(ActionItemSubmitModel submitModel) {
      var actionApiModel = Repository.GetAction(submitModel.ID);
      return GetActionItemModel(actionApiModel);
    }
    #endregion
  }
}
