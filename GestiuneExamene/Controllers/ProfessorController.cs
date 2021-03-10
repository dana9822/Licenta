using GestiuneExamene.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestiuneExamene.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProfessorController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            List<Professor> professors = db.Professors.ToList();
            ViewBag.Professors = professors;
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            Professor professor = new Professor();
            return View(professor);
        }

        [HttpPost]
        public ActionResult New(Professor professorRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Professors.Add(professorRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(professorRequest);
            }
            catch (Exception e)
            {
                return View(professorRequest);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Professor professor = db.Professors.Find(id);
                if (professor == null)
                {
                    return HttpNotFound("Couldn't find the professor with id " + id.ToString());
                }
                return View(professor);
            }
            return HttpNotFound("Missing professor id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(Professor professorRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Professor professor = db.Professors
                    .SingleOrDefault(b => b.MarcaProf.Equals(professorRequest.MarcaProf));
                    if (TryUpdateModel(professor))
                    {
                        professor.Nume = professorRequest.Nume;
                        professor.Prenume = professorRequest.Prenume;
                        professor.GradDidactic = professorRequest.GradDidactic;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(professorRequest);
            }
            catch (Exception e)
            {
                return View(professorRequest);
            }
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Professor professor = db.Professors.Find(id);
                if (professor != null)
                {
                    return View(professor);
                }
                return HttpNotFound("Couldn't find the professor with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing professor id parameter!");
        }

    }
}