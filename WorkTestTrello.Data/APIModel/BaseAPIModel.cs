using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestTrello.Data.APIModel {
  public abstract class BaseAPIModel {
    public string id { get; set; }
    public string name { get; set; }
  }

  public abstract class BaseListAPIModel<T> : List<T> {
    public string id { get; set; }
    public string name { get; set; }
  }
}
