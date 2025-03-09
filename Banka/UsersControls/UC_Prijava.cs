using Banka.Bll;
using Banka.Model;
using System;
using System.Windows.Forms;

namespace Banka.UsersControls
{
    public partial class UC_Prijava : UserControl
    {
        public event EventHandler registracijaKlik;
        public event EventHandler zapriObrazec;

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

            UporabnikBase<string> uporabnik = new UporabnikBase<string>
            {
                uporabniskoIme = uporabniskoIme,
                geslo = geslo,
            };

            Uporabnik<string> uporabnikBll = new Uporabnik<string>();
            bool jePrijavljen = uporabnikBll.Prijava(uporabnik);

            if (jePrijavljen)
            {
                MessageBox.Show("Uspešno ste se prijavili!");
                zapriObrazec?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Napačno uporabniško ime ali geslo!");
            }
        }
    }
}
