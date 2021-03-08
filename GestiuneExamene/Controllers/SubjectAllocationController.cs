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
    public class SubjectAllocationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubjectAllocation
        public ActionResult Index()
        {
            var subjectAllocations = db.SubjectAllocations.Include(s => s.Specialization).Include(s => s.StudyYear).Include(s => s.Subject);
            return View(subjectAllocations.ToList());
        }

        // GET: SubjectAllocation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectAllocation subjectAllocation = db.SubjectAllocations.Find(id);
            if (subjectAllocation == null)
            {
                return HttpNotFound();
            }
            return View(subjectAllocation);
        }

        // GET: SubjectAllocation/Create
        public ActionResult Create()
        {
            ViewBag.IdSpecializare = new SelectList(db.Specializations, "IDSpecializare", "DenumireSpecializare");
            ViewBag.AnStudiu = new SelectList(db.StudyYears, "StudyYearId", "AnStudiu");
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina");
            return View();
        }

        // POST: SubjectAllocation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSpecializare,AnStudiu,IdDisciplina,Semestru,TipEvaluare,Status")] SubjectAllocation subjectAllocation)
        {
            if (ModelState.IsValid)
            {
                db.SubjectAllocations.Add(subjectAllocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSpecializare = new SelectList(db.Specializations, "IDSpecializare", "DenumireSpecializare", subjectAllocation.IdSpecializare);
            ViewBag.AnStudiu = new SelectList(db.StudyYears, "StudyYearId", "AnStudiu", subjectAllocation.AnStudiu);
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", subjectAllocation.IdDisciplina);
            return View(subjectAllocation);
        }

        // GET: SubjectAllocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectAllocation subjectAllocation = db.SubjectAllocations.Find(id);
            if (subjectAllocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSpecializare = new SelectList(db.Specializations, "IDSpecializare", "DenumireSpecializare", subjectAllocation.IdSpecializare);
            ViewBag.AnStudiu = new SelectList(db.StudyYears, "StudyYearId", "AnStudiu", subjectAllocation.AnStudiu);
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", subjectAllocation.IdDisciplina);
            return View(subjectAllocation);
        }

        // POST: SubjectAllocation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSpecializare,AnStudiu,IdDisciplina,Semestru,TipEvaluare,Status")] SubjectAllocation subjectAllocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectAllocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSpecializare = new SelectList(db.Specializations, "IDSpecializare", "DenumireSpecializare", subjectAllocation.IdSpecializare);
            ViewBag.AnStudiu = new SelectList(db.StudyYears, "StudyYearId", "AnStudiu", subjectAllocation.AnStudiu);
            ViewBag.IdDisciplina = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", subjectAllocation.IdDisciplina);
            return View(subjectAllocation);
        }

        // GET: SubjectAllocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectAllocation subjectAllocation = db.SubjectAllocations.Find(id);
            if (subjectAllocation == null)
            {
                return HttpNotFound();
            }
            return View(subjectAllocation);
        }

        // POST: SubjectAllocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectAllocation subjectAllocation = db.SubjectAllocations.Find(id);
            db.SubjectAllocations.Remove(subjectAllocation);
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
