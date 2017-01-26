using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestTrello.Engine.Models {
  public class JsonResultModel {
    public string Value { get; set; }
    public bool ErrorOccurred { get; set; }
    public string ErrorDescription { get; set; }
  }
}
