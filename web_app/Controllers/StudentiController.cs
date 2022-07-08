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
        BazaDbContext bazaPodataka = new BazaDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "O Studentima";
            ViewBag.Fakultet = "MEV";
            return View();
        }
        public ActionResult Popis(string naziv, string spol)
        {
            var studenti = bazaPodataka.PopisStudenata.ToList();
            if (!String.IsNullOrWhiteSpace(naziv))
            {
                studenti = studenti.Where(x => x.PrezimeIme.ToUpper().Contains(naziv.ToUpper())).ToList();
            }
            if (!String.IsNullOrWhiteSpace(spol))
            {
                studenti = studenti.Where(x => x.Spol == spol).ToList();
            }
            return View(studenti);
        }
        public ActionResult Detalji(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Popis");
            }
            Student student = bazaPodataka.PopisStudenata.FirstOrDefault(x => x.Id == id);
            if(student == null)
            {
                return RedirectToAction("Popis");
            }
            return View(student);
        }
        public ActionResult Azuriraj(int? id)
        {
            Student student = null;
            if (!id.HasValue)
            {
                student = new Student();
                ViewBag.Title = "Kreiranje studenta";
                ViewBag.Novi = true;
            }
            else
            {
                student = bazaPodataka.PopisStudenata.FirstOrDefault(x => x.Id == id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Title = "Ažuriranje podataka o studentu";
                ViewBag.Novi = false;
            }    
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Azuriraj(Student s)
        {
            if (!OIB.CheckOIB(s.Oib))
            {
                ModelState.AddModelError("Oib", "Neispravan OIB");
            }
            DateTime punoljetan = DateTime.Now.AddYears(-18);
            if(s.DatumRodjenja > punoljetan)
            {
                ModelState.AddModelError("DatumRodjenja", "Osoba nije punoljetna");
            }

            if (ModelState.IsValid)
            {
                if (s.Id != 0)
                {
                    bazaPodataka.Entry(s).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    bazaPodataka.PopisStudenata.Add(s);
                }
                bazaPodataka.SaveChanges();
                return RedirectToAction("Popis");
            }
            if(s.Id == 0)
            {
                ViewBag.Title = "Kreiranje studenta";
                ViewBag.Novi = true;
            }
            else
            {
                ViewBag.Title = "Ažuriranje podataka o studentu";
                ViewBag.Novi = false;
            }
            return View(s);
        }
        public ActionResult Brisi(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Popis");
            }
            Student s = bazaPodataka.PopisStudenata.FirstOrDefault(x => x.Id == id);
            if(s == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = "Potvrda brisanja studenta";
            return View(s);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Brisi(int id)
        {
            Student s = bazaPodataka.PopisStudenata.FirstOrDefault(x => x.Id == id);
            if (s == null)
            {
                return HttpNotFound();
            }
            bazaPodataka.PopisStudenata.Remove(s);
            bazaPodataka.SaveChanges();
            return View("BrisiStatus");
        }
    }
}