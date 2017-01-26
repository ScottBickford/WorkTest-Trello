using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorkTestTrello.Website.Startup))]
namespace WorkTestTrello.Website {
  public partial class Startup {
    public void Configuration(IAppBuilder app) {
      ConfigureAuth(app);      
    }
  }
}