using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechTrainingTracker.Models.Company;
using TechTrainingTracker.Services;

namespace TechTrainingTracker.WebMVC.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CompanyService(userId);
            var model = service.GetCompanies();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCompanyService();

            if (service.CreateCompany(model))
            {
                TempData["SaveResult"] = "The company was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Company could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCompanyService();
            var model = svc.GetCompanyById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCompanyService();
            var detail = service.GetCompanyById(id);
            var model =
                new CompanyEdit
                {
                    CompanyID = detail.CompanyID,
                    CompanyName = detail.CompanyName,
                    HasFreeCourses = detail.HasFreeCourses,
                    HasPaidSubscription = detail.HasPaidSubscription,
                    SubscriptionCost = detail.SubscriptionCost,
                    IsSubcriptionRequired = detail.IsSubcriptionRequired,
                    HasApp = detail.HasApp,
                    HasAccreditedCourses = detail.HasAccreditedCourses,
                    Accreditation = detail.Accreditation
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompanyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.CompanyID != id)
            {
                ModelState.AddModelError("", "Id does not match");
                return View(model);
            }

            var service = CreateCompanyService();

            if (service.UpdateCompany(model))
            {
                TempData["SaveResult"] = "Company was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Company could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCompanyService();
            var model = svc.GetCompanyById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCompanyService();

            service.DeleteCompany(id);

            TempData["Save Result"] = "The company has been deleted.";

            return RedirectToAction("Index");
        }

        private CompanyService CreateCompanyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CompanyService(userId);
            return service;
        }
    }
}
            