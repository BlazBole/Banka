using Banka.Model;
using Banka.UsersControls;
using System.Windows.Forms;

namespace Banka
{
    public partial class Transakcije : Form
    {
        private UporabnikBase<string> _prijavljenUporabnik;
        public Transakcije(UporabnikBase<string> uporabnik)
        {
            InitializeComponent();
            _prijavljenUporabnik = uporabnik;
            PrikaziPodatke();
            naloziZacetniPogled();
        }

        private void PrikaziPodatke()
        {
            lblUpIme.Text = _prijavljenUporabnik.uporabniskoIme.ToString();
            lblStevilkaRacuna.Text = _prijavljenUporabnik.stevilkaRacuna.ToString();
        }

        private void naloziZacetniPogled()
        {
            UC_Transakcije ucTransakcije = new UC_Transakcije(_prijavljenUporabnik);
            LoadUserControl(ucTransakcije);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void LoadUserControl(UserControl uc)
        {
            pnlVsebina.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlVsebina.Controls.Add(uc);
        }

        private void lblTransakcije_Click(object sender, System.EventArgs e)
        {
            LoadUserControl(UC_Factory.Create("Transakcije", _prijavljenUporabnik));
        }

        private void lblNakazilo_Click(object sender, System.EventArgs e)
        {
            LoadUserControl(UC_Factory.Create("Nakazilo", _prijavljenUporabnik));
        }

        private void lblDvig_Click(object sender, System.EventArgs e)
        {
            LoadUserControl(UC_Factory.Create("Dvig", _prijavljenUporabnik));
        }

        private void lblOdjava_Click(object sender, System.EventArgs e)
        {
            Obrazec odjavaForm = new Obrazec();
            this.Close();
            odjavaForm.Show();
        }
    }
}
