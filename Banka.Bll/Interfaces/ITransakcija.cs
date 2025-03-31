using System.Threading.Tasks;

namespace Banka.Bll.Interfaces
{
    public interface ITransakcija
    {
        Task<bool> IzvediTransakcijo();
    }
}
