using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechTrainingTracker.Models.User;

namespace TechTrainingTracker.WebMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var model = new UserListItem[0];
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }
    }
}