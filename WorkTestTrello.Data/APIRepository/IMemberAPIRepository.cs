using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Data.APIModel;

namespace WorkTestTrello.Data.APIRepository {
  /// <summary>
  /// Interface for getting Member information from the Trello Api
  /// </summary>
  public interface IMemberAPIRepository : IBaseAPIRepository {
    /// <summary>
    /// Get the current member information
    /// </summary>
    /// <returns></returns>
    MemberItemAPIModel GetMember();
  }
}
