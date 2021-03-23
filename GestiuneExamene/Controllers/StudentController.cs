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

        public ActionResult Index()
        {
            List<Student> students = db.Students.ToList();
            ViewBag.Students = students;
            return View();
        }

        public ActionResult New()
        {
            Student student = new Student
            {
                GroupsList = GetAllGroups(),

            };
            return View(student);
        }

        [HttpPost]
        public ActionResult New(Student studentRequest)
        {
            try
            {
                studentRequest.GroupsList = GetAllGroups();
                if (ModelState.IsValid)
                {
                    studentRequest.Group = db.Groups.FirstOrDefault(p => p.IdGrupa.Equals(1));
                    db.Students.Add(studentRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(studentRequest);
            }
            catch (Exception e)
            {
                return View(studentRequest);
            }
        }

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

        [NonAction] // metoda folosita pentru logica interna
        private IEnumerable<SelectListItem> GetAllGroups()
        {
            var selectList = new List<SelectListItem>();
            foreach (var gr in db.Groups.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = gr.IdGrupa.ToString(),
                    Text = gr.Specialization.DenumireSpecializare + " " + gr.nrGrupa + " " + gr.AcademicYear.AnUniversitar
                });
            }
            return selectList;
        }
    }
}
