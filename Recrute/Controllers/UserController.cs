using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Details(int id)
        {
            User user = context.Users.SingleOrDefault(b => b.userID == id);

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
                TypeUsers type = context.Types.SingleOrDefault(ty => ty.typeID == 1);
                user.type = type;
                //user.DateOfBirth = new DateTime();
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Edit(int id)
        {
            User user = context.Users.Single(p => p.userID == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            User _user = context.Users.Single(p => p.userID == id);

            if (ModelState.IsValid)
            {
                _user.userName = user.userName;
                _user.email = user.email;

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            User user = context.Users.Single(p => p.userID == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(int id, User user)
        {
            User _user = context.Users.Single(p => p.userID == id);
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