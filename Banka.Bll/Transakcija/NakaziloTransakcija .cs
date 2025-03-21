using Banka.Bll.Interfaces;
using Banka.Dal;
using Banka.Model;
using System;

namespace Banka.Bll.Transakcija
{
    public class NakaziloTransakcija : TransakcijaBase, ITransakcija
    {

        private readonly BankaManager _bankaManager;

        public NakaziloTransakcija(int uporabnikPosiljateljID, int uporabnikPrejemnikID, decimal znesek, TipTransakcije tipTransakcije)
        {
            this.uporabnikID = uporabnikPosiljateljID;
            this.uporabnikPrejemnikID = uporabnikPrejemnikID;
            this.znesek = znesek;
            this.tip = tipTransakcije;
            _bankaManager = new BankaManager(PovezavaPodatkovnaBaza.Instance);
        }
        public override bool IzvediTransakcijo()
        {
            var uporabnikPosiljatelj = _bankaManager.PridobiStanjeUporabnika(this.uporabnikID);
            var uporabnikPrejemnik = _bankaManager.PridobiStanjeUporabnika(this.uporabnikPrejemnikID);

            if (uporabnikPosiljatelj != null && uporabnikPrejemnik != null && uporabnikPosiljatelj.stanje >= znesek)
            {
                uporabnikPosiljatelj.stanje -= znesek;
                uporabnikPrejemnik.stanje += znesek;

                _bankaManager.PosodobiUporabnika(uporabnikPosiljatelj.stevilkaRacuna, uporabnikPosiljatelj.stanje);
                _bankaManager.PosodobiUporabnika(uporabnikPrejemnik.stevilkaRacuna, uporabnikPrejemnik.stanje);

                _bankaManager.ZabeleziTransakcijo(this);

                return true;
            }

            return false;
        }

        public int pridobiUporabnikazStevilkoRacuna(string stevilkaRacuna)
        {
            int stevilkaRcuna = _bankaManager.PridobiIDPrejemnika(stevilkaRacuna);

            return stevilkaRcuna;
        }
    }
}
