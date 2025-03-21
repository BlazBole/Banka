using System;

namespace Banka.Model
{
    public abstract class FinancnaOperacijaBase
    {
        public DateTime datumUstvarjeno { get; set; } = DateTime.Now;

        public abstract bool ValidirajOperacijo();
    }
}
