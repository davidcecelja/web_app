using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_app.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public char Spol { get; set; }
        public string Oib { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int GodinaStudija { get; set; }
        public bool RedovanStudent { get; set; }
    }
}