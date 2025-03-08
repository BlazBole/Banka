namespace Banka.Model
{
    public class UporabnikBase<T>
    {
        public int uporabnikID { get; set; }
        public string ime { get; set; }
        public string priimek { get; set; }
        public string geslo { get; set; }
        public decimal stanje { get; set; }
        public T uporabniskoIme { get; set; }
    }
}
