using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JSJournal.Data;
using JSJournal.Models;
using JSJournal.Services;
using Microsoft.AspNet.Identity;

namespace JSJournal.Controllers
{
    public class InterviewController : Controller
    {
        // GET: Lead
        public ActionResult InterviewIndex()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InterviewService(userId);
            var model = service.GetInterview();

            return View(model);
        }

        public ActionResult InterviewCreate()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InterviewCreate(InterviewCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InterviewService(userId);

            service.CreateInterview(model);

            return RedirectToAction("InterviewIndex");
        }

        public ActionResult InterviewEdit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InterviewService(userId);
            var detail = service.GetInterviewById(id);
            var model =
                new InterviewEdit
                {
                    LeadID = detail.LeadID,
                    PrimaryInterviewer = detail.PrimaryInterviewer,
                    SecondaryInterviewer = detail.SecondaryInterviewer,
                    InterviewTimeDateUtc = detail.InterviewTimeDateUtc,
                    InterviewerLink = detail.InterviewerLink,
                    Notes = detail.Notes
                };
            return View(model);
        }

        [ActionName("InterviewDelete")]
        public ActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InterviewService(userId);
            var model = service.GetInterviewById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("InterviewDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult InterviewDelete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InterviewService(userId);

            service.DeleteInterview(id);

            TempData["SaveResult"] = "Your Interview was deleted";

            return RedirectToAction("InterviewIndex");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InterviewEdit(int id, InterviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.InterviewID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InterviewService(userId);

            if (service.UpdateInterview(model))
            {
                TempData["SaveResult"] = "Your Lead was updated.";
                return RedirectToAction("InterviewIndex");
            }

            ModelState.AddModelError("", "Your Interview could not be updated.");
            return View(model);
        }

    }
}
