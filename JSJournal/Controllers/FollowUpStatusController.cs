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
    public class FollowUpStatusController : Controller
    {
        // GET: FollowUpStatus
        public ActionResult FollowUpStatusIndex()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FollowUpStatusService(userId);
            var model = service.GetFollowUpStatus();

            return View(model);
        }

        public ActionResult FollowUpStatusCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FollowUpStatusCreate(FollowUpStatusCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FollowUpStatusService(userId);

            service.CreateFollowUpStatus(model);

            return RedirectToAction("FollowUpStatusIndex");
        }

        public ActionResult FollowUpStatusEdit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FollowUpStatusService(userId);
            var detail = service.GetFollowUpStatusById(id);
            var model =
                new FollowUpStatusEdit
                {
                    FollowUpStatusTypeID = detail.FollowUpStatusTypeID,
                    Status = detail.Status,
                    Description = detail.Description
                };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FollowUpStatusService(userId);
            var model = service.GetFollowUpStatusById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSourceType(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FollowUpStatusService(userId);

            service.DeleteFollowUpStatusType(id);

            TempData["SaveResult"] = "Your Status Type was deleted";

            return RedirectToAction("FollowUpStatusIndex");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FollowUpStatusEdit(int id, FollowUpStatusEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FollowUpStatusTypeID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FollowUpStatusService(userId);

            if (service.UpdateFollowUpStatus(model))
            {
                TempData["SaveResult"] = "Your Status Type was updated.";
                return RedirectToAction("FollowUpStatusIndex");
            }

            ModelState.AddModelError("", "Your Status Type could not be updated.");
            return View(model);
        }

    }
}
