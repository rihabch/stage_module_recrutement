using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recrute.Models;

namespace Recrute.Controllers
{
    public class JobOfferController : Controller
    {
        private RecruteContext db = new RecruteContext();

        //
        // GET: /JobOffer/

        public ActionResult Index()
        {
            return View(db.Jobs.ToList());
        }

        //
        // GET: /JobOffer/Details/5

        public ActionResult Details(int id = 0)
        {
            JobOffer joboffer = db.Jobs.Find(id);
            if (joboffer == null)
            {
                return HttpNotFound();
            }
            return View(joboffer);
        }

        //
        // GET: /JobOffer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /JobOffer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobOffer joboffer)
        {
            if (ModelState.IsValid)
            {
                joboffer.adminID = 1;
                User admin = db.Users.Find(1);
                joboffer.admin = admin;
                db.Jobs.Add(joboffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(joboffer);
        }

        //
        // GET: /JobOffer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            JobOffer joboffer = db.Jobs.Find(id);
            if (joboffer == null)
            {
                return HttpNotFound();
            }
            return View(joboffer);
        }

        //
        // POST: /JobOffer/Edit/5

        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobOffer job)
        {
            JobOffer _job = db.Jobs.Find(id);

            if (ModelState.IsValid)
            {
                _job.poste = job.poste;
                _job.place = job.place;
                _job.activity = job.activity;
                _job.dateOffre = job.dateOffre;
                _job.level = job.level;
                _job.experience = job.experience;
                _job.profile = job.profile;
                _job.missions = job.missions;
                _job.atouts = job.atouts;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        //
        // GET: /JobOffer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            JobOffer joboffer = db.Jobs.Find(id);
            if (joboffer == null)
            {
                return HttpNotFound();
            }
            return View(joboffer);
        }

        //
        // POST: /JobOffer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobOffer joboffer = db.Jobs.Find(id);
            db.Jobs.Remove(joboffer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}