using Banka.Bll.Transakcija;
using Banka.Model;
using System.Collections.Generic;
using System.Data;
using System;
using System.Windows.Forms;
using Banka.Bll;

namespace Banka.UsersControls
{
    public partial class UC_Transakcije : UserControl
    {
        public UporabnikBase<string> _prijavljenUporabnik;
        public UC_Transakcije(UporabnikBase<string> uporabnik)
        {
            InitializeComponent();
            _prijavljenUporabnik = uporabnik;
            NaloziTransakcije();
            PridobiStanjeUporabnika();
        }

        private DataTable PretvoriVDataTable(List<Dictionary<string, object>> podatki)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("znesek", typeof(decimal));
            dt.Columns.Add("datumTransakcije", typeof(DateTime));
            dt.Columns.Add("tip", typeof(string));
            dt.Columns.Add("prejemnik", typeof(string));

            dt.Columns["znesek"].ColumnName = "Znesek (€)";
            dt.Columns["datumTransakcije"].ColumnName = "Datum";
            dt.Columns["tip"].ColumnName = "Vrsta";
            dt.Columns["prejemnik"].ColumnName = "Prejemnik";

            foreach (var transakcija in podatki)
            {
                DataRow row = dt.NewRow();
                row["Znesek (€)"] = transakcija["znesek"];
                row["Datum"] = transakcija["datumTransakcije"];
                row["Prejemnik"] = transakcija["prejemnik"];

                if (row["Prejemnik"].ToString() == _prijavljenUporabnik.ime)
                {
                    row["Vrsta"] = "Priliv";
                }
                else
                {
                    row["Vrsta"] = "Odliv";
                }

                dt.Rows.Add(row);
            }

            return dt;
        }

        private async void NaloziTransakcije()
        {
            Transakcija transakcija = new Transakcija();
            string stevilkaracunaUporabnika = _prijavljenUporabnik.stevilkaRacuna.ToString();
            var transakcije = await transakcija.PridobiTransakcijeZaPrikaz(stevilkaracunaUporabnika);

            dgwTransakcije.DataSource = PretvoriVDataTable(transakcije);

            dgwTransakcije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgwTransakcije.Dock = DockStyle.Fill;

            dgwTransakcije.AutoResizeColumns();
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
    }
}
