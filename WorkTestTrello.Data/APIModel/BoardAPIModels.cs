using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestTrello.Data.APIModel {
  public class BoardListAPIModel : List<BoardItemAPIModel> {
  }

  public class BoardItemAPIModel : BaseAPIModel {
    public string desc { get; set; }
    public bool closed { get; set; }
    public string url { get; set; }
    public string idOrganization { get; set; }
    public BoardItemPrefsAPIModel prefs { get; set; }
  }

  public class BoardItemPrefsAPIModel {
    public string permissionLevel { get; set; }
    public string comments { get; set; }
    public string background { get; set; }
    public string backgroundColor { get; set; }
    public bool canBePublic { get; set; }
    public bool canBeOrg { get; set; }
    public bool canBePrivate { get; set; }
    public bool canInvite { get; set; }
  }
}
