using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechTrainingTracker.Models.Training;

namespace TechTrainingTracker.WebMVC.Controllers
{
    [Authorize]
    public class TrainingController : Controller
    {
        // GET: Training
        public ActionResult Index()
        {
            var model = new TrainingListItem[0];
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
            if (ModelState.IsValid)
            {

            }

            return View(model);
        }
    }
}