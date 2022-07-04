using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web_app.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        public ActionResult Index()
        {
            ViewBag.Lokacija = "MEV";
            return View();
        }
        public ActionResult Home()
        {
            ViewBag.Ustanova = "Međimursko veleučilište";
            ViewData["Lokacija"] = "Čakovec";
            return View();
        }
        public ActionResult Treca(string poruka, int broj = 1)
        {
            ViewBag.Poruka = poruka;
            ViewBag.Broj = broj;
            return View();
        }
        public ActionResult Student()
        {
            ViewBag.Ime = "Ana";
            ViewBag.Prezime = "Cecelja";
            ViewBag.GodRodjenja = 1983;
            return View();
        }
        public string VratiVrijeme()
        {
            return DateTime.Now.ToString();
        }
    }
}