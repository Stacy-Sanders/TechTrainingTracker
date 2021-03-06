using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechTrainingTracker.Models.Skill;
using TechTrainingTracker.Services;

namespace TechTrainingTracker.WebMVC.Controllers
{
    [Authorize]
    public class SkillController : Controller
    {
        // GET: Skill
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SkillService(userId);
            var model = service.GetSkills();
            
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View(); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SkillCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSkillService();

            if (service.CreateSkill(model))
            {
                TempData["SaveResult"] = "Your skill was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Skill could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSkillService();
            var model = svc.GetSkillByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSkillService();
            var detail = service.GetSkillByID(id);
            var model =
                new SkillEdit
                {
                    SkillID = detail.SkillID,
                    UserID = detail.UserID,
                    Language = detail.Language,
                    IsTopTenDesirability = detail.IsTopTenDesirability,
                    SkillLevel = detail.SkillLevel
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SkillEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SkillID != id)
            {
                ModelState.AddModelError("", "Id does not match.");
                return View(model);
            }

            var service = CreateSkillService();

            if (service.UpdateSkill(model))
            {
                TempData["SaveResult"] = "Your skill information was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your skill information could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSkillService();
            var model = svc.GetSkillByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSkillService();

            service.DeleteSkill(id);

            TempData["SaveResult"] = "This skill was deleted";

            return RedirectToAction("Index");
        }

        private SkillService CreateSkillService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SkillService(userId);
            return service;
        }
    }
}
            

            

            
