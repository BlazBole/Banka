using Banka.Model;
using System.Threading.Tasks;

namespace Banka.Bll
{
    public interface IUporabnik
    {
        Task<bool> Registracija(UporabnikBase<string> uporabnik);
        Task<UporabnikBase<string>> Prijava(UporabnikBase<string> uporabnik);
    }
}
