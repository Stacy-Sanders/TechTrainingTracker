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
            var model = svc.GetSkillByUserID(id);

            return View(model);
        }

        private SkillService CreateSkillService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SkillService(userId);
            return service;
        }
    }
}
            

            

            
