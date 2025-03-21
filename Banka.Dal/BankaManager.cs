
using Banka.Model;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

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

        public async Task<UporabnikBase<T>> PridobiUporabnika<T>(T uporabniskoIme)
        {
            using (var povezava = _povezava.PridobiPovezavo())
            {
                string poizvedba = "SELECT * FROM Uporabnik WHERE uporabniskoIme = @uporabniskoIme";
                var komanda = new SqlCommand(poizvedba, povezava);
                komanda.Parameters.AddWithValue("@uporabniskoIme", uporabniskoIme);

                await povezava.OpenAsync();
                using (var prebrano = await komanda.ExecuteReaderAsync())
                {
                    if (await prebrano.ReadAsync())
                    {
                        return BankaMapper.MapirajUporabnikBase<T>(prebrano);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public async Task<dynamic> PridobiStanjeUporabnika(int uporabnikID)
        {
            using (var povezava = _povezava.PridobiPovezavo())
            {
                string poizvedba = "SELECT * FROM Uporabnik WHERE uporabnikID = @uporabnikID";
                var komanda = new SqlCommand(poizvedba, povezava);
                komanda.Parameters.AddWithValue("@uporabnikID", uporabnikID);

                await povezava.OpenAsync();
                var prebrano = await komanda.ExecuteReaderAsync();

                if (await prebrano.ReadAsync())
                {
                    return BankaMapper.MapirajUporabnikaTempDynamic(prebrano);
                }
                else
                {
                    return null;
                }
            }
        }


        public void PosodobiUporabnika(string stevilkaRacuna, decimal novoStanje)
        {
          
            using (var povezava = _povezava.PridobiPovezavo())
            {
                string poizvedba = "UPDATE Uporabnik SET stanje = @novoStanje WHERE stevilkaRacuna = @stevilkaRacuna";
                var komanda = new SqlCommand(poizvedba, povezava);
                komanda.Parameters.AddWithValue("@novoStanje", novoStanje);
                komanda.Parameters.AddWithValue("@stevilkaRacuna", stevilkaRacuna);

                povezava.Open();
                komanda.ExecuteNonQuery();
            }
        }

        public async Task<int> PridobiIDPrejemnika(string stevilkaRacuna)
        {
            using (var povezava = _povezava.PridobiPovezavo())
            {
                string poizvedba = "SELECT uporabnikID FROM Uporabnik WHERE stevilkaRacuna = @stevilkaRacuna";
                var komanda = new SqlCommand(poizvedba, povezava);
                komanda.Parameters.AddWithValue("@stevilkaRacuna", stevilkaRacuna);

                await povezava.OpenAsync();
                var rezultat = await komanda.ExecuteScalarAsync();

                if (rezultat != null)
                    return Convert.ToInt32(rezultat);
                else
                    throw new Exception("Uporabnik s to številko računa ne obstaja.");
            }
        }

        public async Task ZabeleziTransakcijo(TransakcijaBase transakcija)
        {
            using (var povezava = _povezava.PridobiPovezavo())
            {
                string sql = "INSERT INTO Transakcija (znesek, datumTransakcije, tip, uporabnikID, uporabnikPrejemnikID) " +
                             "VALUES (@znesek, @datumTransakcije, @tip, @uporabnikID, @uporabnikPrejemnikID)";

                using (var komanda = new SqlCommand(sql, povezava))
                {
                    DateTime datum = (transakcija.datumTransakcije == DateTime.MinValue)
                                        ? DateTime.Now
                                        : transakcija.datumTransakcije;

                    komanda.Parameters.AddWithValue("@znesek", transakcija.znesek);
                    komanda.Parameters.AddWithValue("@datumTransakcije", datum);
                    komanda.Parameters.AddWithValue("@tip", (int)transakcija.tip);
                    komanda.Parameters.AddWithValue("@uporabnikID", transakcija.uporabnikID);
                    komanda.Parameters.AddWithValue("@uporabnikPrejemnikID", transakcija.uporabnikPrejemnikID);

                    await povezava.OpenAsync();
                    await komanda.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
