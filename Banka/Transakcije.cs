using Banka.Model;
using System.Windows.Forms;

namespace Banka
{
    public partial class Transakcije : Form
    {
        private UporabnikBase<string> prijavljenUporabnik;
        public Transakcije(UporabnikBase<string> uporabnik)
        {
            InitializeComponent();
            prijavljenUporabnik = uporabnik;
            PrikaziPodatke();
        }

        private void PrikaziPodatke()
        {
            lblUpIme.Text = prijavljenUporabnik.uporabniskoIme.ToString();
            lblStevilkaRacuna.Text = prijavljenUporabnik.stevilkaRacuna.ToString();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
