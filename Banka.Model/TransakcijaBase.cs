using System;

namespace Banka.Model
{
    public abstract class TransakcijaBase
    {
        public int TransakcijaID { get; set; }
        public string StevilkaRacunaOpravljalca { get; set; }
        public string StevilkaRacunaPrejemnika { get; set; }
        public decimal Znesek { get; set; }
        public DateTime DatumTransakcije { get; set; }

        public abstract bool IzvediTransakcijo();
    }
}
