using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestTrello.Engine.Models {
  public class OrganisationListViewModel {
    public List<OrganisationItemViewModel> Organisations { get; set; }
  }

  public class OrganisationItemViewModel : BaseViewModel {
    public List<BoardItemViewModel> Boards { get; set; }
  }
}
