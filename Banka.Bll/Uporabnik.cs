using Banka.Model;
using Banka.Dal;

namespace Banka.Bll
{
    public class Uporabnik : UporabnikBase, IUporabnik
    {
        private readonly BankaManager _bankaManager;

        public Uporabnik()
        {
            _bankaManager = new BankaManager(new PovezavaPodatkovnaBaza());
        }

        public bool Registracija(UporabnikBase uporabnik)
        {
            var obstojecUporabnik = _bankaManager.PridobiUporabnika(uporabnik.uporabniskoIme);
            if(obstojecUporabnik != null)
            {
                return false;
            }
            else
            {
                _bankaManager.Registracija(uporabnik);
                return true;
            }
        }

        public bool Prijava()
        {
            var uporabnik = _bankaManager.PridobiUporabnika(this.uporabniskoIme);
            if(uporabnik != null && uporabnik.geslo == this.geslo)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}