using Banka.Bll.Interfaces;
using Banka.Dal;
using Banka.Model;
using System.Threading.Tasks;

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

        public override async Task<bool> IzvediTransakcijo()
        {
            var uporabnikPosiljatelj = await _bankaManager.PridobiStanjeUporabnika(this.uporabnikID);
            var uporabnikPrejemnik = await _bankaManager.PridobiStanjeUporabnika(this.uporabnikPrejemnikID);

            if (uporabnikPosiljatelj != null && uporabnikPrejemnik != null && uporabnikPosiljatelj.stanje >= znesek)
            {
                uporabnikPosiljatelj.stanje -= znesek;
                uporabnikPrejemnik.stanje += znesek;

                _bankaManager.PosodobiUporabnika(uporabnikPosiljatelj.stevilkaRacuna, uporabnikPosiljatelj.stanje);
                _bankaManager.PosodobiUporabnika(uporabnikPrejemnik.stevilkaRacuna, uporabnikPrejemnik.stanje);

                await _bankaManager.ZabeleziTransakcijo(this);

                return true;
            }

            return false;
        }


        public async Task<int> pridobiUporabnikazStevilkoRacuna(string stevilkaRacuna)
        {
            return await _bankaManager.PridobiIDPrejemnika(stevilkaRacuna);
        }
    }
}
