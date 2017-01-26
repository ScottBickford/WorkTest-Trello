using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Engine.Models;

namespace WorkTestTrello.TestCases.Engines {
  /// <summary>
  /// Test Case: Many Boards
  /// </summary>
  public class BoardEngine_ManyBoards : BaseBoardEngine {
    public override OrganisationListViewModel GetBoards() {
      var model = new OrganisationListViewModel { Organisations = new List<OrganisationItemViewModel>() };
      for (int i = 1; i <= 10; i++) {
        var org = new OrganisationItemViewModel {
          ID = i.ToString(),
          Name = string.Format("Organisation {0}", i),
          Boards = new List<BoardItemViewModel>()
        };
        for (int b = 1; b <= 100; b++) {
          org.Boards.Add(new BoardItemViewModel {
            ID = b.ToString(),
            Name = string.Format("Board {0}", b),
            BackgroundColor = "lightblue",
            Color = "white",
            Description = string.Format("Board {0}", b)
          });
        }
        model.Organisations.Add(org);
      }
      return model;
    }
  }
}
