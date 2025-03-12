using Banka.Model;
using Banka.UsersControls;
using System;
using System.Windows.Forms;

namespace Banka
{
    public partial class Obrazec : Form
    {

        private UC_Prijava ucPrijava;
        private UC_Registracija ucRegistracija;

        public Obrazec()
        {
            InitializeComponent();
            ucPrijava = new UC_Prijava();
            ucRegistracija = new UC_Registracija();

            PrikaziUc(ucPrijava);

            ucPrijava.registracijaKlik += UC_Prijava_RegistracijaClick;
            ucRegistracija.prijavaKlik += UC_Registracija_PrijavaClick;
            ucPrijava.zapriObrazec += UC_Prijava_ZapriObrazecClick;
        }

        private void PrikaziUc (UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);
        }

        private void UC_Prijava_RegistracijaClick(object sender, EventArgs e)
        {
            PrikaziUc(ucRegistracija);
        }

        private void UC_Registracija_PrijavaClick(object sender, EventArgs e)
        {
            PrikaziUc(ucPrijava);
        }

        private void UC_Prijava_ZapriObrazecClick(object sender, UporabnikBase<string> uporabnik)
        {
            Transakcije transakcijeForm = new Transakcije(uporabnik);
            transakcijeForm.Show();
            this.Hide();
        }
    }
}
