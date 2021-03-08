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
    public class GroupController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Group
        public ActionResult Index()
        {
            var groups = db.Groups.Include(g => g.AcademicYear).Include(g => g.Specialization).Include(g => g.StudyYear);
            return View(groups.ToList());
        }

        // GET: Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Group/Create
        public ActionResult Create()
        {
            ViewBag.AnUniversitarId = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar");
            ViewBag.IdSpecializare = new SelectList(db.Specializations, "IDSpecializare", "DenumireSpecializare");
            ViewBag.AnStudiuId = new SelectList(db.StudyYears, "StudyYearId", "AnStudiu");
            return View();
        }

        // POST: Group/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGrupa,IdSpecializare,AnStudiuId,AnUniversitarId,nrGrupa,NrStudenti")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnUniversitarId = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", group.AnUniversitarId);
            ViewBag.IdSpecializare = new SelectList(db.Specializations, "IDSpecializare", "DenumireSpecializare", group.IdSpecializare);
            ViewBag.AnStudiuId = new SelectList(db.StudyYears, "StudyYearId", "AnStudiu", group.AnStudiuId);
            return View(group);
        }

        // GET: Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnUniversitarId = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", group.AnUniversitarId);
            ViewBag.IdSpecializare = new SelectList(db.Specializations, "IDSpecializare", "DenumireSpecializare", group.IdSpecializare);
            ViewBag.AnStudiuId = new SelectList(db.StudyYears, "StudyYearId", "AnStudiu", group.AnStudiuId);
            return View(group);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGrupa,IdSpecializare,AnStudiuId,AnUniversitarId,nrGrupa,NrStudenti")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnUniversitarId = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", group.AnUniversitarId);
            ViewBag.IdSpecializare = new SelectList(db.Specializations, "IDSpecializare", "DenumireSpecializare", group.IdSpecializare);
            ViewBag.AnStudiuId = new SelectList(db.StudyYears, "StudyYearId", "AnStudiu", group.AnStudiuId);
            return View(group);
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
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
