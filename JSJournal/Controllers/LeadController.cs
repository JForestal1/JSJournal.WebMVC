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
    public class LeadController : Controller
    {
        // GET: Lead
        public ActionResult LeadIndex()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadService(userId);
            var model = service.GetLead();

            return View(model);
        }

        public ActionResult LeadCreate()
        {
            return View();
        }

        public ActionResult FollowUpCreate()
        {

                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeadCreate(LeadCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadService(userId);

            service.CreateLead(model);

            return RedirectToAction("LeadIndex");
        }

        public ActionResult LeadEdit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadService(userId);
            var detail = service.GetLeadById(id);
            var model =
                new LeadEdit
                {
                    LeadID = detail.LeadID,
                    Role = detail.Role,
                    Company = detail.Company,
                    StatusID = detail.StatusID,
                    SourceID = detail.SourceID,
                    JobDescriptionLink = detail.JobDescriptionLink,
                    ResumeID = detail.ResumeID,
                    CoverID = detail.CoverID,
                    OtherArtifactID = detail.OtherArtifactID,
                    CreatedUtc = DateTimeOffset.Now
                };
            return View(model);
        }

        [ActionName("LeadDelete")]
        public ActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadService(userId);
            var model = service.GetLeadById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("LeadDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult LeadDelete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadService(userId);

            service.DeleteLead(id);

            TempData["SaveResult"] = "Your Lead was deleted";

            return RedirectToAction("LeadIndex");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeadEdit(int id, LeadEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LeadID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadService(userId);

            if (service.UpdateLead(model))
            {
                TempData["SaveResult"] = "Your Lead was updated.";
                return RedirectToAction("LeadIndex");
            }

            ModelState.AddModelError("", "Your Lead could not be updated.");
            return View(model);
        }

    }
}
