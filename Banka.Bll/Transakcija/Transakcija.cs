using Banka.Dal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banka.Bll.Transakcija
{
    public class Transakcija
    {
        private readonly BankaManager _bankaManager;

        public Transakcija()
        {
            _bankaManager = new BankaManager(PovezavaPodatkovnaBaza.Instance);
        }

        public async Task<List<Dictionary<string, object>>> PridobiTransakcijeZaPrikaz(string stevilkaracuna)
        {
            var dictionaryList = await _bankaManager.PridobiVseTransakcije(stevilkaracuna);
            return dictionaryList;
        }
    }
}
