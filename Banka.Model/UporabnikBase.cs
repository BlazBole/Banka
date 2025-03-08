namespace Banka.Model
{
    public class UporabnikBase
    {
        public int uporabnikID { get; set; }
        public string ime { get; set; }
        public string priimek { get; set; }
        public string geslo { get; set; }
        public decimal stanje { get; set; }
        public string uporabniskoIme { get; set; }
    }
}
