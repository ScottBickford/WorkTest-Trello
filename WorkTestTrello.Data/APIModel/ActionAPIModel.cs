using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestTrello.Data.APIModel {
  public class ActionListAPIModel : List<ActionItemAPIModel> {
  }

  public class ActionItemAPIModel : BaseAPIModel {
    public string idMemberCreator { get; set; }    
    public ActionItemDataAPIModel data { get; set; }
    public string type { get; set; }
    public string date { get; set; }
    public ActionItemMemberCreatorAPIModel memberCreator { get; set; }
  }

  public class ActionItemDataAPIModel {
    public string text { get; set; }
  }

  public class ActionItemMemberCreatorAPIModel {
    public string id { get; set; }
    public string avatarHash { get; set; }
    public string fullName { get; set; }
    public string initials { get; set; }
    public string username { get; set; }
  }

  public class PostActionAPIModel {
    public string text { get; set; }
  }
}
