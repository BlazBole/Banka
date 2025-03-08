
using Banka.Model;
using System.Data.SqlClient;

namespace Banka.Dal
{
    public class BankaManager
    {
        private readonly PovezavaPodatkovnaBaza _povezava;

        public BankaManager(PovezavaPodatkovnaBaza povezava)
        {
            _povezava = new PovezavaPodatkovnaBaza();
        }

        public void Registracija(UporabnikBase uporabnik)
        {
            using (var povezava = _povezava.PridobiPovezavo())
            {
                string poizvedba = "INSERT INTO Uporabnik (ime, priimek, geslo, stanje, uporabniskoIme) VALUES (@ime, @priimek, @geslo, @stanje, @uporabniskoIme)";
                var komanda = new SqlCommand(poizvedba, povezava);
                komanda.Parameters.AddWithValue("@ime", uporabnik.ime);
                komanda.Parameters.AddWithValue("@priimek", uporabnik.priimek);
                komanda.Parameters.AddWithValue("@geslo", uporabnik.geslo);
                komanda.Parameters.AddWithValue("@stanje", uporabnik.stanje);
                komanda.Parameters.AddWithValue("@uporabniskoIme", uporabnik.uporabniskoIme);

                povezava.Open();
                komanda.ExecuteNonQuery();
            }
        }

        public UporabnikBase PridobiUporabnika(string uporabniskoIme)
        {
            using (var povezava = _povezava.PridobiPovezavo())
            {
                string poizvedba = "SELECT * FROM Uporabnik WHERE uporabniskoIme = @uporabniskoIme";
                var komanda = new SqlCommand(poizvedba, povezava);
                komanda.Parameters.AddWithValue("@uporabniskoIme", uporabniskoIme);

                povezava.Open();
                var prebrano = komanda.ExecuteReader();
            
                if (prebrano.Read())
                {
                    return BankaMapper.MapirajUporabnikBase(prebrano);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
