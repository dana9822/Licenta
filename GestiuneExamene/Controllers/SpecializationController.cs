using GestiuneExamene.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestiuneExamene.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SpecializationController : Controller
    {
        // GET: Specialization
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Specializations
        [HttpGet]
        public ActionResult Index()
        {
            //List<Specialization> specializations = db.Specializations.Include("Faculty").ToList();
            List<Specialization> specializations = db.Specializations.ToList();
            ViewBag.Specializations = specializations;
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            Specialization specialization = new Specialization
            {
                FacultiesList = GetAllFaculties()
            };
            return View(specialization);
        }

        [HttpPost]
        public ActionResult New(Specialization specializationRequest)
        {
            try
            {
                specializationRequest.FacultiesList = GetAllFaculties();
                if (ModelState.IsValid) // ModelState - model binding corect si nu sunt incalcate reguli de validare
                {
                    specializationRequest.Faculty = db.Faculties.FirstOrDefault(p => p.IdFacultate.Equals(1));
                    db.Specializations.Add(specializationRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index"); // RedirectToAction - redirect catre actiunea Index din acelasi controller
                }
                return View(specializationRequest);
            }
            catch (Exception e)
            {
                return View(specializationRequest);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Specialization specialization = db.Specializations.Find(id);
                if (specialization == null)
                {
                    return HttpNotFound("Couldn't find the specialization with id " + id.ToString());
                }
                return View(specialization);
            }
            return HttpNotFound("Missing specialization id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(Specialization specializationRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Specialization specialization = db.Specializations // expresie LINQ
                                                   //.Include("Faculty")
                    .SingleOrDefault(b => b.IDSpecializare.Equals(specializationRequest.IDSpecializare));
                    if (TryUpdateModel(specialization)) 
                    {
                        specialization.DenumireSpecializare = specializationRequest.DenumireSpecializare;
                        specialization.FormaInvatamant = specializationRequest.FormaInvatamant;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(specializationRequest);
            }
            catch (Exception e)
            {
                return View(specializationRequest);
            }
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Specialization specialization = db.Specializations.Find(id);
                if (specialization != null)
                {
                    return View(specialization);
                }
                return HttpNotFound("Couldn't find the specialization with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing specialization id parameter!");
        }

        [NonAction] // metoda folosita pentru logica interna
        private IEnumerable<SelectListItem> GetAllFaculties()
        {
            var selectList = new List<SelectListItem>();
            foreach (var cover in db.Faculties.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = cover.IdFacultate.ToString(),
                    Text = cover.DenumireFacultate
                });
            }
            return selectList;
        }
    }
}