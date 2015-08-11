using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Recrute.Models;

namespace Recrute.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        RecruteContext context = null;

        public UserController()
        {
            context = new RecruteContext();
        }
        public ActionResult Index()
        {
            List<User> users = context.Users.ToList();
            return View(users);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.typeID = 1;
                TypeUsers type = context.Types.Find(1);
                //TypeUsers type = context.Types.SingleOrDefault(ty => ty.typeID == 1);
                user.type = type;
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Edit(int id)
        {
            User user = context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            User _user = context.Users.Find(id);

            if (ModelState.IsValid)
            {
                _user.userName = user.userName;
                _user.userFirstName = user.userFirstName;
                _user.email = user.email;
                _user.password = user.password;
                _user.DateOfBirth = user.DateOfBirth;
                _user.nationality = user.nationality;
                _user.placeOfBirth = user.placeOfBirth;
                _user.famSituation = user.famSituation;
                _user.phoneNum = user.phoneNum;
                _user.gsmNum = user.gsmNum;
                _user.adress = user.adress;
                _user.village = user.village;
                _user.city = user.city;
                _user.country = user.country;
                _user.codePoste = user.codePoste;

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            User user = context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User _user = context.Users.Find(id);
            context.Users.Remove(_user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}