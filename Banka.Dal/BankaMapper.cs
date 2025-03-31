using Banka.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Banka.Dal
{
    public class BankaMapper
    {
        public static UporabnikBase<T> MapirajUporabnikBase<T>(SqlDataReader prebrano)
        {
            return new UporabnikBase<T>
            {
                uporabnikID = (int)prebrano["uporabnikID"],
                ime = prebrano["ime"].ToString(),
                priimek = prebrano["priimek"].ToString(),
                stevilkaRacuna = prebrano["stevilkaRacuna"].ToString(),
                uporabniskoIme = (T)Convert.ChangeType(prebrano["uporabniskoIme"], typeof(T)),
                geslo = prebrano["geslo"].ToString(),
                stanje = (decimal)prebrano["stanje"]
            };
        }

        public static dynamic MapirajUporabnika(SqlDataReader prebrano)
        {
            dynamic rezultat = new System.Dynamic.ExpandoObject();
            var dict = (IDictionary<string, object>)rezultat;
            dict["uporabnikID"] = (int)prebrano["uporabnikID"];
            dict["ime"] = prebrano["ime"].ToString();
            dict["priimek"] = prebrano["priimek"].ToString();
            dict["stevilkaRacuna"] = prebrano["stevilkaRacuna"].ToString();
            dict["uporabniskoIme"] = prebrano["uporabniskoIme"].ToString();
            dict["geslo"] = prebrano["geslo"].ToString();
            dict["stanje"] = (decimal)prebrano["stanje"];
            return rezultat;
        }

        public static List<Dictionary<string, object>> MapirajTransakcije(SqlDataReader prebrano)
        {
            var transakcije = new List<Dictionary<string, object>>();

            while (prebrano.Read())
            {
                var transakcija = new Dictionary<string, object>
                {
                    { "transakcijaID", prebrano.GetInt32(prebrano.GetOrdinal("transakcijaID")) },
                    { "znesek", prebrano.GetDecimal(prebrano.GetOrdinal("znesek")) },
                    { "datumTransakcije", prebrano.GetDateTime(prebrano.GetOrdinal("datumTransakcije")) },
                    { "tip", (TipTransakcije)prebrano.GetInt32(prebrano.GetOrdinal("tip")) },
                    { "uporabnikID", prebrano.GetInt32(prebrano.GetOrdinal("uporabnikID")) },
                    { "uporabnikPrejemnikID", prebrano.GetInt32(prebrano.GetOrdinal("uporabnikPrejemnikID")) },
                    { "posiljatelj", prebrano["PosiljateljIme"] != DBNull.Value ? prebrano["PosiljateljIme"].ToString() : "Neznan" },
                    { "prejemnik", prebrano["PrejemnikIme"] != DBNull.Value ? prebrano["PrejemnikIme"].ToString() : "Neznan" }
                };

                transakcije.Add(transakcija);
            }
            return transakcije;
        }
    }
}
