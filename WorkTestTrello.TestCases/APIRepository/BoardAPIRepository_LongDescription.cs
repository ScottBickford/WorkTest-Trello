using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Data.APIModel;

namespace WorkTestTrello.TestCases.APIRepository {
  /// <summary>
  /// Test Case: Long description
  /// </summary>
  public class BoardAPIRepository_LongDescription : BaseBoardAPIRepository {
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
      var model = new BoardListAPIModel();
      for (int i = 1; i <= 10; i++) {
        model.Add(new BoardItemAPIModel {
          id = string.Format("12345678{0}", i),
          idOrganization = "1",
          name = "This is a long description and this is a long description and this is a long description and this is a long description and this is a long description and this is a long description and this is a long description",
          closed = false,
          url = "url1",
          prefs = new BoardItemPrefsAPIModel {
            background = "green",
            backgroundColor = "green",
          }
        });
      }
      return model;
    }
  }
}
