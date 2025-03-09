using System;
using System.Data.SqlClient;

namespace Banka.Dal
{
    public sealed class PovezavaPodatkovnaBaza
    {
        private static readonly Lazy<PovezavaPodatkovnaBaza> _instance =
            new Lazy<PovezavaPodatkovnaBaza>(() => new PovezavaPodatkovnaBaza());

        private readonly string _connectionString = "Server=.;Database=BankaDB;Trusted_Connection=True;";

        private PovezavaPodatkovnaBaza() { }

        public static PovezavaPodatkovnaBaza Instance => _instance.Value;

        public SqlConnection PridobiPovezavo()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
