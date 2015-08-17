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
    public class InternshipOfferController : Controller
    {
        private RecruteContext db = new RecruteContext();

        //
        // GET: /InternshipOffer/

        public ActionResult Index()
        {
            return View(db.Internships.ToList());
        }

        //
        // GET: /InternshipOffer/Details/5

        public ActionResult Details(int id = 0)
        {
            InternshipOffer internshipoffer = db.Internships.Find(id);
            if (internshipoffer == null)
            {
                return HttpNotFound();
            }
            return View(internshipoffer);
        }

        //
        // GET: /InternshipOffer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /InternshipOffer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InternshipOffer internshipoffer)
        {
            if (ModelState.IsValid)
            {
                internshipoffer.adminID = 1; 
                User admin = db.Users.Find(1);
                internshipoffer.admin = admin;
                db.Internships.Add(internshipoffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(internshipoffer);
        }

        //
        // GET: /InternshipOffer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            InternshipOffer internshipoffer = db.Internships.Find(id);
            if (internshipoffer == null)
            {
                return HttpNotFound();
            }
            return View(internshipoffer);
        }

        //
        // POST: /InternshipOffer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InternshipOffer internship)
        {
            InternshipOffer _internship = db.Internships.Find(id);

            if (ModelState.IsValid)
            {
                _internship.poste = internship.poste;
                _internship.place = internship.place;
                _internship.activity = internship.activity;
                _internship.nbreInterns = internship.nbreInterns;
                _internship.dateOffre = internship.dateOffre;
                _internship.dateStart = internship.dateStart;
                _internship.dateEnd = internship.dateEnd;
                _internship.description = internship.description;
                _internship.techKnow = internship.techKnow;
                _internship.praticKnow = internship.praticKnow;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(internship);
        }
        //
        // GET: /InternshipOffer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            InternshipOffer internshipoffer = db.Internships.Find(id);
            if (internshipoffer == null)
            {
                return HttpNotFound();
            }
            return View(internshipoffer);
        }

        //
        // POST: /InternshipOffer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InternshipOffer internshipoffer = db.Internships.Find(id);
            db.Internships.Remove(internshipoffer);
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