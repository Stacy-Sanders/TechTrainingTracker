﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechTrainingTracker.Models;
using TechTrainingTracker.Services;

namespace TechTrainingTracker.WebMVC.Controllers
{
    [Authorize]
    public class CertificationController : Controller
    {
        // GET: Certification
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CertificationService(userId);
            var model = service.GetCertifications();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CertificationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCertificationService();

            if (service.CreateCertification(model))
            {
                TempData["SaveResult"] = "Your certification was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Certification could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCertificationService();
            var model = svc.GetCertificationById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCertificationService();
            var detail = service.GetCertificationById(id);
            var model =
                new CertificationEdit
                {
                    CertificationID = detail.CertificationID,
                    CertificationName = detail.CertificationName,
                    HasExam = detail.HasExam,
                    ExamFee = detail.ExamFee,
                    IssueDate = detail.IssueDate,
                    ExpireDate = detail.ExpireDate,
                    CompanyID = detail.CompanyID
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CertificationEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            
            if(model.CertificationID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCertificationService();

            if (service.UpdateCertification(model))
            {
                TempData["SaveResult"] = "Your certification was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your certification could not be updated.");
            return View(model);
        }


        private CertificationService CreateCertificationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CertificationService(userId);
            return service;
        }
    }
}

