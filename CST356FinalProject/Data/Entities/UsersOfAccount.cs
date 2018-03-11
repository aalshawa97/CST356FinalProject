using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CST356FinalProject.Models;

namespace CST356FinalProject.Data.Entities
{
  public class UsersOfAccount
  {
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime Birthday { get; set; }

    public int UserId { get; set; }
    public UserAccount UserAccount { get; set; }
  }
}