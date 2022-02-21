using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechTrainingTracker.Models.User;
using TechTrainingTracker.Services;

namespace TechTrainingTracker.WebMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserService(userId);
            var model = service.GetUsers();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateUserService();

            if (service.CreateUser(model))
            {
                TempData["SaveResult"] = "User was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "User could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateUserService();
            var model = svc.GetUserById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateUserService();
            var detail = service.GetUserById(id);
            var model =
                new UserEdit 
                { 
                    UserID = detail.UserID,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    StreetAddress = detail.StreetAddress,
                    StreetAddress2 = detail.StreetAddress2,
                    City = detail.City,
                    State = detail.State,
                    ZipCode = detail.ZipCode,
                    PhoneNumber = detail.PhoneNumber,
                    EmailAddress = detail.EmailAddress,
                    PortfolioURL = detail.PortfolioURL
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.UserID != id)
            {
                ModelState.AddModelError("", "Id does not match.");
                return View(model);
            }

            var service = CreateUserService();

            if (service.UpdateUser(model))
            {
                TempData["SaveResult"] = "User was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "User could not be updated.");
            
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateUserService();
            var model = svc.GetUserById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateUserService();

            service.DeleteUser(id);

            TempData["SaveResult"] = "User was deleted.";

            return RedirectToAction("Index");
        }

        private UserService CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserService(userId);
            return service;
        }
    }
}

            


