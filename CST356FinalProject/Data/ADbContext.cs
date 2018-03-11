using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CST356FinalProject.Data.Entities;

namespace CST356FinalProject.Models
{
  public class ADbContext : DbContext
  {
    public ADbContext()
    {
      this.Configuration.LazyLoadingEnabled = false;

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      Database.SetInitializer(new AppDbInitializer());
    }

    public  virtual DbSet<UserAccount> UserAccounts { get; set; }
    public virtual DbSet<BankAccount> BankAccounts { get; set; }
    public virtual DbSet<UsersOfAccount> UsersOfAccounts { get; set; }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ADbContext>
    {

    }
  }
}