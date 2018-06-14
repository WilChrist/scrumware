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
    public class BacklogsController : Controller
    {
        private ProjetScrumEntities db = new ProjetScrumEntities();

        //GET: Backlogs
        public ActionResult Index(int id)
        {
            Backlog backlog = db.Backlogs.Where(p => p.Projet_Id == id).SingleOrDefault();
            if (backlog == null)
            {
                return RedirectToAction("Create");

            }
            return View("Details",backlog);
        }

        // GET: Backlogs/Details/5
      

        // GET: Backlogs/Create
        public ActionResult Create()
        {
            ViewBag.Projet_Id = new SelectList(db.Projets, "Id", "Name");
            ViewBag.User_Id = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Backlogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CreationDate,LastUpdateDate,State,TotalEstimation,Projet_Id,User_Id")] Backlog backlog)
        {
            if (ModelState.IsValid)
            {
                db.Backlogs.Add(backlog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Projet_Id = new SelectList(db.Projets, "Id", "Name", backlog.Projet_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "FirstName", backlog.User_Id);
            return View(backlog);
        }

        // GET: Backlogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Backlog backlog = db.Backlogs.Find(id);
            if (backlog == null)
            {
                return HttpNotFound();
            }
            ViewBag.Projet_Id = new SelectList(db.Projets, "Id", "Name", backlog.Projet_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "FirstName", backlog.User_Id);
            return View(backlog);
        }

        // POST: Backlogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreationDate,LastUpdateDate,State,TotalEstimation,Projet_Id,User_Id")] Backlog backlog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(backlog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Projet_Id = new SelectList(db.Projets, "Id", "Name", backlog.Projet_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "FirstName", backlog.User_Id);
            return View(backlog);
        }

        // GET: Backlogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Backlog backlog = db.Backlogs.Find(id);
            if (backlog == null)
            {
                return HttpNotFound();
            }
            return View(backlog);
        }

        // POST: Backlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Backlog backlog = db.Backlogs.Find(id);
            db.Backlogs.Remove(backlog);
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
