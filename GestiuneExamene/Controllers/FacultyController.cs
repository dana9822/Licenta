using GestiuneExamene.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestiuneExamene.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FacultyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Faculties
        [HttpGet]
        public ActionResult Index()
        {
            List<Faculty> faculties = db.Faculties.ToList();
            ViewBag.Faculties = faculties;
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            Faculty faculty = new Faculty();
            return View(faculty);
        }

        [HttpPost]
        public ActionResult New(Faculty facultyRequest)
        {
            try
            {
                if (ModelState.IsValid) // ModelState - model binding corect si nu sunt incalcate reguli de validare
                {
                    //facultyRequest.Specialization = db.Specializations.FirstOrDefault(p => p.SpecializationID.Equals(1));
                    db.Faculties.Add(facultyRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index"); // RedirectToAction - redirect catre actiunea Index din acelasi controller
                }
                return View(facultyRequest);
            }
            catch (Exception e)
            {
                return View(facultyRequest);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Faculty faculty = db.Faculties.Find(id);
                if (faculty == null)
                {
                    return HttpNotFound("Couldn't find the faculty with id " + id.ToString());
                }
                return View(faculty);
            }
            return HttpNotFound("Missing faculty id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(Faculty facultyRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Faculty faculty = db.Faculties // expresie LINQ
                   //.Include("Publisher")
                    .SingleOrDefault(b => b.IdFacultate.Equals(facultyRequest.IdFacultate));
                    if (TryUpdateModel(faculty)) // de ce TryUpdateModel?
                    {
                        faculty.DenumireFacultate = facultyRequest.DenumireFacultate;
                        faculty.AdresaFacultate = facultyRequest.AdresaFacultate;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(facultyRequest);
            }
            catch (Exception e)
            {
                return View(facultyRequest);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Faculty faculty = db.Faculties.Find(id);
            if (faculty != null)
            {
                db.Faculties.Remove(faculty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the faculty with id " + id.ToString());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Faculty faculty = db.Faculties.Find(id);
                if (faculty != null)
                {
                    return View(faculty);
                }
                return HttpNotFound("Couldn't find the faculty with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing faculty id parameter!");
        }

    }
}