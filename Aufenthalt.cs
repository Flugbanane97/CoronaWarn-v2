using System;
using System.Collections.Generic;

#nullable disable

namespace CoronaWarn
{
    public partial class Aufenthalt
    {
        public int Id { get; set; }
        public int BenutzerId { get; set; }
        public int LocationId { get; set; }
        public DateTime Datum { get; set; }
    }
}
