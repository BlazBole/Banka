using System.Data.SqlClient;

namespace Banka.Dal
{
    public class PovezavaPodatkovnaBaza
    {
        private readonly string povezava = "Server=.;Database=BankaDB;Trusted_Connection=True;";

        public SqlConnection PridobiPovezavo()
        {
            return new SqlConnection(povezava);
        }
    }
}
