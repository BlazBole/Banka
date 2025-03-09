namespace Banka.Bll
{
    public static class UporabnikUpravitelj
    {
        public static string HashirajGeslo(string geslo)
        {
            return BCrypt.Net.BCrypt.HashPassword(geslo);
        }

        public static bool PreveriGeslo(string vnesenoGeslo, string hashiranoGeslo)
        {
            return BCrypt.Net.BCrypt.Verify(vnesenoGeslo, hashiranoGeslo);
        }
    }
}
