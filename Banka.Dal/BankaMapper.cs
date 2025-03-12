using Banka.Model;
using System;
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
    }
}
