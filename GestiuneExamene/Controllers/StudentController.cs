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
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Group);
            return View(students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.IdGrupa = new SelectList(db.Groups, "IdGrupa", "nrGrupa");
            ViewBag.IdSPec = new SelectList(db.Groups, "IdSpecializare", "DenumireSpecializare");
            ViewBag.AnStudiu = new SelectList(db.Groups, "AnStudiuId", "StudyYear");
            ViewBag.AnUniv = new SelectList(db.Groups, "AnUniversitarId", "AnUniversitar");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGrupa,IdSpec,AnStudiu,AnUniv,Matricola,Username,Parola,Nume,Prenume,StatusStudent")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGrupa = new SelectList(db.Groups, "IdGrupa", "IdGrupa", student.IdGrupa);
            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGrupa = new SelectList(db.Groups, "IdGrupa", "IdGrupa", student.IdGrupa);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGrupa,IdSpec,AnStudiu,AnUniv,Matricola,Username,Parola,Nume,Prenume,StatusStudent")] Student student)
        {
            if (ModelState.IsValid)
            {
                int OIdGrupa = Convert.ToInt32(Request["IdGrupa"]);
                int OIdSpec = Convert.ToInt32(Request["IdSpec"]);
                int OAnStudiu = Convert.ToInt32(Request["AnStudiu"]);
                int OAnUniv = Convert.ToInt32(Request["LanguageID"]);

                var services = db.Students.Where(a => a.IdGrupa == OIdGrupa)
                                           .Where(a => a.IdSpec == OIdSpec)
                                           .Where(a => a.AnStudiu == OAnStudiu)
                                           .Where(a => a.AnUniv == OAnUniv);
                /* foreach (var s in services)
                {
                    db.Schedule.Remove(s);
                }

                db.Schedule.Add(schedule);
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    return RedirectToAction("Index");
                }
                db.Entry(schedule).State = EntityState.Modified;
                return RedirectToAction("Index");
            }
            ViewBag.DayID = new SelectList(db.Days, "DayID", "Day", schedule.DayID);
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "Language", schedule.LanguageID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Location", schedule.LocationID);
            ViewBag.TimeID = new SelectList(db.Times, "TimeID", "Time", schedule.TimeID);
            return View(schedule);*/
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGrupa = new SelectList(db.Groups, "IdGrupa", "IdGrupa", student.IdGrupa);
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
