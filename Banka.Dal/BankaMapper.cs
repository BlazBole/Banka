using Banka.Model;
using System.Data.SqlClient;

namespace Banka.Dal
{
    public class BankaMapper
    {
        public static UporabnikBase MapirajUporabnikBase(SqlDataReader prebrano)
        {
            return new UporabnikBase
            {
                uporabnikID = (int)prebrano["uporabnikID"],
                ime = prebrano["ime"].ToString(),
                priimek = prebrano["priimek"].ToString(),
                geslo = prebrano["geslo"].ToString(),
                stanje = (decimal)prebrano["stanje"],
                uporabniskoIme = prebrano["uporabniskoIme"].ToString()
            };
        }
    }
}
