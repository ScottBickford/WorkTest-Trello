using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace WorkTestTrello.Engine.Engines {
  /// <summary>
  /// The Base Interface for engines
  /// </summary>
  public interface IBaseEngine {
    /// <summary>
    /// Initilise the Engine and pass through the Unity Container for resolving dependancies
    /// </summary>
    /// <param name="container"></param>
    void Initialise(IUnityContainer container);
  }
}