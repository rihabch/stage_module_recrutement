using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Recrute.Models;
using WebMatrix.WebData;

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

            if (Session["LogedUserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<User> users = context.Users.ToList();
                return View(users);
            }
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

        // GET: /User/Login

        public ActionResult Login()
        {
            return View();
        }

        // POST: /User/Login


        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (ValidateUser(user.email, user.password))
                {

                    FormsAuthentication.SetAuthCookie(user.userFirstName, false);
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("Erreur", "Email ou Mot de passe invalides!");
                }
            }
            return View();
        }

        private bool ValidateUser(string Email, string Password)
        {

            bool isValid = false;
            using (var db = new RecruteContext())
            {
                    var v = db.Users.Where(a => a.email.Equals(Email) && a.password.Equals(Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.userID.ToString();
                        Session["LogedUserFirstname"] = v.userFirstName.ToString();
                        Session["LogedUserName"] = v.userName.ToString();
                        isValid = true;
                    }
            }
            return isValid;
        }

        // POST: /User/LogOff

        public ActionResult LogOff()
        {
            Session.Abandon(); // it will clear the session at the end of request
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: /User/Login

        /*[AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /User/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(user.userName, user.password, persistCookie: model.RememberMe))
            {
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(user);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
/*
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                using (RecruteContext contex = new RecruteContext())
                {
                    var v = contex.Users.Where(a => a.email.Equals(u.email) && a.password.Equals(u.password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.userID.ToString();
                        Session["LogedUserFirstname"] = v.userFirstName.ToString();
                        Session["LogedUserName"] = v.userName.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(u);
        }

        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        
        // POST: /User/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        */
    }
}