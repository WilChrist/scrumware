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
                return RedirectToAction("Create/"+id);

            }
            return View("Details",backlog);
        }

        // GET: Backlogs/Details/5
      

        // GET: Backlogs/Create
        public ActionResult Create(int id)
        {
            Backlog backlog = new Backlog();
            backlog.Projet_Id = id;
            return View(backlog);
        }

        // POST: Backlogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,State,TotalEstimation,Projet_Id,User_Id")] Backlog backlog)
        {
            if (ModelState.IsValid)
            {
                backlog.CreationDate = DateTime.Now;
                backlog.LastUpdateDate = DateTime.Now;
 ScrumWare.Models.User user = (ScrumWare.Models.User)Session["user"];
                backlog.User_Id = user.Id;
db.Backlogs.Add(backlog);
                db.SaveChanges();
                return RedirectToAction("Index/"+ backlog.Projet_Id);
            }

            
            return View(backlog);
        }

        // GET: Backlogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Backlog backlog = db.Backlogs.Where(p => p.Projet_Id==id).FirstOrDefault();
            if (backlog == null)
            {
                return HttpNotFound();
            }
          
            return View(backlog);
        }

        // POST: Backlogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,State,TotalEstimation,Projet_Id,User_Id")] Backlog backlog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(backlog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index/" + backlog.Projet_Id);
            }
    
            return View(backlog);
        }

        // GET: Backlogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Backlog backlog = db.Backlogs.Where(p => p.Projet_Id == id).FirstOrDefault();
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
            Backlog backlog = db.Backlogs.Where(p => p.Projet_Id == id).FirstOrDefault();
            db.Backlogs.Remove(backlog);
            db.SaveChanges();
            return RedirectToAction("Index/"+id);
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
