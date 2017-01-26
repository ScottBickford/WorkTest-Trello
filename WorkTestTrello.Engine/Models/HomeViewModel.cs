using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WorkTestTrello.Engine.Models {
  public class HomeViewModel {
    public string TrelloDeveloperKey { get; set; }
  }

  public class AuthoriseSubmitModel {
    [Required]
    [Display(Name = "Trello Authentication Token")]
    public string Token { get; set; }
  }
}
