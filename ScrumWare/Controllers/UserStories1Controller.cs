using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScrumWare.Models;

namespace ScrumWare.Controllers
{
    public class UserStories1Controller : Controller
    {
        private ProjetScrumEntities db = new ProjetScrumEntities();

        // GET: UserStories1
        public ActionResult Index()
        {
            var userStorys = db.UserStorys.Include(u => u.Backlog).Include(u => u.Sprint).Include(u => u.User);
            return View(userStorys.ToList());
        }

        // GET: UserStories1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStory userStory = db.UserStorys.Find(id);
            if (userStory == null)
            {
                return HttpNotFound();
            }
            return View(userStory);
        }

        // GET: UserStories1/Create
        public ActionResult Create()
        {
            ViewBag.Backlog_Id = new SelectList(db.Backlogs, "Id", "Name");
            ViewBag.Sprint_Id = new SelectList(db.Sprints, "Id", "Name");
            ViewBag.User_Id = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: UserStories1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CreationDate,LastUpdateDate,State,Priorite,Estimation,Backlog_Id,Sprint_Id,User_Id")] UserStory userStory)
        {
            if (ModelState.IsValid)
            {
                db.UserStorys.Add(userStory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Backlog_Id = new SelectList(db.Backlogs, "Id", "Name", userStory.Backlog_Id);
            ViewBag.Sprint_Id = new SelectList(db.Sprints, "Id", "Name", userStory.Sprint_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "FirstName", userStory.User_Id);
            return View(userStory);
        }

        // GET: UserStories1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStory userStory = db.UserStorys.Find(id);
            if (userStory == null)
            {
                return HttpNotFound();
            }
            ViewBag.Backlog_Id = new SelectList(db.Backlogs, "Id", "Name", userStory.Backlog_Id);
            ViewBag.Sprint_Id = new SelectList(db.Sprints, "Id", "Name", userStory.Sprint_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "FirstName", userStory.User_Id);
            return View(userStory);
        }

        // POST: UserStories1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreationDate,LastUpdateDate,State,Priorite,Estimation,Backlog_Id,Sprint_Id,User_Id")] UserStory userStory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userStory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Backlog_Id = new SelectList(db.Backlogs, "Id", "Name", userStory.Backlog_Id);
            ViewBag.Sprint_Id = new SelectList(db.Sprints, "Id", "Name", userStory.Sprint_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "FirstName", userStory.User_Id);
            return View(userStory);
        }

        // GET: UserStories1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStory userStory = db.UserStorys.Find(id);
            if (userStory == null)
            {
                return HttpNotFound();
            }
            return View(userStory);
        }

        // POST: UserStories1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserStory userStory = db.UserStorys.Find(id);
            db.UserStorys.Remove(userStory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
