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
    }
}