using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using WorkTestTrello.Data.APIRepository;

namespace WorkTestTrello.Engine.Engines {
  /// <summary>
  /// The Base Engine
  /// </summary>
  public abstract class BaseEngine : IBaseEngine {
    /// <summary>
    /// The Unity Container to resolve dependancies
    /// </summary>
    protected IUnityContainer Container;

    public void Initialise(IUnityContainer container) {
      Container = container;
    }

    private IBaseAPIRepository repository;
    /// <summary>
    /// Create (if needed) and return a the Repository Class based on the interface type associated with this Property.
    /// </summary>
    /// <typeparam name="T">The interface type to resolve</typeparam>
    /// <returns>The Resolved Repository</returns>
    protected T GetRepository<T>() where T: IBaseAPIRepository {
      if (repository == null) {
        repository = (T)Container.Resolve(typeof(T));
        repository.Token = Authentication.Current != null ? Authentication.Current.Token : null;
      }
      return (T)repository;
    }
  }
}