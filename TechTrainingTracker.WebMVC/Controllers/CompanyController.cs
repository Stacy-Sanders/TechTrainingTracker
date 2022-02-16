using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechTrainingTracker.Models.Company;

namespace TechTrainingTracker.WebMVC.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            var model = new CompanyListItem[0];
            return View(model);
        }
    }
}