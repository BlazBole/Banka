
using Banka.Model;
using System.Data.SqlClient;

namespace Banka.Dal
{
    public class BankaManager
    {
        private readonly PovezavaPodatkovnaBaza _povezava;

        public BankaManager(PovezavaPodatkovnaBaza povezava)
        {
            _povezava = PovezavaPodatkovnaBaza.Instance;
        }

        public void Registracija<T>(UporabnikBase<T> uporabnik)
        {
            using (var povezava = _povezava.PridobiPovezavo())
            {
                string poizvedba = "INSERT INTO Uporabnik (ime, priimek, stevilkaRacuna, uporabniskoIme, geslo, stanje) VALUES (@ime, @priimek, @stevilkaRacuna, @uporabniskoIme, @geslo, @stanje)";
                var komanda = new SqlCommand(poizvedba, povezava);
                komanda.Parameters.AddWithValue("@ime", uporabnik.ime);
                komanda.Parameters.AddWithValue("@priimek", uporabnik.priimek);
                komanda.Parameters.AddWithValue("@stevilkaRacuna", uporabnik.stevilkaRacuna);
                komanda.Parameters.AddWithValue("@uporabniskoIme", uporabnik.uporabniskoIme);
                komanda.Parameters.AddWithValue("@geslo", uporabnik.geslo);
                komanda.Parameters.AddWithValue("@stanje", uporabnik.stanje);

                povezava.Open();
                komanda.ExecuteNonQuery();
            }
        }

        public UporabnikBase<T> PridobiUporabnika<T>(T uporabniskoIme)
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
                    return BankaMapper.MapirajUporabnikBase<T>(prebrano);
                }
                else
                {
                    return null;
                }
            }
        }

        public void PosodobiUporabnika(UporabnikBase<string> uporabnik)
        {
            using (var povezava = _povezava.PridobiPovezavo())
            {
                string poizvedba = "UPDATE Uporabnik SET stanje = @stanje WHERE stevilkaRacuna = @stevilkaRacuna";
                var komanda = new SqlCommand(poizvedba, povezava);
                komanda.Parameters.AddWithValue("@stanje", uporabnik.stanje);
                komanda.Parameters.AddWithValue("@stevilkaRacuna", uporabnik.stevilkaRacuna);

                povezava.Open();
                komanda.ExecuteNonQuery();
            }
        }

        public void ZabeleziTransakcijo(TransakcijaBase transakcija)
        {
            using (var povezava = _povezava.PridobiPovezavo())
            {
                string poizvedba = "INSERT INTO Transakcije (stevilkaRacunaOpravljalca, stevilkaRacunaPrejemnika, znesek, datumTransakcije) " +
                                    "VALUES (@stevilkaRacunaOpravljalca, @stevilkaRacunaPrejemnika, @znesek, @datumTransakcije)";
                var komanda = new SqlCommand(poizvedba, povezava);
                komanda.Parameters.AddWithValue("@stevilkaRacunaOpravljalca", transakcija.StevilkaRacunaOpravljalca);
                komanda.Parameters.AddWithValue("@stevilkaRacunaPrejemnika", transakcija.StevilkaRacunaPrejemnika);
                komanda.Parameters.AddWithValue("@znesek", transakcija.Znesek);
                komanda.Parameters.AddWithValue("@datumTransakcije", transakcija.DatumTransakcije);

                povezava.Open();
                komanda.ExecuteNonQuery();
            }
        }
    }
}
