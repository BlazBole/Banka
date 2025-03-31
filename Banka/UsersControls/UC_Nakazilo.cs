using Banka.Bll;
using Banka.Bll.Transakcija;
using Banka.Model;
using System;
using System.Drawing;
using System.Linq;
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

        private async void btnPotrdi_Click(object sender, System.EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtStevilkaRacuna.Text) || string.IsNullOrWhiteSpace(txtZnesek.Text))
            {
                MessageBox.Show("Vnesite številko računa in znesek!", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtZnesek.Text, out decimal znesekPlacilo) || znesekPlacilo <= 0)
            {
                MessageBox.Show("Vnesite veljaven znesek!", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int uporabnikID = _prijavljenUporabnik.uporabnikID;
            string stevilkaRacuna = "SI56" + txtStevilkaRacuna.Text;
            decimal znesek = decimal.Parse(txtZnesek.Text);
            TipTransakcije tipTransakcije = TipTransakcije.odliv;

            NakaziloTransakcija nakaziloTransakcija = new NakaziloTransakcija(uporabnikID, 0, znesek, tipTransakcije);

            int prejemnikID = await nakaziloTransakcija.pridobiUporabnikazStevilkoRacuna(stevilkaRacuna);

            if (prejemnikID != 0)
            {
                nakaziloTransakcija.uporabnikPrejemnikID = prejemnikID;

                bool uspeh = await nakaziloTransakcija.IzvediTransakcijo();

                if (uspeh)
                {
                    MessageBox.Show("Nakazilo je uspešno!");
                    PridobiStanjeUporabnika();
                    lblStanje.ForeColor = Color.OrangeRed;
                    txtStevilkaRacuna.Text = "";
                    txtZnesek.Text = "";
                }
                else
                {
                    MessageBox.Show("Ni dovolj sredstev!");
                }
            }
            else
            {
                MessageBox.Show("Uporabnik s to številko računa ne obstaja!");
            }
        }

        private void txtStevilkaRacuna_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (txtStevilkaRacuna.Text.Length >= 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
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
