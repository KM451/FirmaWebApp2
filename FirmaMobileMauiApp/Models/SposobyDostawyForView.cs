using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Models
{
    public class SposobyDostawyForView
    {
        public int IdSposobuDostawy { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public bool CzyAktywny { get; set; }
        public SposobyDostawyForView(){}
        public SposobyDostawyForView(SposobDostawy sposobDostawy)
        {
            IdSposobuDostawy = sposobDostawy.IdSposobuDostawy;
            Nazwa = sposobDostawy.Nazwa;
            Uwagi = sposobDostawy?.Uwagi ?? " ";
            CzyAktywny = sposobDostawy.CzyAktywny;
        }
    }
}
