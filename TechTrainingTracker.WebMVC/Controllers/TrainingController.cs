using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechTrainingTracker.Models.Training;
using TechTrainingTracker.Services;

namespace TechTrainingTracker.WebMVC.Controllers
{
    [Authorize]
    public class TrainingController : Controller
    {
        // GET: Training
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrainingService(userId);
            var model = service.GetTrainings();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrainingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTrainingService();

            if (service.CreateTraining(model))
            {
                TempData["SaveResult"] = "Your training course was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Training course could not be created.");
            
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTrainingService();
            var model = svc.GetTrainingById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTrainingService();
            var detail = service.GetTrainingById(id);
            var model =
                new TrainingEdit
                {
                    TrainingID = detail.TrainingID,
                    CourseName = detail.CourseName,
                    CourseWebsite = detail.CourseWebsite,
                    UserID = detail.UserID,
                    Language = detail.Language,
                    DifficultyLevel = detail.DifficultyLevel,
                    IsSubcriptionRequired = detail.IsSubcriptionRequired,
                    IsFree = detail.IsFree,
                    CourseCost = detail.CourseCost,
                    LearningLocation = detail.LearningLocation,
                    LearningMethod = detail.LearningMethod,
                    Duration = detail.Duration,
                    CompanyID = detail.CompanyID
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TrainingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TrainingID != id)
            {
                ModelState.AddModelError("", "Id does not match.");
                return View(model);
            }

            var service = CreateTrainingService();

            if (service.UpdateTraining(model))
            {
                TempData["SaveResult"] = "Your training course was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your training course could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTrainingService();
            var model = svc.GetTrainingById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTrainingService();

            service.DeleteTraining(id);

            TempData["SaveResult"] = "Your training course was deleted.";

            return RedirectToAction("Index");
        }

        private TrainingService CreateTrainingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrainingService(userId);
            return service;
        }
    }
}