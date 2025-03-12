using Banka.Bll.Interfaces;
using Banka.Dal;
using Banka.Model;
using System;

namespace Banka.Bll.Transakcija
{
    public class NakaziloTransakcija : TransakcijaBase, ITransakcija
    {

        private readonly BankaManager _bankaManager;

        public NakaziloTransakcija(string stevilkaRacunaOpravljalca, string stevilkaRacunaPrejemnika, decimal znesek)
        {
            StevilkaRacunaOpravljalca = stevilkaRacunaOpravljalca;
            StevilkaRacunaPrejemnika = stevilkaRacunaPrejemnika;
            Znesek = znesek;
            DatumTransakcije = DateTime.Now;
            _bankaManager = new BankaManager(PovezavaPodatkovnaBaza.Instance);
        }
        public override bool IzvediTransakcijo()
        {
            var uporabnikOpravljalec = _bankaManager.PridobiUporabnika(StevilkaRacunaOpravljalca);
            var uporabnikPrejemnik = _bankaManager.PridobiUporabnika(StevilkaRacunaPrejemnika);

            if (uporabnikOpravljalec != null && uporabnikPrejemnik != null && uporabnikOpravljalec.stanje >= Znesek)
            {
                uporabnikOpravljalec.stanje -= Znesek;
                uporabnikPrejemnik.stanje += Znesek;

                _bankaManager.PosodobiUporabnika(uporabnikOpravljalec);
                _bankaManager.PosodobiUporabnika(uporabnikPrejemnik);

                _bankaManager.ZabeleziTransakcijo(this);

                return true;
            }

            return false;
        }
    }
}
