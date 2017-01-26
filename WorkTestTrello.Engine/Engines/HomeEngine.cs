using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Engine.Models;
using WorkTestTrello.Data.APIRepository;

namespace WorkTestTrello.Engine.Engines {
  public class HomeEngine : BaseEngine, IHomeEngine {
    #region Properties
    protected IMemberAPIRepository Repository {
      get {
        return GetRepository<IMemberAPIRepository>();
      }
    }
    #endregion

    #region GetHomeViewModel
    public HomeViewModel GetHomeViewModel() {
      return new Models.HomeViewModel {
        TrelloDeveloperKey = Data.Constants.c_TrelloDeveloperKey
      };
    }
    #endregion

    #region Authorise
    public void Authorise(AuthoriseSubmitModel model) {
      Repository.Token = model.Token;
      var apiModel = Repository.GetMember();
      Authentication.Set(model, apiModel);
    }
    #endregion
  }
}
