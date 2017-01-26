using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.IO;

namespace WorkTestTrello.Data.APIRepository {
  /// <summary>
  /// The Base API Repository
  /// </summary>
  public abstract class BaseAPIRepository : IBaseAPIRepository {
    protected const string c_application_key = "[application_key]";
    protected const string c_auth_token = "[auth_token]";

    public string Token { get; set; }

    /// <summary>
    /// Get from Trello API
    /// </summary>
    /// <typeparam name="Out">The Type of output Model from the Api Call</typeparam>
    /// <param name="url">The suffix URL</param>
    /// <returns>The Api result</returns>
    protected Out Get<Out>(string url) {
      Uri request = new Uri(string.Format("https://api.trello.com/{0}", url).Replace(c_application_key, Constants.c_TrelloDeveloperKey).Replace(c_auth_token, Token));

      using (WebClient wc = new WebClient()) {
        var data = wc.DownloadData(request);
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Out));
        using (Stream stream = new MemoryStream(data)) {
          stream.Position = 0;
          return (Out)ser.ReadObject(stream);
        }
      }
    }

    /// <summary>
    /// Post to Trello API
    /// </summary>
    /// <typeparam name="In">The Type of Model to serialize to Json to Post</typeparam>
    /// <typeparam name="Out">The Type of output Model from the Api Call</typeparam>
    /// <param name="url">The suffix URL</param>
    /// <param name="apiModel">The Model to serialize to Json to Post</param>
    /// <returns>The Api result</returns>
    protected Out Post<In, Out>(string url, In apiModel) {
      string fullurl = string.Format("https://api.trello.com/{0}", url).Replace(c_application_key, Constants.c_TrelloDeveloperKey).Replace(c_auth_token, Token);
      var req = WebRequest.Create(fullurl);
      var enc = new UTF8Encoding(false);
      var json = new JavaScriptSerializer().Serialize(apiModel);

      var data = enc.GetBytes(json);

      req.Method = "POST";
      req.ContentType = "application/json";
      req.ContentLength = data.Length;

      using (var sr = req.GetRequestStream()) {
        sr.Write(data, 0, data.Length);
      }
      var res = req.GetResponse();

      DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Out));
      using (Stream stream = res.GetResponseStream()) {
        return (Out)ser.ReadObject(stream);
      }
    }
  }
}