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
    public class SubjectCoverageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubjectCoverage
        public ActionResult Index()
        {
            var subjectCoverages = db.SubjectCoverages.Include(s => s.AcademicYear).Include(s => s.Professor).Include(s => s.Specialization).Include(s => s.StudyYear).Include(s => s.Subject);
            return View(subjectCoverages.ToList());
        }

        // GET: SubjectCoverage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectCoverage subjectCoverage = db.SubjectCoverages.Find(id);
            if (subjectCoverage == null)
            {
                return HttpNotFound();
            }
            return View(subjectCoverage);
        }

        // GET: SubjectCoverage/Create
        public ActionResult Create()
        {
            ViewBag.AnUniversitar = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar");
            ViewBag.MarcaProf = new SelectList(db.Professors, "MarcaProf", "Nume");
            ViewBag.IdSpecializare = new SelectList(db.Specializations, "IDSpecializare", "DenumireSpecializare");
            ViewBag.AnStudiu = new SelectList(db.StudyYears, "StudyYearId", "AnStudiu");
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina");
            return View();
        }

        // POST: SubjectCoverage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSpecializare,IdDisciplina,MarcaProf,AnStudiu,AnUniversitar")] SubjectCoverage subjectCoverage)
        {
            if (ModelState.IsValid)
            {
                db.SubjectCoverages.Add(subjectCoverage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnUniversitar = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", subjectCoverage.AnUniversitar);
            ViewBag.MarcaProf = new SelectList(db.Professors, "MarcaProf", "Nume", subjectCoverage.MarcaProf);
            ViewBag.IdSpecializare = new SelectList(db.Specializations, "IDSpecializare", "DenumireSpecializare", subjectCoverage.IdSpecializare);
            ViewBag.AnStudiu = new SelectList(db.StudyYears, "StudyYearId", "AnStudiu", subjectCoverage.AnStudiu);
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", subjectCoverage.IdDisciplina);
            return View(subjectCoverage);
        }

        // GET: SubjectCoverage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectCoverage subjectCoverage = db.SubjectCoverages.Find(id);
            if (subjectCoverage == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnUniversitar = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", subjectCoverage.AnUniversitar);
            ViewBag.MarcaProf = new SelectList(db.Professors, "MarcaProf", "Nume", subjectCoverage.MarcaProf);
            ViewBag.IdSpecializare = new SelectList(db.Specializations, "IDSpecializare", "DenumireSpecializare", subjectCoverage.IdSpecializare);
            ViewBag.AnStudiu = new SelectList(db.StudyYears, "StudyYearId", "AnStudiu", subjectCoverage.AnStudiu);
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", subjectCoverage.IdDisciplina);
            return View(subjectCoverage);
        }

        // POST: SubjectCoverage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSpecializare,IdDisciplina,MarcaProf,AnStudiu,AnUniversitar")] SubjectCoverage subjectCoverage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectCoverage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnUniversitar = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", subjectCoverage.AnUniversitar);
            ViewBag.MarcaProf = new SelectList(db.Professors, "MarcaProf", "Nume", subjectCoverage.MarcaProf);
            ViewBag.IdSpecializare = new SelectList(db.Specializations, "IDSpecializare", "DenumireSpecializare", subjectCoverage.IdSpecializare);
            ViewBag.AnStudiu = new SelectList(db.StudyYears, "StudyYearId", "AnStudiu", subjectCoverage.AnStudiu);
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", subjectCoverage.IdDisciplina);
            return View(subjectCoverage);
        }

        // GET: SubjectCoverage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectCoverage subjectCoverage = db.SubjectCoverages.Find(id);
            if (subjectCoverage == null)
            {
                return HttpNotFound();
            }
            return View(subjectCoverage);
        }

        // POST: SubjectCoverage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectCoverage subjectCoverage = db.SubjectCoverages.Find(id);
            db.SubjectCoverages.Remove(subjectCoverage);
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
