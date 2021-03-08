using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestiuneExamene.Models;

namespace GestiuneExamene.Controllers
{
    public class StudyYearController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudyYear
        public ActionResult Index()
        {
            return View(db.StudyYears.ToList());
        }

        // GET: StudyYear/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyYear studyYear = db.StudyYears.Find(id);
            if (studyYear == null)
            {
                return HttpNotFound();
            }
            return View(studyYear);
        }

        // GET: StudyYear/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudyYear/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudyYearId,AnStudiu")] StudyYear studyYear)
        {
            if (ModelState.IsValid)
            {
                db.StudyYears.Add(studyYear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studyYear);
        }

        // GET: StudyYear/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyYear studyYear = db.StudyYears.Find(id);
            if (studyYear == null)
            {
                return HttpNotFound();
            }
            return View(studyYear);
        }

        // POST: StudyYear/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudyYearId,AnStudiu")] StudyYear studyYear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studyYear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studyYear);
        }

        // GET: StudyYear/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyYear studyYear = db.StudyYears.Find(id);
            if (studyYear == null)
            {
                return HttpNotFound();
            }
            return View(studyYear);
        }

        // POST: StudyYear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudyYear studyYear = db.StudyYears.Find(id);
            db.StudyYears.Remove(studyYear);
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
