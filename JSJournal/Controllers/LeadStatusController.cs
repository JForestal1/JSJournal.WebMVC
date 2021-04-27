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
    public class LeadStatusController : Controller
    {
        // GET: LeadStatus
        public ActionResult LeadStatusIndex()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadStatusService(userId);
            var model = service.GetLeadStatus();

            return View(model);
        }

        public ActionResult LeadStatusCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeadStatusCreate(LeadStatusCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadStatusService(userId);

            service.CreateStatus(model);

            return RedirectToAction("LeadStatusIndex");
        }

        public ActionResult Edit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadStatusService(userId);
            var detail = service.GetLeadStatusById(id);
            var model =
                new LeadStatusEdit
                {
                    StatusTypeID = detail.StatusTypeID,
                    Status = detail.Status,
                    Description = detail.Description
                };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadStatusService(userId);
            var model = service.GetLeadStatusById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStatusType(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadStatusService(userId);

            service.DeleteStatusType(id);

            TempData["SaveResult"] = "Your Status Code was deleted";

            return RedirectToAction("LeadStatusIndex");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LeadStatusEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.StatusTypeID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeadStatusService(userId);

            if (service.UpdateLeadStatus(model))
            {
                TempData["SaveResult"] = "Your Status Code was updated.";
                return RedirectToAction("LeadStatusIndex");
            }

            ModelState.AddModelError("", "Your Status Code could not be updated.");
            return View(model);
        }

    }
}
