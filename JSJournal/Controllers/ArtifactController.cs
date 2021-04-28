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
    public class ArtifactController : Controller
    {
        // GET: Artifact
        public ActionResult ArtifactIndex()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtifactService(userId);
            var model = service.GetArtifact();

            return View(model);
        }

        public ActionResult ArtifactCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ArtifactCreate(ArtifactCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtifactService(userId);

            service.CreateSource(model);

            return RedirectToAction("ArtifactIndex");
        }

        public ActionResult ArtifactEdit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtifactService(userId);
            var detail = service.GetArtifactById(id);
            var model =
                new ArtifactEdit
                {
                    ArtifactID = detail.ArtifactID,
                    ArtifactType = detail.ArtifactType,
                    ShortLabel = detail.ShortLabel,
                    Description = detail.Description,
                    Link = detail.Link
                };
            return View(model);
        }

        [ActionName("ArtifactDelete")]
        public ActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtifactService(userId);
            var model = service.GetArtifactById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("ArtifactDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ArtifactDelete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtifactService(userId);

            service.DeleteArtifact(id);

            TempData["SaveResult"] = "Your Artifact was deleted";

            return RedirectToAction("ArtifactIndex");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ArtifactEdit(int id, ArtifactEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ArtifactID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtifactService(userId);

            if (service.UpdateArtifact(model))
            {
                TempData["SaveResult"] = "Your Artifact was updated.";
                return RedirectToAction("ArtifactIndex");
            }

            ModelState.AddModelError("", "Your Artifact could not be updated.");
            return View(model);
        }

    }
}
