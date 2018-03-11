using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CST356FinalProject.Data.Entities;
using CST356FinalProject.Models;
using CST356FinalProject.Models.View;

namespace CST356FinalProject.Controllers
{
  public class UsersOfAccountController : Controller
  {
    public ActionResult List(int userId)
    {
      ViewBag.UserId = userId;

      var usersOfAccount = GetUsersOfAccountForUser(userId);

      return View(usersOfAccount);
    }

    [HttpGet]
    public ActionResult Create(int userId)
    {
      ViewBag.UserId = userId;

      return View();
    }

    [HttpPost]
    public ActionResult Create(UsersOfAccountViewModel usersOfAccountViewModel)
    {
      if (ModelState.IsValid)
      {
        Save(usersOfAccountViewModel);
        return RedirectToAction("List", new { UserId = usersOfAccountViewModel.UserId });
      }

      return View();
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
      var usersOfAccountViewModel = GetUsersOfAccount(id);

      return View(usersOfAccountViewModel);
    }

    [HttpPost]
    public ActionResult Edit(UsersOfAccountViewModel usersOfAccountViewModel)
    {
      if (ModelState.IsValid)
      {
        UpdateUsersOfAccount(usersOfAccountViewModel);

        return RedirectToAction("List");
      }

      return View();
    }

    public ActionResult Delete(int id)
    {
      var usersOfAccountViewModel = GetUsersOfAccount(id);

      DeleteUsersOfAccount(id);

      return RedirectToAction("List", new { UserId = usersOfAccountViewModel.UserId });
    }

    private UsersOfAccount GetUsersOfAccount(int UsersOfAccountId)
    {
      var dbContext = new ADbContext();

      return dbContext.UsersOfAccounts.Find(UsersOfAccountId);
    }

    private ICollection<UsersOfAccountViewModel> GetUsersOfAccountForUser(int userId)
    {
      var usersOfAccountViewModels = new List<UsersOfAccountViewModel>();

      var dbContext = new ADbContext();

      var usersOfAccounts = dbContext.UsersOfAccounts.Where(usersOfAccount => usersOfAccount.UserId == userId).ToList();

      foreach (var usersOfAccount in usersOfAccounts)
      {
        var usersOfAccountViewModel = MapToUsersOfAccountViewModel(usersOfAccount);
        usersOfAccountViewModels.Add(usersOfAccountViewModel);
      }

      return usersOfAccountViewModels;
    }

    private void Save(UsersOfAccountViewModel usersOfAccountViewModel)
    {
      var dbContext = new ADbContext();

      var userOfAccount = MapToUsersOfAccount(usersOfAccountViewModel);

      dbContext.UsersOfAccounts.Add(userOfAccount);

      dbContext.SaveChanges();
    }

    private void UpdateUsersOfAccount(UsersOfAccountViewModel usersOfAccountViewModel)
    {
      var dbContext = new ADbContext();

      var usersOfAccount = dbContext.UsersOfAccounts.Find(usersOfAccountViewModel.Id);

      CopyToUsersOfAccount(usersOfAccountViewModel, usersOfAccount);

      dbContext.SaveChanges();
    }

    private void DeleteUsersOfAccount(int id)
    {
      var dbContext = new ADbContext();

      var usersOfAccount = dbContext.UsersOfAccounts.Find(id);

      if (usersOfAccount != null)
      {
        dbContext.UsersOfAccounts.Remove(usersOfAccount);
        dbContext.SaveChanges();
      }
    }

    private UsersOfAccount MapToUsersOfAccount(UsersOfAccountViewModel usersOfAccountViewModel)
    {
      return new UsersOfAccount
      {
        Id = usersOfAccountViewModel.Id,
        Name = usersOfAccountViewModel.Name,
        Birthday = usersOfAccountViewModel.Birthday,
        UserId = usersOfAccountViewModel.UserId
      };
    }

    private UsersOfAccountViewModel MapToUsersOfAccountViewModel(UsersOfAccount usersOfAccount)
    {
      return new UsersOfAccountViewModel
      {
        Id = usersOfAccount.Id,
        Name = usersOfAccount.Name,
        Birthday = usersOfAccount.Birthday,
        UserId = usersOfAccount.UserId
      };
    }

    private void CopyToUsersOfAccount(UsersOfAccountViewModel usersOfAccountViewModel, UsersOfAccount usersOfAccount)
    {
      usersOfAccount.Id = usersOfAccountViewModel.Id;
      usersOfAccount.Name = usersOfAccountViewModel.Name;
      usersOfAccount.Birthday = usersOfAccountViewModel.Birthday;
      usersOfAccount.UserId = usersOfAccountViewModel.UserId;
    }
  }
}