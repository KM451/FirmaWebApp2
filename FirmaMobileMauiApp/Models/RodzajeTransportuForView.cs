using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Models
{
    public class RodzajeTransportuForView
    {
        public int IdRodzajuTransportu { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public bool CzyAktywny { get; set; }

        public RodzajeTransportuForView() {}
        public RodzajeTransportuForView(RodzajTransportu rodzajTransportu)
        {
            IdRodzajuTransportu = rodzajTransportu.IdRodzajuTransportu;
            Nazwa = rodzajTransportu.Nazwa;
            Uwagi = rodzajTransportu?.Uwagi ?? " ";
            CzyAktywny = rodzajTransportu.CzyAktywny;
        }
    }
}
