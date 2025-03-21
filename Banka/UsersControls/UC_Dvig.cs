using Banka.Bll;
using Banka.Bll.Transakcija;
using Banka.Model;
using System;
using System.Windows.Forms;

namespace Banka.UsersControls
{
    public partial class UC_Dvig : UserControl
    {
        public UporabnikBase<string> _prijavljenUporabnik;
        public UC_Dvig(UporabnikBase<string> uporabnik)
        {
            InitializeComponent();
            _prijavljenUporabnik = uporabnik;
        }
        private async void btnDvig_Click(object sender, EventArgs e)
        {
            int uporabnikID = _prijavljenUporabnik.uporabnikID;
            decimal znesek = 10m;
            TipTransakcije tipTransakcije = TipTransakcije.priliv;

            DvigTransakcija dvigTransakcijaBll = new DvigTransakcija(uporabnikID, uporabnikID, znesek, tipTransakcije);

            bool uspeh = await dvigTransakcijaBll.IzvediTransakcijo();

            if (uspeh)
            {
                MessageBox.Show("Dvig je bil uspešen!");
            }
            else
            {
                MessageBox.Show("Ni dovolj sredstev ali je prišlo do napake.");
            }
        }
    }
}
