using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Data.APIModel;

namespace WorkTestTrello.TestCases.APIRepository {
  /// <summary>
  /// Test Case: Many Cards
  /// </summary>
  public class BoardAPIRepository_ManyCards : BaseBoardAPIRepository {
    public override OrganisationListAPIModel GetOrganisations() {
      return new OrganisationListAPIModel {
        new OrganisationItemAPIModel {
          id = "1",
          desc = "Test 1",
          displayName = "Test 1",
          name = "Test 1",
          url = "url1"
        }
      };
    }

    public override BoardListAPIModel GetBoards() {
      return new BoardListAPIModel {
        new BoardItemAPIModel {
          id = "12345678",
          idOrganization = "1",
          name = "This is Test 1",
          closed = false,
          url = "url1",
          prefs = new BoardItemPrefsAPIModel {
            background = "green",
            backgroundColor = "green",
          }
        }
      };
    }

    public override ListListAPIModel GetLists(string boardID) {
      var model = new ListListAPIModel();
      for (int i = 1; i <= 100; i++) {
        var listItem = new ListItemAPIModel {
          id = i.ToString(),
          name = string.Format("Test List {0}", i),
          cards = new List<CardItemAPIModel>()
        };
        for (int c = 1; c <= 100; c++) {
          listItem.cards.Add(new CardItemAPIModel {
            id = c.ToString(),
            name = string.Format("Test Card {0}", c),
            idList = i.ToString(),
            url = "url"
          });
        }
        model.Add(listItem);
      }
      return model;
    }
  }
}