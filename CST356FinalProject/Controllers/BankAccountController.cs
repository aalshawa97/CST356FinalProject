using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CST356FinalProject.Models;
using CST356FinalProject.Models.View;

namespace CST356FinalProject.Controllers
{
    public class BankAccountController : Controller
    {
      //List the bank accounts associated with the user
      public ActionResult List(int userId)
      {
        ViewBag.UserId = userId;

        var bankAccounts = GetBankAccountsForUser(userId);

        return View(bankAccounts);
      }

      private ICollection<BankAccountViewModel> GetBankAccountsForUser(int userId)
      {
        var bankAccountViewModels = new List<BankAccountViewModel>();

        var dbContext = new ADbContext();

        var bankAccounts = dbContext.BankAccounts.Where(pet => pet.UserId == userId).ToList();

        foreach (var bankAccount in bankAccounts)
        {
          //var bankAccountViewModel = MapToBankAccountViewModel(bankAccount);
          //bankAccountViewModels.Add(bankAccountViewModel);
        }
        return bankAccountViewModels;
      }

      /*
        [HttpGet]
        public ActionResult Create(int userId)
        {
          ViewBag.UserId = userId;

          return View();
        }

        [HttpPost]
        public ActionResult Create(PetViewModel petViewModel)
        {
          if (ModelState.IsValid)
          {
            Save(petViewModel);
            return RedirectToAction("List", new { petViewModel.UserId });
          }

          return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
          var pet = GetPet(id);

          return View(pet);
        }

        [HttpPost]
        public ActionResult Edit(PetViewModel petViewModel)
        {
          petViewModel.UserId = GetPet(petViewModel.Id).UserId;

          if (ModelState.IsValid)
          {
            UpdatePet(petViewModel);

            return RedirectToAction("List", new { petViewModel.UserId });
          }

          return View();
        }

        public ActionResult Details(int id)
        {
          var pet = GetPet(id);

          return View(pet);
        }

        private void UpdatePet(PetViewModel petViewModel)
        {
          var dbContext = new AppDbContext();

          var pet = dbContext.Pets.Find(petViewModel.Id);

          CopyToPet(petViewModel, pet);

          dbContext.SaveChanges();
        }

        private void CopyToPet(PetViewModel petViewModel, Pet pet)
        {
          pet.Name = petViewModel.Name;
          pet.Age = petViewModel.Age;
          pet.NextCheckup = petViewModel.NextCheckup;
          pet.VetName = petViewModel.VetName;
          pet.UserId = petViewModel.UserId;
        }

        public ActionResult Delete(int id)
        {
          var pet = GetPet(id);

          DeletePet(id);

          return RedirectToAction("List", new { UserId = pet.UserId });
        }

        private PetViewModel GetPet(int petId)
        {
          var dbContext = new AppDbContext();

          var pet = dbContext.Pets.Find(petId);

          return MapToPetViewModel(pet);
        }

          return petViewModels;
        }

        private void Save(PetViewModel petViewModel)
        {
          var dbContext = new AppDbContext();

          var pet = MapToPet(petViewModel);

          dbContext.Pets.Add(pet);

          dbContext.SaveChanges();
        }

        private void DeletePet(int id)
        {
          var dbContext = new AppDbContext();

          var pet = dbContext.Pets.Find(id);

          if (pet != null)
          {
            dbContext.Pets.Remove(pet);
            dbContext.SaveChanges();
          }
        }

        private Pet MapToPet(PetViewModel petViewModel)
        {
          return new Pet
          {
            Id = petViewModel.Id,
            Name = petViewModel.Name,
            Age = petViewModel.Age,
            NextCheckup = petViewModel.NextCheckup,
            VetName = petViewModel.VetName,
            UserId = petViewModel.UserId
          };
        }

        private PetViewModel MapToPetViewModel(Pet pet)
        {
          return new PetViewModel
          {
            Id = pet.Id,
            Name = pet.Name,
            Age = pet.Age,
            NextCheckup = pet.NextCheckup,
            VetName = pet.VetName,
            UserId = pet.UserId
          };
        }
      */
    }
}