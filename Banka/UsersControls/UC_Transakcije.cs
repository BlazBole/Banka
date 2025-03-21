using Banka.Model;
using System.Windows.Forms;

namespace Banka.UsersControls
{
    public partial class UC_Transakcije : UserControl
    {
        public UporabnikBase<string> _prijavljenUporabnik;
        public UC_Transakcije(UporabnikBase<string> uporabnik)
        {
            InitializeComponent();
            _prijavljenUporabnik = uporabnik;
        }
    }
}
