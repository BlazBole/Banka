using Banka.Model;
using Banka.Dal;
using System;

namespace Banka.Bll
{
    public class Uporabnik<T> : UporabnikBase<T>, IUporabnik
    {
        private readonly BankaManager _bankaManager;

        public Uporabnik()
        {
            _bankaManager = new BankaManager(PovezavaPodatkovnaBaza.Instance);
        }

        public bool Registracija(UporabnikBase<string> uporabnik)
        {
            var obstojecUporabnik = _bankaManager.PridobiUporabnika(uporabnik.uporabniskoIme);
            if(obstojecUporabnik != null)
            {
                return false;
            }
            else
            {
                uporabnik.stevilkaRacuna = GenerirajStevilkoRacuna();
                uporabnik.geslo = UporabnikUpravitelj.HashirajGeslo(uporabnik.geslo);
                _bankaManager.Registracija(uporabnik);
                return true;
            }
        }

        public UporabnikBase<string> Prijava(UporabnikBase<string> uporabnik)
        {
            var obstojecUporabnik = _bankaManager.PridobiUporabnika(uporabnik.uporabniskoIme);
            if(uporabnik != null && UporabnikUpravitelj.PreveriGeslo(uporabnik.geslo, obstojecUporabnik.geslo))
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