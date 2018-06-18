﻿using System;
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
    public class UserStoriesController : Controller
    {
        private ProjetScrumEntities db = new ProjetScrumEntities();

        // GET: UserStories
        public ActionResult Index(int id)
        {
            List<UserStory> userStories = new List<UserStory>();
            userStories = db.UserStorys.Where(p => p.Backlog_Id== id).ToList();
            //if (userStories.Count()==0)
            //{
            //    return RedirectToAction("Index/" +id);
            //}
            ViewBag.c = id;
             return View(userStories);
        }

        // GET: UserStories/Details/5
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


        // GET: UserStories/Create
        public ActionResult Create(int id)
        {
            List<Sprint> sprintes = new List<Sprint>();
           sprintes = db.Sprints.Where(p => p.Backlog_Id == id).ToList();
            ViewBag.Sprint_Id = ViewBag.Sprint_Id = new SelectList(sprintes, "Id", "Name");
            UserStory userStory = new UserStory();
            userStory.Backlog_Id = id;
            return View(userStory);
        }

        // POST: UserStories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,State,Priorite,Estimation,Backlog_Id,Sprint_Id,User_Id")] UserStory userStory)
        {
            if (ModelState.IsValid)
            {
             userStory.CreationDate = DateTime.Now;
             userStory.LastUpdateDate = DateTime.Now;

                ScrumWare.Models.User user = (ScrumWare.Models.User)Session["user"];
                userStory.User_Id = user.Id;
                db.UserStorys.Add(userStory);
                db.SaveChanges();
                return RedirectToAction("Index/"+ userStory.Backlog_Id);
            }

            List<Sprint> sprintes = new List<Sprint>();
            sprintes = db.Sprints.Where(p => p.Backlog_Id == userStory.Backlog_Id).ToList();
            ViewBag.Sprint_Id = ViewBag.Sprint_Id = new SelectList(sprintes, "Id", "Name");
            return View(userStory);
        }

        // GET: UserStories/Edit/5
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
            List<Sprint> sprintes = new List<Sprint>();
            sprintes = db.Sprints.Where(p => p.Backlog_Id == userStory.Backlog_Id).ToList();
            ViewBag.Sprint_Id = ViewBag.Sprint_Id = new SelectList(sprintes, "Id", "Name");
            return View(userStory);
        }

        // POST: UserStories/Edit/5
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
                return RedirectToAction("Index/"+ userStory.Backlog_Id);
            }
            List<Sprint> sprintes = new List<Sprint>();
            sprintes = db.Sprints.Where(p => p.Backlog_Id == userStory.Backlog_Id).ToList();
 ViewBag.Sprint_Id = new SelectList(sprintes, "Id", "Name"); 
            return View(userStory);
        }

        // GET: UserStories/Delete/5
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

        // POST: UserStories/Delete/5
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