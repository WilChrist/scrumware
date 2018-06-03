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
    public class ProjetsController : Controller
    {
        private ProjetScrumEntities db = new ProjetScrumEntities();

        // GET: Projets
        public ActionResult Index()
        {
            return View(db.Projets.ToList());
        }

        // GET: Projets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // GET: Projets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CreationDate,LastUpdateDate,State")] Projet projet)
        {
            projet.CreationDate = DateTime.Now;
            projet.LastUpdateDate = DateTime.Now;
            projet.State = "newly created";
            if (ModelState.IsValid)
            {
                db.Projets.Add(projet);
                
                ScrumWare.Models.User user = (ScrumWare.Models.User)Session["user"];
                user.Projets.Add(projet);
                db.Users.Find(user.Id).Projets.Add(projet);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projet);
        }

        // GET: Projets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // POST: Projets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreationDate,LastUpdateDate,State")] Projet projet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projet);
        }

        // GET: Projets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // POST: Projets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projet projet = db.Projets.Find(id);
            db.Projets.Remove(projet);
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
