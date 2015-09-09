using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using Kendo.Mvc.UI;
using Recrute.Models;
using Kendo.Mvc.Extensions;
using System.Data.Entity;
using System.Web;
using System.Collections;
using System.Globalization;

namespace Recrute.Controllers
{
    [CustomAuthorize]
    public class UserController : Controller
    {
        //
        // GET: /User/

        RecruteContext context = null;
        UserService userservice = null;

        public UserController()
        {
            context = new RecruteContext();
            userservice = new UserService();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
                List<User> users = context.Users.ToList();
                return View(users);
            
        }


        [Authorize(Roles = "Admin, User")]
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
                context.Users.Add(user);

                Session["LogedUserID"] = user.userID.ToString();
                Session["LogedUserFirstname"] = user.userFirstName.ToString();
                Session["LogedUserName"] = user.userName.ToString();
                
                FormsAuthentication.SetAuthCookie(user.email, false);
                context.SaveChanges();
                Session["LoggedUserRole"] = Roles.GetRolesForUser(user.email);
                
                Roles.AddUserToRole(user.email, "User");
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        //[Authorize(Roles = "Admin, User")]
        public ActionResult Edit(int id)
        {
            User user = context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //[Authorize(Roles = "Admin, User")]
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


        [Authorize(Roles = "Admin")]
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
                using (RecruteContext contex = new RecruteContext())
                {
                    var v = contex.Users.Where(a => a.email.Equals(user.email) && a.password.Equals(user.password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.userID.ToString();
                        Session["LogedUserFirstname"] = v.userFirstName.ToString();
                        Session["LogedUserName"] = v.userName.ToString();
                        Session["LoggedUserRole"] = Roles.GetRolesForUser(v.email);
                        FormsAuthentication.SetAuthCookie(v.email, false);
                        return RedirectToAction("Details", "User", new { id = v.userID });
                    }
                }
            }
                else
                {
                    ModelState.AddModelError("Erreur", "Email ou Mot de passe invalides!");
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
    }
}