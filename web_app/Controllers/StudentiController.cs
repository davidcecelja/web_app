using System;
using web_app.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace web_app.Controllers
{
    public class StudentiController : Controller
    {
        // GET: Studenti
        public ActionResult Index()
        {
            ViewBag.Title = "O Studentima";
            ViewBag.Fakultet = "MEV";
            return View();
        }
        public ActionResult Popis()
        {
            StudentiDB studentidb = new StudentiDB();
            return View(studentidb);
        }
        public ActionResult Detalji(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Popis");
            }
            StudentiDB studentidb = new StudentiDB();
            Student student = studentidb.VratiListu().FirstOrDefault(x => x.Id == id);
            if(student == null)
            {
                return RedirectToAction("Popis");
            }
            return View(student);
        }
        public ActionResult Azuriraj(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            StudentiDB studentidb = new StudentiDB();
            Student student = studentidb.VratiListu().FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
    }
}