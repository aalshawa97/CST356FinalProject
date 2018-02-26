using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST356FinalProject.Models.View
{
  public class UserAccountViewModel
  {
    public int Id { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [Display(Name = "User Name")]
    public string Username { get; set; }

    [Required]
    [Display(Name = "Password")]
    public string Password { get; set; }
  }
}