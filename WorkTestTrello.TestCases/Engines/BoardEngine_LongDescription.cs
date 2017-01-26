using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Engine.Models;

namespace WorkTestTrello.TestCases.Engines {
  public class BoardEngine_LongDescription : BaseBoardEngine {
    public override OrganisationListViewModel GetBoards() {
      string orgDescription = "This is a long description for Organisation and this is a long description for Organisation and this is a long description for Organisation. This is a long description for Organisation and this is a long description for Organisation and this is a long description for Organisation";
      string boardDescription = "This is a long description for a Board and this is a long description for a Board and this is a long description for a Board. This is a long description for a Board and this is a long description for a Board and this is a long description for a Board.";

      return new OrganisationListViewModel {
        Organisations = new List<OrganisationItemViewModel> {
          new OrganisationItemViewModel {
            ID = 1.ToString(),
            Name = orgDescription,
            Boards = new List<BoardItemViewModel> {
              new BoardItemViewModel {
                ID = 1.ToString(),
                Name = boardDescription,
                BackgroundColor = "green",
                Color = "white",
                Description = boardDescription
              }
            }
          }
        }
      };
    }
  }
}