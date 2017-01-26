using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestTrello.Data.APIRepository {
  /// <summary>
  /// The Base Interface for Repositories
  /// </summary>
  public interface IBaseAPIRepository {
    /// <summary>
    /// The Token given to us by Trello
    /// </summary>
    string Token { get; set; }
  }
}
