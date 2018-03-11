using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CST356FinalProject.Data.Entities;
using CST356FinalProject.Models;
using CST356FinalProject.Models.View;
using Microsoft.AspNet.Identity;

namespace CST356FinalProject.Controllers
{
    public class BankAccountController : Controller
    {
      //List the bank accounts associated with the user
      public ActionResult List()
      {
        var userId = Session["Username"].ToString();
        ViewBag.UserId = userId;
        int userIdInteger;
         int.TryParse(userId,out userIdInteger);
        var bankAccounts = GetBankAccountsForUser(userIdInteger);

        return View(bankAccounts);
      }

      private ICollection<BankAccountViewModel> GetBankAccountsForUser(int userId)
      {
        var bankAccountViewModels = new List<BankAccountViewModel>();

        var dbContext = new ADbContext();

        var bankAccounts = dbContext.BankAccounts.Where(userAccount => userAccount.UserId == userId).ToList();

        foreach (var bankAccount in bankAccounts)
        {
          var bankAccountViewModel = MapToBankAccountViewModel(bankAccount);
          //bankAccountViewModels.Add(bankAccountViewModel);
        }
        return bankAccountViewModels;
      }
      private BankAccount MapToBankAccount(BankAccountViewModel bankAccountViewModel)
      {
        return new BankAccount
        {
          Id = bankAccountViewModel.Id,
          AccountNumber = bankAccountViewModel.AccountNumber,
          UserId = bankAccountViewModel.UserId,
          AccountType = bankAccountViewModel.AccountType,
        };
      }

      private BankAccountViewModel MapToBankAccountViewModel(BankAccount bankAccount)
      { 
        return new BankAccountViewModel
        {
          Id = bankAccount.Id,
          AccountNumber = bankAccount.AccountNumber,
          UserId = bankAccount.UserId,
          AccountType = bankAccount.AccountType,
        };
      }

      [HttpGet]
      public ActionResult Create(int userId)
      {
        try
        {
          ViewBag.UserId = userId;
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
          throw;
        }

        return View();
      }

      [HttpPost]
      public ActionResult Create(BankAccountViewModel bankAccountViewModel)
      {
        try
        {
          if (ModelState.IsValid)
          {
            Save(bankAccountViewModel);
            return RedirectToAction("List", new { bankAccountViewModel.UserId });
          }
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
          throw;
        }

        return View();
      }

      [HttpGet]
      public ActionResult Edit(int id)
      {
        var bankAccount = GetBankAccount(id);

        return View(bankAccount);
      }

      private BankAccountViewModel GetBankAccount(int bankAccountId)
      {
        var dbContext = new ADbContext();

        var bankAccount = dbContext.BankAccounts.Find(bankAccountId);

        return MapToBankAccountViewModel(bankAccount);
      }

      private void Save(BankAccountViewModel bankAccountViewModel)
      {
        var dbContext = new ADbContext();

        var bankAccount = MapToBankAccount(bankAccountViewModel);

        dbContext.BankAccounts.Add(bankAccount);

        dbContext.SaveChanges();
      }



      [HttpPost]
      public ActionResult Edit(BankAccountViewModel bankAccountViewModel)
      {
        bankAccountViewModel.UserId = GetBankAccount(bankAccountViewModel.Id).UserId;

        if (ModelState.IsValid)
        {
          UpdateBankAccount(bankAccountViewModel);

          return RedirectToAction("List", new { bankAccountViewModel.UserId });
        }

        return View();
      }

      private void UpdateBankAccount (BankAccountViewModel bankAccountViewModel)
      {
        var dbContext = new ADbContext();

        var bankAccount = dbContext.BankAccounts.Find(bankAccountViewModel.Id);

        CopyToBankAccount(bankAccountViewModel, bankAccount);

        dbContext.SaveChanges();
      }

      private void CopyToBankAccount(BankAccountViewModel bankAccountViewModel, BankAccount bankAccount)
      {
        bankAccount.AccountNumber = bankAccountViewModel.AccountNumber;
        bankAccount.AccountNumber = bankAccountViewModel.AccountNumber;
        bankAccount.AccountType = bankAccountViewModel.AccountType;
      }

      public ActionResult Details(int id)
      {
        var bankAccount = GetBankAccount(id);

        return View(bankAccount);
      }

      public ActionResult Delete(int id)
      {
        var bankAccount = GetBankAccount(id);

        DeleteBankAccount(id);

        return RedirectToAction("List", new { UserId = bankAccount.UserId });
      }
      private void DeleteBankAccount(int id)
      {
        var dbContext = new ADbContext();

        var bankAccount = dbContext.BankAccounts.Find(id);

        if (bankAccount != null)
        {
          dbContext.BankAccounts.Remove(bankAccount);
          dbContext.SaveChanges();
        }
      }
  }
}