
using ScrumWare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumWare.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            if (Session["user"]==null)
            {
                ViewBag.message = "Please login First";
                
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.message = "";
            return View();
        }
        public ActionResult Sessions()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin user)
        {
            if (ViewBag.message == null)
            {
                ViewBag.message = "";
            }
            else
            {

            }
                       
            ProjetScrumEntities db = new ProjetScrumEntities();
            var c = db.Users.Where(a => a.Email == user.Email).FirstOrDefault();
            if (c != null)
            {
                if (c.MotPasse == user.MotPasse)
                {
                    c.Projets = db.Projets.ToList();
                    Session["user"] = c;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.message = "Invalid PassWord";
                    return View();
                }
                
            }
            else
            {
                ViewBag.message = "Invalid Login";
           
            return View();
            }
        }
        public ActionResult Inscription()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inscription(User user)
        {
            if (ModelState.IsValid)
            {
                var isExist = IsEmailExist(user.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already Exist");
                    return View(user);
                }
                ProjetScrumEntities db = new ProjetScrumEntities();
                user.SignUpDate = DateTime.Now.ToLongDateString();
                user.LastSignIn = DateTime.Now;
                user.DateOfBirth= DateTime.Now;
                user.Role_Id = 3;
                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Login");
            }
            else
            {
                return View(user);
            }
          }
        [NonAction]
        public bool IsEmailExist(String emailID)
        {
            ProjetScrumEntities db = new ProjetScrumEntities();
            var v = db.Users.Where(a => a.Email == emailID).FirstOrDefault();
            return v != null;

        }
    }
}