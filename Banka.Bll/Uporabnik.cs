﻿using Banka.Model;
using Banka.Dal;

namespace Banka.Bll
{
    public class Uporabnik<T> : UporabnikBase<T>, IUporabnik
    {
        private readonly BankaManager _bankaManager;

        public Uporabnik()
        {
            _bankaManager = new BankaManager(new PovezavaPodatkovnaBaza());
        }

        public bool Registracija<T>(UporabnikBase<T> uporabnik)
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

        public bool Prijava<T>(UporabnikBase<T> uporabnik)
        {
            var obstojecUporabnik = _bankaManager.PridobiUporabnika(uporabnik.uporabniskoIme);
            if(uporabnik != null && uporabnik.geslo == obstojecUporabnik.geslo)
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