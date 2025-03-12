using Banka.Model;

namespace Banka.Bll
{
    public interface IUporabnik
    {
        bool Registracija(UporabnikBase<string> uporabnik);
        UporabnikBase<string> Prijava(UporabnikBase<string> uporabnik);
    }
}
