using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CST356FinalProject.Models;

namespace CST356FinalProject.Data.Entities
{
  public class BankAccount
  {
    [Key, Required]
    public int Id { get; set; }

    public string AccountNumber { get; set; }

    public int UserId { get; set; }

    public UserAccount User { get; set; }

    public string AccountType { get; set; }
  }
}