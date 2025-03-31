using System;
using Banka.UsersControls;
using System.Windows.Forms;

namespace Banka.Model
{
    public static class UC_Factory
    {
        public static UserControl Create(string tip, UporabnikBase<string> uporabnik)
        {
            switch (tip)
            {
                case "Transakcije":
                    return new UC_Transakcije(uporabnik);
                case "Nakazilo":
                    return new UC_Nakazilo(uporabnik);
                case "Dvig":
                    return new UC_Dvig(uporabnik);
                default:
                    throw new ArgumentException("Neveljaven tip UserControl-a");
            }
        }
    }
}
