using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WorkTestTrello.Engine.Models {
  public class CardItemViewModel : BaseViewModel {
    [Required]
    [Display(Name = "Comment")]
    public string Comment { get; set; }
    public List<ActionItemViewModel> Actions { get; set; }
  }

  public class CardItemSubmitModel {
    [Required]
    [Display(Name = "Card ID")]
    public string ID { get; set; }
  }

  public class CardActionSubmitModel {
    [Required]
    [Display(Name = "Card ID")]
    public string ID { get; set; }

    [Required]
    [Display(Name = "Comment")]
    [StringLength(16384, ErrorMessage = "Your comment cannot be longer than 16 384 characters.")]
    public string Comment { get; set; }
  }
}
