using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CST356FinalProject.Models
{
  public class ADbContext : DbContext
  {
    public DbSet<UserAccount> UserAccounts { get; set ;}
  }
}