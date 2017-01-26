using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestTrello.Engine.Models {
  public class ActionItemViewModel {
    public string Comment { get; set; }
    public string Date { get; set; }
    public string FullName { get; set; }
    public string Initials { get; set; }
  }

  public class ActionItemSubmitModel {
    public string ID { get; set; }
  }
}
