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
    public class MakeupExamRequestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MakeupExamRequest
        public ActionResult Index()
        {
            var makeupExamRequests = db.MakeupExamRequests.Include(m => m.AcademicYear).Include(m => m.Session).Include(m => m.Student).Include(m => m.Subject);
            return View(makeupExamRequests.ToList());
        }

        // GET: MakeupExamRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakeupExamRequest makeupExamRequest = db.MakeupExamRequests.Find(id);
            if (makeupExamRequest == null)
            {
                return HttpNotFound();
            }
            return View(makeupExamRequest);
        }

        // GET: MakeupExamRequest/Create
        public ActionResult Create()
        {
            ViewBag.AnUnivCurent = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar");
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune");
            ViewBag.IdGrupa = new SelectList(db.Students, "IdGrupa", "Username");
            ViewBag.IdDisc = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina");
            return View();
        }

        // POST: MakeupExamRequest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGrupa,IdSpec,AnStudiu,AnUnivStudent,Matricola,IdSesiune,IdDisc,AnUnivCurent")] MakeupExamRequest makeupExamRequest)
        {
            if (ModelState.IsValid)
            {
                db.MakeupExamRequests.Add(makeupExamRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnUnivCurent = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", makeupExamRequest.AnUnivCurent);
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune", makeupExamRequest.IdSesiune);
            ViewBag.IdGrupa = new SelectList(db.Students, "IdGrupa", "Username", makeupExamRequest.IdGrupa);
            ViewBag.IdDisc = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", makeupExamRequest.IdDisc);
            return View(makeupExamRequest);
        }

        // GET: MakeupExamRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakeupExamRequest makeupExamRequest = db.MakeupExamRequests.Find(id);
            if (makeupExamRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnUnivCurent = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", makeupExamRequest.AnUnivCurent);
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune", makeupExamRequest.IdSesiune);
            ViewBag.IdGrupa = new SelectList(db.Students, "IdGrupa", "Username", makeupExamRequest.IdGrupa);
            ViewBag.IdDisc = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", makeupExamRequest.IdDisc);
            return View(makeupExamRequest);
        }

        // POST: MakeupExamRequest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGrupa,IdSpec,AnStudiu,AnUnivStudent,Matricola,IdSesiune,IdDisc,AnUnivCurent")] MakeupExamRequest makeupExamRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makeupExamRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnUnivCurent = new SelectList(db.AcademicYears, "AcademicYearId", "AnUniversitar", makeupExamRequest.AnUnivCurent);
            ViewBag.IdSesiune = new SelectList(db.Sessions, "IdSesiune", "DenumireSesiune", makeupExamRequest.IdSesiune);
            ViewBag.IdGrupa = new SelectList(db.Students, "IdGrupa", "Username", makeupExamRequest.IdGrupa);
            ViewBag.IdDisc = new SelectList(db.Subjects, "IdDisciplina", "DenumireDisciplina", makeupExamRequest.IdDisc);
            return View(makeupExamRequest);
        }

        // GET: MakeupExamRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakeupExamRequest makeupExamRequest = db.MakeupExamRequests.Find(id);
            if (makeupExamRequest == null)
            {
                return HttpNotFound();
            }
            return View(makeupExamRequest);
        }

        // POST: MakeupExamRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MakeupExamRequest makeupExamRequest = db.MakeupExamRequests.Find(id);
            db.MakeupExamRequests.Remove(makeupExamRequest);
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
