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
    public class AcademicYearController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AcademicYear
        public ActionResult Index()
        {
            return View(db.AcademicYears.ToList());
        }

        // GET: AcademicYear/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicYear academicYear = db.AcademicYears.Find(id);
            if (academicYear == null)
            {
                return HttpNotFound();
            }
            return View(academicYear);
        }

        // GET: AcademicYear/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcademicYear/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AcademicYearId,AnUniversitar")] AcademicYear academicYear)
        {
            if (ModelState.IsValid)
            {
                db.AcademicYears.Add(academicYear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academicYear);
        }

        // GET: AcademicYear/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicYear academicYear = db.AcademicYears.Find(id);
            if (academicYear == null)
            {
                return HttpNotFound();
            }
            return View(academicYear);
        }

        // POST: AcademicYear/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AcademicYearId,AnUniversitar")] AcademicYear academicYear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academicYear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academicYear);
        }

        // GET: AcademicYear/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicYear academicYear = db.AcademicYears.Find(id);
            if (academicYear == null)
            {
                return HttpNotFound();
            }
            return View(academicYear);
        }

        // POST: AcademicYear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcademicYear academicYear = db.AcademicYears.Find(id);
            db.AcademicYears.Remove(academicYear);
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

        [NonAction]
        public int GetCurrentAcademicYearId()
        {
            var max = db.AcademicYears.OrderByDescending(p => p.AcademicYearId).FirstOrDefault().AcademicYearId;
            //sau
            //int max = db.AcademicYears.Max(p => p.AcademicYearId);
            Globals.idAnUnivCurent = max;
            return max;
        }

        [NonAction]
        public string GetCurrentAcademicYear()
        {
            int idAnUniversitarCurent = GetCurrentAcademicYearId();
            var anUniv = db.AcademicYears
                            .Where(p => p.AcademicYearId == idAnUniversitarCurent)
                            .Select(p => new { p.AnUniversitar });
            Globals.anUnivCurent = anUniv.ToString();
            ViewData["anUnivCurent"] = Globals.anUnivCurent;
            return anUniv.ToString();
        }
    }
}
