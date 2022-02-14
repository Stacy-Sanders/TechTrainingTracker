using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechTrainingTracker.Models;

namespace TechTrainingTracker.WebMVC.Controllers
{
    [Authorize]
    public class CertificationController : Controller
    {
        // GET: Certification
        public ActionResult Index()
        {
            var model = new CertificationListItem[0];
            return View(model);
        }
    }
}