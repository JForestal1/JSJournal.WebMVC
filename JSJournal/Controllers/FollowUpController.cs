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
    public class FollowUpController : Controller
    {
        // GET: FollowUp
        public ActionResult FollowUpIndex()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FollowUpService(userId);
            var model = service.GetFollowUps();

            return View(model);
        }

        public ActionResult FollowUpCreate()
        {
            return View();
        }

        public ActionResult FollowUpCreate(int leadID)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FollowUpCreate(FollowUpCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FollowUpService(userId);

            service.CreateFollowUp(model);

            return RedirectToAction("FollowUpIndex");
        }

        public ActionResult FollowUpEdit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FollowUpService(userId);
            var detail = service.GetFollowUpById(id);
            var model =
                new FollowUpEdit
                {
                    FollowUpID = detail.FollowUpID,
                    ShortDescription = detail.ShortDescription,
                    FollowUpStatusID = detail.FollowUpStatusID,
                    Notes = detail.Notes,
                    DueUtc = (DateTimeOffset)detail.DueUtc
                };
            return View(model);
        }

        [ActionName("FollowUpDelete")]
        public ActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FollowUpService(userId);
            var model = service.GetFollowUpById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("FollowUpDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult FollowUpDelete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FollowUpService(userId);

            service.DeleteFollowUp(id);

            TempData["SaveResult"] = "Your Follow-up was deleted";

            return RedirectToAction("FollowUpIndex");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FollowUpEdit(int id, FollowUpEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FollowUpID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FollowUpService(userId);

            if (service.UpdateFollowUp(model))
            {
                TempData["SaveResult"] = "Your Follow-up was updated.";
                return RedirectToAction("FollowUpIndex");
            }

            ModelState.AddModelError("", "Your Follow-up could not be updated.");
            return View(model);
        }

    }
}
