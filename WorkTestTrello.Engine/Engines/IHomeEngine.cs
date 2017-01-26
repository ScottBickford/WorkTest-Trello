using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Engine.Models;

namespace WorkTestTrello.Engine.Engines {
  /// <summary>
  /// Interface for the Home Controller Logic
  /// </summary>
  public interface IHomeEngine : IBaseEngine {
    /// <summary>
    /// Get the home index page model
    /// </summary>
    /// <returns></returns>
    HomeViewModel GetHomeViewModel();

    /// <summary>
    /// The user has been authorised against Trello, store the credentials
    /// </summary>
    /// <param name="submitModel">The information to process</param>
    void Authorise(AuthoriseSubmitModel submitModel);
  }
}
