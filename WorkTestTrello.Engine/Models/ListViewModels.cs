using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTestTrello.Engine.Models {
  public class ListListViewModel {
    public BoardItemViewModel Board { get; set; }
    public List<ListItemViewModel> Lists { get; set; }
  }

  public class ListItemViewModel : BaseViewModel {
    public List<CardItemViewModel> Cards { get; set; }
  }
}
