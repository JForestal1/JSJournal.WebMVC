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
    public class LeadSourceController : Controller
    {
        // GET: LeadSource
        public ActionResult LeadSourceIndex()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadSourceService(userId);
            var model = service.GetLeadSource();

            return View(model);
        }

        public ActionResult LeadSourceCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeadSourceCreate(LeadSourceCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadSourceService(userId);

            service.CreateSource(model);

            return RedirectToAction("LeadSourceIndex");
        }

        public ActionResult LeadSourceEdit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadSourceService(userId);
            var detail = service.GetLeadSourceById(id);
            var model =
                new LeadSourceEdit
                {
                    SourceTypeID = detail.SourceTypeID,
                    Source = detail.Source,
                    Description = detail.Description
                };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadSourceService(userId);
            var model = service.GetLeadSourceById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSourceType(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadSourceService(userId);

            service.DeleteSourceType(id);

            TempData["SaveResult"] = "Your Source was deleted";

            return RedirectToAction("LeadSourceIndex");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeadSourceEdit(int id, LeadSourceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SourceTypeID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadSourceService(userId);

            if (service.UpdateLeadSource(model))
            {
                TempData["SaveResult"] = "Your Source was updated.";
                return RedirectToAction("LeadSourceIndex");
            }

            ModelState.AddModelError("", "Your Source could not be updated.");
            return View(model);
        }

    }
}
