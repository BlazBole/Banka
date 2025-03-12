using Banka.Bll.Interfaces;
using Banka.Dal;
using Banka.Model;
using System;

namespace Banka.Bll.Transakcija
{
    public class DvigTransakcija : TransakcijaBase, ITransakcija
    {
        private readonly BankaManager _bankaManager;

        public DvigTransakcija(string stevilkaRacunaOpravljalca, decimal znesek)
        {
            StevilkaRacunaOpravljalca = stevilkaRacunaOpravljalca;
            Znesek = znesek;
            DatumTransakcije = DateTime.Now;
            _bankaManager = new BankaManager(PovezavaPodatkovnaBaza.Instance);
        }

        public override bool IzvediTransakcijo()
        {
            var uporabnik = _bankaManager.PridobiUporabnika(StevilkaRacunaOpravljalca);

            if (uporabnik != null && uporabnik.stanje >= Znesek)
            {
                uporabnik.stanje -= Znesek;

                _bankaManager.PosodobiUporabnika(uporabnik);

                _bankaManager.ZabeleziTransakcijo(this);

                return true;
            }

            return false;
        }
    }
}
