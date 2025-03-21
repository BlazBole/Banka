using Banka.Model;
using Banka.Dal;
using System;
using System.Threading.Tasks;

namespace Banka.Bll
{
    public class Uporabnik<T> : UporabnikBase<T>, IUporabnik
    {
        private readonly BankaManager _bankaManager;

        public Uporabnik()
        {
            _bankaManager = new BankaManager(PovezavaPodatkovnaBaza.Instance);
        }

        public async Task<bool> Registracija(UporabnikBase<string> uporabnik)
        {
            var obstojecUporabnik = await _bankaManager.PridobiUporabnika(uporabnik.uporabniskoIme);
            if (obstojecUporabnik != null) return false;

            uporabnik.stevilkaRacuna = GenerirajStevilkoRacuna();
            uporabnik.geslo = UporabnikUpravitelj.HashirajGeslo(uporabnik.geslo);

            _bankaManager.Registracija(uporabnik);
            return true;
        }

        public async Task<UporabnikBase<string>> Prijava(UporabnikBase<string> uporabnik)
        {
            var obstojecUporabnik = await _bankaManager.PridobiUporabnika(uporabnik.uporabniskoIme);

            if (obstojecUporabnik != null && UporabnikUpravitelj.PreveriGeslo(uporabnik.geslo, obstojecUporabnik.geslo))
            {
                return obstojecUporabnik;
            }

            return null;
        }


        public static string GenerirajStevilkoRacuna()
        {
            Random rand = new Random();
            string prefix = "SI56";
            string randomPart = rand.Next(100000000, 999999999).ToString();
            return prefix + randomPart;
        }
    }
}