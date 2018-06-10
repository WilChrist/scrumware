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
    public class TachesController : Controller
    {
        private ProjetScrumEntities db = new ProjetScrumEntities();

        // GET: Taches
        public ActionResult Index()
        {
            var taches1 = db.Taches1.Include(t => t.Backlog).Include(t => t.Sprint).Include(t => t.User);
            return View(taches1.ToList());
        }

        // GET: Taches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tache tache = db.Taches1.Find(id);
            if (tache == null)
            {
                return HttpNotFound();
            }
            return View(tache);
        }

        // GET: Taches/Create
        public ActionResult Create()
        {
            ViewBag.Backlog_Id = new SelectList(db.Backlogs, "Id", "Name");
            ViewBag.Sprint_Id = new SelectList(db.Sprints, "Id", "Name");
            ViewBag.User_Id = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Taches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CreationDate,LastUpdateDate,State,Cout,BeginDate,EndDate,Cout_Mon,Cout_Tue,Cout_Wen,Cout_Thu,Cout_Fri,Backlog_Id,Sprint_Id,User_Id")] Tache tache)
        {
            if (ModelState.IsValid)
            {
                db.Taches1.Add(tache);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Backlog_Id = new SelectList(db.Backlogs, "Id", "Name", tache.Backlog_Id);
            ViewBag.Sprint_Id = new SelectList(db.Sprints, "Id", "Name", tache.Sprint_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "FirstName", tache.User_Id);
            return View(tache);
        }

        // GET: Taches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tache tache = db.Taches1.Find(id);
            if (tache == null)
            {
                return HttpNotFound();
            }
            ViewBag.Backlog_Id = new SelectList(db.Backlogs, "Id", "Name", tache.Backlog_Id);
            ViewBag.Sprint_Id = new SelectList(db.Sprints, "Id", "Name", tache.Sprint_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "FirstName", tache.User_Id);
            return View(tache);
        }

        // POST: Taches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreationDate,LastUpdateDate,State,Cout,BeginDate,EndDate,Cout_Mon,Cout_Tue,Cout_Wen,Cout_Thu,Cout_Fri,Backlog_Id,Sprint_Id,User_Id")] Tache tache)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tache).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Backlog_Id = new SelectList(db.Backlogs, "Id", "Name", tache.Backlog_Id);
            ViewBag.Sprint_Id = new SelectList(db.Sprints, "Id", "Name", tache.Sprint_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "FirstName", tache.User_Id);
            return View(tache);
        }

        // GET: Taches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tache tache = db.Taches1.Find(id);
            if (tache == null)
            {
                return HttpNotFound();
            }
            return View(tache);
        }

        // POST: Taches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tache tache = db.Taches1.Find(id);
            db.Taches1.Remove(tache);
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
