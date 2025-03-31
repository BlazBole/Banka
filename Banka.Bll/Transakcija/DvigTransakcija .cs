using Banka.Bll.Interfaces;
using Banka.Dal;
using Banka.Model;
using System.Threading.Tasks;

namespace Banka.Bll.Transakcija
{
    public class DvigTransakcija : TransakcijaBase, ITransakcija
    {
        private readonly BankaManager _bankaManager;

        public DvigTransakcija(int uporabnikPosiljateljID, int uporabnikPrejemnikID, decimal znesek, TipTransakcije tipTransakcije)
        {
            this.uporabnikID = uporabnikPosiljateljID;
            this.uporabnikPrejemnikID = uporabnikPrejemnikID;
            this.znesek = znesek;
            this.tip = tipTransakcije;
            _bankaManager = new BankaManager(PovezavaPodatkovnaBaza.Instance);
        }

        public override async Task<bool> IzvediTransakcijo()
        {
            var uporabnik = await _bankaManager.PridobiStanjeUporabnika(this.uporabnikID);

            if (uporabnik != null)
            {
                uporabnik.stanje += znesek;

                _bankaManager.PosodobiUporabnika(uporabnik.stevilkaRacuna, uporabnik.stanje);

                await _bankaManager.ZabeleziTransakcijo(this);

                return true;
            }

            return false;
        }

    }
}
