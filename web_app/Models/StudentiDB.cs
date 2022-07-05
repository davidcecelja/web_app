using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_app.Models
{
    public class StudentiDB
    {
        private List<Student> lista = new List<Student>();
        public StudentiDB()
        {
            lista.Add(new Student()
            {
                Id = 1,
                Prezime = "Ivić",
                Ime = "Petar",
                DatumRodjenja = new DateTime(1995, 10, 15),
                Spol = 'M',
                GodinaStudija = 2,
                Oib = "12345678911",
                RedovanStudent = false
            });
            lista.Add(new Student()
            {
                Id = 2,
                Prezime = "Marić",
                Ime = "Marko",
                DatumRodjenja = new DateTime(1994, 9, 11),
                Spol = 'M',
                GodinaStudija = 3,
                Oib = "12345678914",
                RedovanStudent = true
            });
            lista.Add(new Student()
            {
                Id = 3,
                Prezime = "Tomić",
                Ime = "Ana",
                DatumRodjenja = new DateTime(1995, 7, 18),
                Spol = 'Ž',
                GodinaStudija = 1,
                Oib = "12345678919",
                RedovanStudent = true
            });
            lista.Add(new Student()
            {
                Id = 4,
                Prezime = "Šerić",
                Ime = "Karlo",
                DatumRodjenja = new DateTime(1993, 11, 15),
                Spol = 'M',
                GodinaStudija = 3,
                Oib = "12345678910",
                RedovanStudent = true
            });
        }
        public List<Student> VratiListu()
        {
            return lista;
        }
    }
}