using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestTrello.Data.APIModel {
  public class ListListAPIModel : List<ListItemAPIModel> {
  }

  public class ListItemAPIModel : BaseAPIModel {
    public List<CardItemAPIModel> cards { get; set; }
  }

  public class CardListAPIModel : List<CardItemAPIModel> {
  }

  public class CardItemAPIModel : BaseAPIModel {
    public string idList { get; set; }    
    public string url { get; set; }    
  }
}
