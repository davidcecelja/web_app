﻿using web_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_app.Misc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace web_app.Controllers
{
    public class KorisniciController : Controller
    {
        BazaDbContext bazaPodataka = new BazaDbContext();
        // GET: Korisnici
        public ActionResult Index()
        {
            var listaKorisnika = bazaPodataka.PopisKorisnika.OrderBy(x => x.SifraOvlasti).ThenBy(x => x.Prezime).ToList();
            return View(listaKorisnika);
        }
        public ActionResult Prijava(string returnUrl)
        {
            KorisnikPrijava model = new KorisnikPrijava();
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }
        public ActionResult Prijava(KorisnikPrijava model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var korisnikBaza = bazaPodataka.PopisKorisnika.FirstOrDefault(x => x.KorisnickoIme == model.KorisnickoIme);
                if (korisnikBaza != null)
                {
                    var passwordOK = korisnikBaza.Lozinka == Misc.PasswordHelper.IzracunajHash(model.Lozinka);
                    if (passwordOK)
                    {
                        LogiraniKorisnik prijavljeniKorisnik = new LogiraniKorisnik(korisnikBaza);
                        LogiraniKorisnikSerializeModel serializeModel = new LogiraniKorisnikSerializeModel();
                        serializeModel.CopyFromUser(prijavljeniKorisnik);
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        string korisnickiPodaci = serializer.Serialize(serializeModel);

                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                            1,
                            prijavljeniKorisnik.Identity.Name,
                            DateTime.Now,
                            DateTime.Now.AddDays(1),
                            false,
                            korisnickiPodaci
                            );

                        string ticketEncrypted = FormsAuthentication.Encrypt(authTicket);

                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketEncrypted);
                        Response.Cookies.Add(cookie);

                        if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Neispravno korisničko ime ili lozinka");
            return View();
        }
        public ActionResult Odjava()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}