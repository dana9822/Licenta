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
    public class BuildingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            List<Building> buildings = db.Buildings.ToList();
            ViewBag.Buildings = buildings;
            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Building building = db.Buildings.Find(id);
                if (building != null)
                {
                    return View(building);
                }
                return HttpNotFound("Couldn't find the building with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing building id parameter!");
        }

        [HttpGet]
        public ActionResult New()
        {
            Building building = new Building();
            return View(building);
        }

        [HttpPost]
        public ActionResult New(Building buildingRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Buildings.Add(buildingRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(buildingRequest);
            }
            catch (Exception e)
            {
                return View(buildingRequest);
            }

        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Building building = db.Buildings.Find(id);
                if (building == null)
                {
                    return HttpNotFound("Couldn't find the building with id " + id.ToString());
                }
                return View(building);
            }
            return HttpNotFound("Missing building id parameter!");
        }

        [HttpPut]
        public ActionResult Edit( Building buildingRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Building building = db.Buildings
                    .SingleOrDefault(b => b.IdCorp.Equals(buildingRequest.IdCorp));
                    if (TryUpdateModel(building))
                    {
                        building.DenumireCorp = buildingRequest.DenumireCorp;
                        building.Adresa = buildingRequest.Adresa;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(buildingRequest);
            }
            catch (Exception e)
            {
                return View(buildingRequest);
            }
        }

        // GET: Building/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // POST: Building/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Building building = db.Buildings.Find(id);
            db.Buildings.Remove(building);
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
