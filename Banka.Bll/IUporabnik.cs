using Banka.Model;

namespace Banka.Bll
{
    public interface IUporabnik
    {
        bool Registracija(UporabnikBase uporabnik);
        bool Prijava();
    }
}
