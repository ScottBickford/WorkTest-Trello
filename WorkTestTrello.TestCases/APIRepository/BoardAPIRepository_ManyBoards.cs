using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Data.APIModel;

namespace WorkTestTrello.TestCases.APIRepository {
  /// <summary>
  /// Test Case: Many Boards
  /// </summary>
  public class BoardAPIRepository_ManyBoards : BaseBoardAPIRepository {
    public override OrganisationListAPIModel GetOrganisations() {
      return new OrganisationListAPIModel {
        new OrganisationItemAPIModel {
          id = "1",
          desc = "Test 1",
          displayName = "Test 1",
          name = "Test 1",
          url = "url1"
        }, new OrganisationItemAPIModel {
          id = "2",
          desc = "Test 2",
          displayName = "Test 2",
          name = "Test 2",
          url = "url1"
        }
      };
    }

    public override BoardListAPIModel GetBoards() {
      var model = new BoardListAPIModel();
      for (int i = 1; i <= 100; i++) {
        model.Add(new BoardItemAPIModel {
          id = string.Format("12345678{0}", i),
          idOrganization = "1",
          name = "This is Test 1",
          closed = false,
          url = "url1",
          prefs = new BoardItemPrefsAPIModel {
            background = "green",
            backgroundColor = "green",
          }
        });
      }
      for (int i = 1; i <= 50; i++) {
        model.Add(new BoardItemAPIModel {
          id = string.Format("12345678{0}", i),          
          name = "This is Test 2",
          closed = false,
          url = "url1",
          prefs = new BoardItemPrefsAPIModel {
            background = "blue",
            backgroundColor = "blue",
          }
        });
      }
      return model;
    }
  }
}
