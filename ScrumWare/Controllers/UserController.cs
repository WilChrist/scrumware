
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
        ProjetScrumEntities db = new ProjetScrumEntities();
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
        public ActionResult ScrumMaster()
        {
            List<Projet> projets = new List<Projet>();
            ScrumWare.Models.User user = (ScrumWare.Models.User)Session["user"];
           
            projets=db.Users.Find(user.Id).Projets.ToList();
            return View(projets);
        }
      public ActionResult ListBacklog(int id)
        {
            Backlog backlog = db.Backlogs.Where(p => p.Projet_Id == id).SingleOrDefault();
            if (backlog == null)
            {
                return RedirectToAction("Create");

            }
            return View(backlog);
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
                       

           // db.Database.SqlQuery("select * from ProjetUser ",);
            var c = db.Users.Where(a => a.Email == user.Email).FirstOrDefault();
            if (c != null)
            {
                if (c.MotPasse == user.MotPasse)
                {
                    Session["user"] = c;
                    if (c.Role.Name.Equals("ProductOwner"))
                    {

                      return  Redirect(Url.Action("Index", "Projets"));
                    //    return RedirectToAction("Index");
                    }
                    if (c.Role.Name.Equals("ScrumMaster"))
                    {
                        return Redirect(Url.Action("ScrumMaster", "User"));
                    }
                    if (c.Role.Name.Equals("Equipe"))
                    {

                        return Redirect(Url.Action("Index", "Taches"));

                    }

                }
                else
                {
                    ViewBag.message = "Invalid PassWord";
                    return View();
                }
                
            }
         
                ViewBag.message = "Invalid Login";
           
            return View();
          
        }
        public ActionResult Inscription()
        {
            ViewBag.Role_Id = new SelectList(db.Roles, "Id", "Name");
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
              
                user.SignUpDate = DateTime.Now.ToLongDateString();
                user.LastSignIn = DateTime.Now;
                user.DateOfBirth= DateTime.Now;
        
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
         




            var v = db.Users.Where(a => a.Email == emailID).FirstOrDefault();
            return v != null;

        }
    }
}