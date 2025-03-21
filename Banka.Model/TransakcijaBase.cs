﻿using System;

namespace Banka.Model
{
    public abstract class TransakcijaBase : FinancnaOperacijaBase
    {
        public int transakcijaID { get; set; }
        public decimal znesek { get; set; }
        public DateTime datumTransakcije { get; set; }
        public TipTransakcije tip { get; set; }
        public int uporabnikID { get; set; }
        public int uporabnikPrejemnikID { get; set; }

        public override bool ValidirajOperacijo()
        {
            return znesek > 0;
        }

        public abstract bool IzvediTransakcijo();
    }

    public enum TipTransakcije
    {
        priliv,
        odliv
    }
}
