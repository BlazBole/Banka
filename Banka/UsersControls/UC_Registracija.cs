using System;
using System.Windows.Forms;
using Banka.Bll;
using Banka.Model;
using Banka.Dal;

namespace Banka.UsersControls
{
    public partial class UC_Registracija : UserControl
    {

        public event EventHandler prijavaKlik;


        public UC_Registracija()
        {
            InitializeComponent();

        }

        private void lblPrijava_Click(object sender, EventArgs e)
        {
            prijavaKlik?.Invoke(this, EventArgs.Empty);
        }

        private void btnRegistracija_Click(object sender, EventArgs e)
        {
            string ime = txtIme.Text;
            string priimek = txtPriimek.Text;
            string uporabniskoIme = txtUpIme.Text;
            string geslo = txtUpGeslo.Text;

            UporabnikBase<string> uporabnik = new UporabnikBase<string>
            {
                ime = ime,
                priimek = priimek,
                stevilkaRacuna = "",
                uporabniskoIme = uporabniskoIme,
                geslo = geslo,
                stanje = 0
            };


            Uporabnik<string> uporabnikBll = new Uporabnik<string>();
            bool jeRegistriran = uporabnikBll.Registracija(uporabnik);

            if (jeRegistriran)
            {
                MessageBox.Show("Uspešno ste se registrirali, zdaj se lahko prijavite!");
                prijavaKlik?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Uporabnik s tem uporabniškim imenom že obstaja!");
            }
        }
    }
}
