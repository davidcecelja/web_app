using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_app.Models
{
    public class StudentiDB
    {
        private static List<Student> lista = new List<Student>();
        private static bool listaInicijalizirana = false;
        public StudentiDB()
        {
            if (listaInicijalizirana == false)
            {
                listaInicijalizirana = true;
                lista.Add(new Student()
                {
                    Id = 1,
                    Prezime = "Ivić",
                    Ime = "Petar",
                    DatumRodjenja = new DateTime(1995, 10, 15),
                    Spol = 'M',
                    GodinaStudija = GodinaStudija.Druga,
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
                    GodinaStudija = GodinaStudija.Treca,
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
                    GodinaStudija = GodinaStudija.Prva,
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
                    GodinaStudija = GodinaStudija.Peta,
                    Oib = "12345678910",
                    RedovanStudent = true
                });
            }
        }
        public List<Student> VratiListu()
        {
            return lista;
        }
        public void AzurirajStudenta(Student student)
        {
            int studentIndex = lista.FindIndex(x => x.Id == student.Id);
            lista[studentIndex] = student;
        }
    }
}