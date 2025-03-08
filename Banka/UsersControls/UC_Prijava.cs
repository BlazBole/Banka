using System;
using System.Windows.Forms;

namespace Banka.UsersControls
{
    public partial class UC_Prijava : UserControl
    {
        public event EventHandler registracijaKlik;

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

        }
    }
}
