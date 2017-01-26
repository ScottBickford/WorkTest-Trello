using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;
using WorkTestTrello.Engine.Models;
using WorkTestTrello.Data.APIModel;

namespace WorkTestTrello.Engine {
  public class Authentication {
    public const string c_session_trellouser = "TrelloUser";

    public class TrelloUser {
      public string Token;
      public string Username;
      public string FullName;
    }

    private static TrelloUser nonHTMLUser; // To keep a variable if HttpContext is null (for testing)

    /// <summary>
    /// Retrive the Trello variables in the Session
    /// </summary>
    public static TrelloUser Current {
      get {
        if (HttpContext.Current == null) {
          // For testing purposes - get a static variable
          return nonHTMLUser;
        }
        return HttpContext.Current.Session[c_session_trellouser] as TrelloUser;
      }
    }

    /// <summary>
    /// Store the Trello variables in the Session (it's only 3 fields so therefore quite small to store in memory)
    /// </summary>
    /// <param name="model"></param>
    /// <param name="apiModel"></param>
    public static void Set(AuthoriseSubmitModel model, MemberItemAPIModel apiModel) {
      Set(new TrelloUser {
        Token = model.Token,
        Username = apiModel.username,
        FullName = apiModel.fullName
      });
    }

    /// <summary>
    /// Store the Trello variables in the Session (it's only 3 fields so therefore quite small to store in memory)
    /// </summary>
    /// <param name="trelloUser"></param>
    public static void Set(TrelloUser trelloUser) {
      if (HttpContext.Current != null) {
        HttpContext.Current.Session[c_session_trellouser] = trelloUser;
      } else {
        // For testing purposes - set a static variable
        nonHTMLUser = trelloUser;
      }
    }

    /// <summary>
    /// Check if the user is logged in
    /// </summary>
    /// <returns></returns>
    public static bool IsLoggedIn() {
      return Current != null;
    }

    /// <summary>
    /// Get the full name of the User if logged in
    /// </summary>
    /// <returns></returns>
    public static string GetFullName() {
      return IsLoggedIn() ? Current.FullName : string.Empty;
    }
  }
}