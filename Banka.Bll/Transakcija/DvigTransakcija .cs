using Banka.Bll.Interfaces;
using Banka.Dal;
using Banka.Model;
using System;

namespace Banka.Bll.Transakcija
{
    public class DvigTransakcija : TransakcijaBase, ITransakcija
    {
        private readonly BankaManager _bankaManager;

        public DvigTransakcija(int uporabnikID, decimal znesek, TipTransakcije tipTransakcije)
        {
            this.uporabnikID = uporabnikID;
            this.znesek = znesek;
            this.tip = tipTransakcije;
            _bankaManager = new BankaManager(PovezavaPodatkovnaBaza.Instance);
        }

        public override bool IzvediTransakcijo()
        {
            var uporabnik = _bankaManager.PridobiStanjeUporabnika(this.uporabnikID);

            if (uporabnik != null)
            {
                uporabnik.stanje += znesek;

                _bankaManager.PosodobiUporabnika(uporabnik.stevilkaRacuna, uporabnik.stanje);

                //_bankaManager.ZabeleziTransakcijo(this);

                return true;
            }

            return false;
        }
    }
}
