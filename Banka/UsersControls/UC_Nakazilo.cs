using Banka.Bll.Transakcija;
using Banka.Model;
using System.Windows.Forms;

namespace Banka.UsersControls
{
    public partial class UC_Nakazilo : UserControl
    {
        public UporabnikBase<string> _prijavljenUporabnik;
        public UC_Nakazilo(UporabnikBase<string> uporabnik)
        {
            InitializeComponent();
            _prijavljenUporabnik = uporabnik;
        }

        private async void btnPolog_Click(object sender, System.EventArgs e)
        {
            int uporabnikID = _prijavljenUporabnik.uporabnikID;
            string stevilkaRacuna = "SI56194003828";
            decimal znesek = 30m;
            TipTransakcije tipTransakcije = TipTransakcije.odliv;

            NakaziloTransakcija nakaziloTransakcija = new NakaziloTransakcija(uporabnikID, 0, znesek, tipTransakcije);

            int prejemnikID = await nakaziloTransakcija.pridobiUporabnikazStevilkoRacuna(stevilkaRacuna);

            nakaziloTransakcija.uporabnikPrejemnikID = prejemnikID;

            bool uspeh = await nakaziloTransakcija.IzvediTransakcijo();

            if (uspeh)
            {
                MessageBox.Show("Nakazilo je uspešno!");
            }
            else
            {
                MessageBox.Show("Ni dovolj sredstev ali je prišlo do napake.");
            }
        }
    }
}
