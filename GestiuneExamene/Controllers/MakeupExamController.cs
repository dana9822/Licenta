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
    public class MakeupExamController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MakeupExam
        public ActionResult Index()
        {
            var makeupExams = db.MakeupExams.Include(m => m.AcademicYear).Include(m => m.Classroom).Include(m => m.Professor).Include(m => m.Session).Include(m => m.Subject);
            return View(makeupExams.ToList());
        }

        // GET: MakeupExam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakeupExam makeupExam = db.MakeupExams.Find(id);
            if (makeupExam == null)
            {
                return HttpNotFound();
            }
            return View(makeupExam);
        }

        // GET: MakeupExam/Create
        public ActionResult Create()
        {
            ViewBag.AnUniversitar = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar");
            ViewBag.IdCorp = new SelectList(db.Classrooms, "IdCorp", "TipSala");
            ViewBag.MarcaProf = new SelectList(db.Professors, "MarcaProf", "Nume");
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune");
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina");
            return View();
        }

        // POST: MakeupExam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCorp,NrSala,Etaj,MarcaProf,IdDisciplina,IdSesiune,AnUniversitar,IdMakeupExam,Data,Ora,ModEvaluare,Durata")] MakeupExam makeupExam)
        {
            if (ModelState.IsValid)
            {
                db.MakeupExams.Add(makeupExam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnUniversitar = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", makeupExam.AnUniversitar);
            ViewBag.IdCorp = new SelectList(db.Classrooms, "IdCorp", "TipSala", makeupExam.IdCorp);
            ViewBag.MarcaProf = new SelectList(db.Professors, "MarcaProf", "Nume", makeupExam.MarcaProf);
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune", makeupExam.IdSesiune);
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", makeupExam.IdDisciplina);
            return View(makeupExam);
        }

        // GET: MakeupExam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakeupExam makeupExam = db.MakeupExams.Find(id);
            if (makeupExam == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnUniversitar = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", makeupExam.AnUniversitar);
            ViewBag.IdCorp = new SelectList(db.Classrooms, "IdCorp", "TipSala", makeupExam.IdCorp);
            ViewBag.MarcaProf = new SelectList(db.Professors, "MarcaProf", "Nume", makeupExam.MarcaProf);
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune", makeupExam.IdSesiune);
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", makeupExam.IdDisciplina);
            return View(makeupExam);
        }

        // POST: MakeupExam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCorp,NrSala,Etaj,MarcaProf,IdDisciplina,IdSesiune,AnUniversitar,IdMakeupExam,Data,Ora,ModEvaluare,Durata")] MakeupExam makeupExam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makeupExam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnUniversitar = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", makeupExam.AnUniversitar);
            ViewBag.IdCorp = new SelectList(db.Classrooms, "IdCorp", "TipSala", makeupExam.IdCorp);
            ViewBag.MarcaProf = new SelectList(db.Professors, "MarcaProf", "Nume", makeupExam.MarcaProf);
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune", makeupExam.IdSesiune);
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", makeupExam.IdDisciplina);
            return View(makeupExam);
        }

        // GET: MakeupExam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakeupExam makeupExam = db.MakeupExams.Find(id);
            if (makeupExam == null)
            {
                return HttpNotFound();
            }
            return View(makeupExam);
        }

        // POST: MakeupExam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MakeupExam makeupExam = db.MakeupExams.Find(id);
            db.MakeupExams.Remove(makeupExam);
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
