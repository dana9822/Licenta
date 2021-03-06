﻿using System;
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

        [HttpGet]
        public ActionResult Index()
        {
            List<Group> groups = db.Groups.ToList();
            ViewBag.Groups = groups;
            return View();
            
        }

        [HttpGet]
        public ActionResult New()
        {
            Group group = new Group
            {
                SpecializationsList = GetAllSpecializations(),
                StudyYearsList = GetAllStudyYears(),
                AcademicYearsList = GetAllAcademicalYears()
                
            };
            return View(group);
        }

        [HttpPost]
        public ActionResult New(Group groupRequest)
        {
            try
            {
                groupRequest.SpecializationsList = GetAllSpecializations();
                groupRequest.StudyYearsList = GetAllStudyYears();
                groupRequest.AcademicYearsList = GetAllAcademicalYears();
                if (ModelState.IsValid)
                {
                    groupRequest.Specialization = db.Specializations.FirstOrDefault(p => p.IDSpecializare.Equals(1));
                    groupRequest.StudyYear = db.StudyYears.FirstOrDefault(p => p.StudyYearId.Equals(1));
                    groupRequest.AcademicYear = db.AcademicYears.FirstOrDefault(p => p.AcademicYearId.Equals(1));
                    db.Groups.Add(groupRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(groupRequest);
            }
            catch (Exception e)
            {
                return View(groupRequest);
            }
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

        [NonAction] // metoda folosita pentru logica interna
        private IEnumerable<SelectListItem> GetAllSpecializations()
        {
            var selectList = new List<SelectListItem>();
            foreach (var spec in db.Specializations.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = spec.IDSpecializare.ToString(),
                    Text = spec.DenumireSpecializare
                });
            }
            return selectList;
        }

        [NonAction] // metoda folosita pentru logica interna
        private IEnumerable<SelectListItem> GetAllStudyYears()
        {
            var selectList = new List<SelectListItem>();
            foreach (var stdyr in db.StudyYears.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = stdyr.StudyYearId.ToString(),
                    Text = stdyr.AnStudiu
                });
            }
            return selectList;
        }

        [NonAction] // metoda folosita pentru logica interna
        private IEnumerable<SelectListItem> GetAllAcademicalYears()
        {
            var selectList = new List<SelectListItem>();
            foreach (var acdyr in db.AcademicYears.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = acdyr.AcademicYearId.ToString(),
                    Text = acdyr.AnUniversitar
                });
            }
            return selectList;
        }

    }
}
