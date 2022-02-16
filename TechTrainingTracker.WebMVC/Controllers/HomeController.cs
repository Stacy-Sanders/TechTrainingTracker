using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechTrainingTracker.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Tech Training Tracker";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Questions, Comments, Concerns?";

            return View();
        }
    }
}