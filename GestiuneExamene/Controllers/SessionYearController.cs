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
    public class SessionYearController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SessionYear
        public ActionResult Index()
        {
            var sessionYears = db.SessionYears.Include(s => s.AcademicYear).Include(s => s.Session);
            return View(sessionYears.ToList());
        }

        // GET: SessionYear/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionYear sessionYear = db.SessionYears.Find(id);
            if (sessionYear == null)
            {
                return HttpNotFound();
            }
            return View(sessionYear);
        }

        // GET: SessionYear/Create
        public ActionResult Create()
        {
            ViewBag.AnUniversitar = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar");
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune");
            return View();
        }

        // POST: SessionYear/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSesiune,AnUniversitar,IdSessionYear,DataInceput,DataFinal")] SessionYear sessionYear)
        {
            if (ModelState.IsValid)
            {
                db.SessionYears.Add(sessionYear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnUniversitar = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", sessionYear.AnUniversitar);
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune", sessionYear.IdSesiune);
            return View(sessionYear);
        }

        // GET: SessionYear/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionYear sessionYear = db.SessionYears.Find(id);
            if (sessionYear == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnUniversitar = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", sessionYear.AnUniversitar);
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune", sessionYear.IdSesiune);
            return View(sessionYear);
        }

        // POST: SessionYear/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSesiune,AnUniversitar,IdSessionYear,DataInceput,DataFinal")] SessionYear sessionYear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sessionYear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnUniversitar = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", sessionYear.AnUniversitar);
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune", sessionYear.IdSesiune);
            return View(sessionYear);
        }

        // GET: SessionYear/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionYear sessionYear = db.SessionYears.Find(id);
            if (sessionYear == null)
            {
                return HttpNotFound();
            }
            return View(sessionYear);
        }

        // POST: SessionYear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SessionYear sessionYear = db.SessionYears.Find(id);
            db.SessionYears.Remove(sessionYear);
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
