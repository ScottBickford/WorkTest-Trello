using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestTrello.Engine.Models {
  public class BoardItemViewModel : BaseViewModel {
    public string Description { get; set; }
    public string BackgroundColor { get; set; }
    public string Color { get; set; }
  }

  public class BoardItemSubmitModel {
    public string ID { get; set; }
  }
}
