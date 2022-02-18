using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechTrainingTracker.Models.Skill;

namespace TechTrainingTracker.WebMVC.Controllers
{
    [Authorize]
    public class SkillController : Controller
    {
        // GET: Skill
        public ActionResult Index()
        {
            var model = new SkillListItem[0];
            return View(model);
        }
    }
}