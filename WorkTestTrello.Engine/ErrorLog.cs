using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity.Validation;
using System.Diagnostics;

using WorkTestTrello.Data;

namespace WorkTestTrello.Engine {
  public class ErrorLog {
    private string ErrorDescription = "";
    private string StackTrace = "";
    private string Source = "";

    /// <summary>
    /// Writes to the ErrorLog table in the DB
    /// </summary>
    /// <param name="exception">The exception raised</param>
    /// <param name="createdByUser">The current logged in user</param>
    /// <param name="appCode">A code to identify the process</param>
    /// <param name="appVersion">The version of the dll</param>
    /// <param name="controllerName">The originating controller that threw the exception (if any)</param>
    /// <param name="actionName">The originating action that threw the exception (if any)</param>
    /// <returns></returns>
    public static int? Log(Exception exception, string createdByUser, string appCode, string appVersion, string controllerName = null, string actionName = null) {
      try {
        var entities = new WorkTestTrelloEntities();
        using (entities) {
          ErrorLog er = new ErrorLog(exception);

          HttpRequest oHttpRequest = null;
          if (HttpContext.Current != null) { oHttpRequest = HttpContext.Current.Request; ; }
          string sUserAgent = string.Empty;
          string sUserHostAddress = string.Empty;
          string sUserHostName = string.Empty;

          if (oHttpRequest != null) {
            sUserAgent = oHttpRequest.UserAgent;
            sUserHostAddress = oHttpRequest.UserHostAddress;
            sUserHostName = oHttpRequest.UserHostName;
          }

          var errorLog = new Data.ErrorLog {
            AppCode = appCode,
            AppVersion = appVersion,
            ErrorDescription = er.ErrorDescription,
            StackTrace = er.StackTrace,
            SourceName = er.Source,
            ExceptionType = exception.GetType().ToString(),
            IPAddress = GetIPAddress(),
            ControllerName = controllerName,
            ActionName = actionName,
            UserAgent = sUserAgent,
            UserHostAddress = sUserHostAddress,
            UserHostName = sUserHostName,
            CreatedByUser = createdByUser,
            CreatedOnDate = DateTime.Now
          };

          entities.ErrorLogs.Add(errorLog);
          entities.SaveChanges();

          return errorLog.ErrorLogID;
        }
      } catch (Exception ex) {
        // Write to the event log instead
        LogToEventLog("Writing to the error log failed - " + ex.Message, EventLogEntryType.Error);
        return null;
      }
    }

    private static string GetIPAddress() {
      try {
        return System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0].ToString();
      } catch {
        return "127.0.0.1";
      }
    }

    private ErrorLog(Exception Exception) {
      AddExceptionDetails(Exception, false);
    }

    private void AddExceptionDetails(Exception Exception, bool isInnerException) {
      if (isInnerException) {
        ErrorDescription += "\r\nInner Exception\r\n";
        StackTrace += "\r\nInner Exception\r\n";
        Source += "\r\nInner Exception\r\n";
      }
      ErrorDescription += Exception.Message;
      StackTrace += Exception.StackTrace;
      Source += Exception.Source;
      var dbException = Exception as DbEntityValidationException;
      if (dbException != null) {
        if (dbException.EntityValidationErrors != null) {
          StringBuilder validationErrors = new StringBuilder();
          foreach (var entityValidationError in dbException.EntityValidationErrors) {
            foreach (var validationError in entityValidationError.ValidationErrors) {
              validationErrors.AppendLine(string.Format("{0} - {1}", validationError.PropertyName, validationError.ErrorMessage));
            }
          }
          ErrorDescription += string.Format("\r\nEntity Validation Errors\r\n{0}", validationErrors.ToString());
        }
      }
      if (Exception.InnerException != null) {
        AddExceptionDetails(Exception.InnerException, true);
      }
    }

    private static void LogToEventLog(string message, EventLogEntryType eventLogEntryType) {
      try {
        string source = "Work Test Trello";
        string log = "Application";

        if (!EventLog.SourceExists(source))
          EventLog.CreateEventSource(source, log);

        EventLog.WriteEntry(source, message, eventLogEntryType);
      } catch { } // Couldnt write to the event log
    }
  }
}