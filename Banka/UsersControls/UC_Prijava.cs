using Banka.Bll;
using Banka.Model;
using System;
using System.Windows.Forms;

namespace Banka.UsersControls
{
    public partial class UC_Prijava : UserControl
    {
        public event EventHandler registracijaKlik;
        public event EventHandler<UporabnikBase<string>> zapriObrazec;

        public UC_Prijava()
        {
            InitializeComponent();
        }

        private void lblRegistracija_Click(object sender, EventArgs e)
        {
            registracijaKlik?.Invoke(this, EventArgs.Empty);
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            string uporabniskoIme = txtUpIme.Text;
            string geslo = txtUpGeslo.Text;


            Uporabnik<string> uporabnikBll = new Uporabnik<string>();
            UporabnikBase<string> prijavljenUporabnik = uporabnikBll.Prijava(new UporabnikBase<string>
            {
                uporabniskoIme = uporabniskoIme,
                geslo = geslo,
            });

            if (prijavljenUporabnik != null)
            {
                MessageBox.Show("Uspešno ste se prijavili!");
                zapriObrazec?.Invoke(this, prijavljenUporabnik);
            }
            else
            {
                MessageBox.Show("Napačno uporabniško ime ali geslo!");
            }
        }
    }
}
