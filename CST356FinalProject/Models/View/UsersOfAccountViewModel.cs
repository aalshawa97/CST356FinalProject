using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST356FinalProject.Models.View
{
  public class UsersOfAccountViewModel
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Account User's Name")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Birthday")]
    public DateTime Birthday { get; set; }

    public int UserId { get; set; }
  }
}