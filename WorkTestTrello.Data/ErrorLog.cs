//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkTestTrello.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ErrorLog
    {
        public int ErrorLogID { get; set; }
        public string AppCode { get; set; }
        public string AppVersion { get; set; }
        public string ErrorDescription { get; set; }
        public string StackTrace { get; set; }
        public string SourceName { get; set; }
        public string ExceptionType { get; set; }
        public string IPAddress { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string UserAgent { get; set; }
        public string UserHostAddress { get; set; }
        public string UserHostName { get; set; }
        public string CreatedByUser { get; set; }
        public System.DateTime CreatedOnDate { get; set; }
    }
}