using Banka.Bll;
using Banka.Bll.Transakcija;
using Banka.Model;
using System;
using System.Drawing;
using System.Linq;
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
            PridobiStanjeUporabnika();
        }

        private async void PridobiStanjeUporabnika()
        {
            Uporabnik<string> uporabnikBll = new Uporabnik<string>();
            UporabnikBase<string> uporabnik = await uporabnikBll.PridobiUporabnika(new UporabnikBase<string>
            {
                uporabniskoIme = _prijavljenUporabnik.uporabniskoIme,
            });

            lblStanje.Text = uporabnik.stanje.ToString() + " €";
        }

        private async void btnPotrdi_Click(object sender, EventArgs e)
        {

            if (!decimal.TryParse(txtZnesek.Text, out decimal znesek) || znesek <= 0)
            {
                MessageBox.Show("Vnesite veljaven znesek!", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int uporabnikID = _prijavljenUporabnik.uporabnikID;
            TipTransakcije tipTransakcije = TipTransakcije.priliv;

            DvigTransakcija dvigTransakcijaBll = new DvigTransakcija(uporabnikID, uporabnikID, znesek, tipTransakcije);

            bool uspeh = await dvigTransakcijaBll.IzvediTransakcijo();

            if (uspeh)
            {
                MessageBox.Show("Dvig je bil uspešen!");
                PridobiStanjeUporabnika();
                lblStanje.ForeColor = Color.OrangeRed;
                txtZnesek.Text = "";
            }
            else
            {
                MessageBox.Show("Ni dovolj sredstev!");
            }
        }

        private void txtZnesek_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator)
            {
                e.Handled = true;
            }

            if ((e.KeyChar == decimalSeparator) && txtZnesek.Text.Contains(decimalSeparator))
            {
                e.Handled = true;
            }
        }
    }
}
