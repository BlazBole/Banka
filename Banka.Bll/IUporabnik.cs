using Banka.Model;

namespace Banka.Bll
{
    public interface IUporabnik
    {
        bool Registracija<T>(UporabnikBase<T> uporabnik);
        bool Prijava();
    }
}
