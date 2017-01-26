using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestTrello.Data.APIModel {
  public class MemberItemAPIModel : BaseAPIModel {
    public string username { get; set; }
    public string fullName { get; set; }
    public string url { get; set; }
  }
}
