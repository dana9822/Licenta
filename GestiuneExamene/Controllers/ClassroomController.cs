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
    public class ClassroomController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            List<Classroom> classrooms = db.Classrooms.ToList();
            ViewBag.Classrooms = classrooms;
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            Classroom classroom = new Classroom
            {
                BuildingsList = GetAllBuildings()
            };
            return View(classroom);
        }

        [HttpPost]
        public ActionResult New(Classroom classroomRequest)
        {
            try
            {
                classroomRequest.BuildingsList = GetAllBuildings();
                if (ModelState.IsValid)
                {
                    classroomRequest.Building = db.Buildings.FirstOrDefault(p => p.IdCorp.Equals(1));
                    db.Classrooms.Add(classroomRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(classroomRequest);
            }
            catch (Exception e)
            {
                return View(classroomRequest);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Classroom classroom = db.Classrooms.Find(id);
                if (classroom == null)
                {
                    return HttpNotFound("Couldn't find the classroom with id " + id.ToString());
                }
                return View(classroom);
            }
            return HttpNotFound("Missing classroom id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(Classroom classroomRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Classroom classroom = db.Classrooms
                    .SingleOrDefault(b => b.IdCorp.Equals(classroomRequest.IdCorp));
                    if (TryUpdateModel(classroom))
                    {
                        classroom.NrLocuri = classroomRequest.NrLocuri;
                        classroom.TipSala = classroomRequest.TipSala;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(classroomRequest);
            }
            catch (Exception e)
            {
                return View(classroomRequest);
            }
        }

        [HttpGet]
        public ActionResult Details(int? id)   // PK E COMPUSA !!!!! PK = idCorp + nrSala + etaj , idCorp = FK
        {
            if (id.HasValue)
            {
                Classroom classroom = db.Classrooms.Find(id);
                if (classroom != null)
                {
                    return View(classroom);
                }
                return HttpNotFound("Couldn't find the classroom with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing classroom id parameter!");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classroom classroom = db.Classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Classroom classroom = db.Classrooms.Find(id);
            db.Classrooms.Remove(classroom);
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
        private IEnumerable<SelectListItem> GetAllBuildings()
        {
            var selectList = new List<SelectListItem>();
            foreach (var building in db.Buildings.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = building.IdCorp.ToString(),
                    Text = building.DenumireCorp
                });
            }
            return selectList;
        }
    }
}
