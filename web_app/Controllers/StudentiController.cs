﻿using System;
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
        public ActionResult Popis()
        {
            var studenti = bazaPodataka.PopisStudenata.ToList();
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
                bazaPodataka.Entry(s).State = System.Data.Entity.EntityState.Modified;
                bazaPodataka.SaveChanges();
                return RedirectToAction("Popis");
            }
            return View(s);
        }
    }
}