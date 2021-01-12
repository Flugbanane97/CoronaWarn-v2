using System;
using System.Collections.Generic;

#nullable disable

namespace CoronaWarn
{
    public partial class Benutzer
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime GebDat { get; set; }
        public string Straße { get; set; }
        public int Hausnummer { get; set; }
        public string Ort { get; set; }
        public int Plz { get; set; }
        public bool Positiv { get; set; }
        public DateTime? Seit { get; set; }
        public DateTime? Bis { get; set; }
        public string Email { get; set; }
    }
}
