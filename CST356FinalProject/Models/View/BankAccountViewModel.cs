using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST356FinalProject.Models.View
{
  public class BankAccountViewModel
  {
    public int Id { get; set; }

    public int UserId { get; set; }

    [Required]
    [Display(Name = "Account Number")]
    public string AccountNumber { get; set; }

    [Required]
    [Display(Name = "Account Type")]
    public string AccountType { get; set; }
  }
}