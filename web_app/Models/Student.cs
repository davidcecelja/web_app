using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web_app.Models
{
    public class Student
    {
        [Display(Name = "ID Studenta")]
        public int Id { get; set; }

        [Display(Name = "Ime")]
        public string Ime { get; set; }

        [Display(Name = "Prezime")]
        public string Prezime { get; set; }

        [Display(Name = "Spol")]
        public char Spol { get; set; }

        [Display(Name = "OIB")]
        public string Oib { get; set; }

        [Display(Name = "Datum rođenja")]
        public DateTime DatumRodjenja { get; set; }

        [Display(Name = "Godina studija")]
        public GodinaStudija GodinaStudija { get; set; }

        [Display(Name = "Redovan student")]
        public bool RedovanStudent { get; set; }
    }
}