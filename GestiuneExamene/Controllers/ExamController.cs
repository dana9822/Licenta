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
    public class ExamController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Exam
        public ActionResult Index()
        {
            var exams = db.Exams.Include(e => e.Classroom).Include(e => e.Group).Include(e => e.Session).Include(e => e.Subject);
            return View(exams.ToList());
        }

        // GET: Exam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exam/Create
        public ActionResult Create()
        {
            ViewBag.IdCorp = new SelectList(db.Classrooms, "IdCorp", "TipSala");
            ViewBag.IdGrupa = new SelectList(db.Groups, "IdGrupa", "IdGrupa");
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune");
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina");
            return View();
        }

        // POST: Exam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCorp,NrSala,Etaj,IdGrupa,IdSpecializare,AnStudiu,AnUniversitar,IdSesiune,IdDisciplina,ModEvaluare,Data,Ora,Durata,ProfTitular,ProfSupraveghetor")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCorp = new SelectList(db.Classrooms, "IdCorp", "TipSala", exam.IdCorp);
            ViewBag.IdGrupa = new SelectList(db.Groups, "IdGrupa", "IdGrupa", exam.IdGrupa);
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune", exam.IdSesiune);
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", exam.IdDisciplina);
            return View(exam);
        }

        // GET: Exam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCorp = new SelectList(db.Classrooms, "IdCorp", "TipSala", exam.IdCorp);
            ViewBag.IdGrupa = new SelectList(db.Groups, "IdGrupa", "IdGrupa", exam.IdGrupa);
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune", exam.IdSesiune);
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", exam.IdDisciplina);
            return View(exam);
        }

        // POST: Exam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCorp,NrSala,Etaj,IdGrupa,IdSpecializare,AnStudiu,AnUniversitar,IdSesiune,IdDisciplina,ModEvaluare,Data,Ora,Durata,ProfTitular,ProfSupraveghetor")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCorp = new SelectList(db.Classrooms, "IdCorp", "TipSala", exam.IdCorp);
            ViewBag.IdGrupa = new SelectList(db.Groups, "IdGrupa", "IdGrupa", exam.IdGrupa);
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune", exam.IdSesiune);
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", exam.IdDisciplina);
            return View(exam);
        }

        // GET: Exam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
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
