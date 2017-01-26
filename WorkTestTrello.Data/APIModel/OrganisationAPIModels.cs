using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestTrello.Data.APIModel {
  public class OrganisationListAPIModel : List<OrganisationItemAPIModel> {
  }

  public class OrganisationItemAPIModel : BaseAPIModel {
    public string displayName { get; set; }
    public string desc { get; set; }
    public string url { get; set; }
  }
}
