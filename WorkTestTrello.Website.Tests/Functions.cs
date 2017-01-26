using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Engine;

namespace WorkTestTrello.Website.Tests {
  internal class Functions {
    internal static void SetAuthentication() {
      Authentication.Set(new Authentication.TrelloUser { Token = Constants.Token, Username = "test", FullName = "Test" });
    }
  }
}
