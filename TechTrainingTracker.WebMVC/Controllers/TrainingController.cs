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
    }
}