using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CST356FinalProject.Models;
using Microsoft.AspNet.Identity;

namespace CST356FinalProject.Controllers
{
  public class UserAccountController : Controller
  {
    // GET: UserAccount
    public ActionResult Index()
    {
      using (ADbContext db = new ADbContext())
      {
        return View(db.UserAccounts.ToList());
      }
      return View();
    }

    public ActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Register(UserAccount account)
    {
      if (ModelState.IsValid)
      {
        using (ADbContext db = new ADbContext())
        {
          db.UserAccounts.Add(account);
          db.SaveChanges();
        }

        //Clear the contents of all input controls
        ModelState.Clear();

        ViewBag.Message = account.FirstName + " " + account.LastName + "succesfully registered.";
      }
      return View();
    }

    /*
    //
    // POST: /Account/LogOff
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult LogOff()
    {
      AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
      return RedirectToAction("Index", "Home");
    }
    */

    //User login
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Login(UserAccount user)
    {

      using (ADbContext db = new ADbContext())
      {
        var userAccount = db.UserAccounts.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();

        if (userAccount != null)
        {
          Session["UserID"] = userAccount.UserID.ToString();
          Session["Username"] = userAccount.Username.ToString();
          return RedirectToAction("LoggedIn");
        }
        else
        {
          ModelState.AddModelError("", "User or Password is wrong");
        }
      }
      return View();
    }

    public ActionResult LoggedIn()
    {
      if (Session["UserId"] != null)
      {
        return View();
      }
      else
      {
        return RedirectToAction("Login");
      }
    }

    public ActionResult Delete(int id)
    {
      DeleteUser(id);

      return RedirectToAction("List");
    }

    private void DeleteUser(int id)
    {
      UserAccount account;
      if (ModelState.IsValid)
      {
        using (ADbContext db = new ADbContext())
        {
          account = db.UserAccounts.Find(id);
          db.UserAccounts.Remove(account);
          db.SaveChanges();
        }

        //Clear the contents of all input controls
        ModelState.Clear();

        ViewBag.Message = account.FirstName + " " + account.LastName + "succesfully registered.";
      }

    }
  }
}