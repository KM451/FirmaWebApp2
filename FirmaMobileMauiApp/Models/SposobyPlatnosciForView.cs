using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Models
{
    public class SposobyPlatnosciForView
    {
        public int IdSposobuPlatnosci { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public bool CzyAktywny { get; set; }
        public SposobyPlatnosciForView(){}
        public SposobyPlatnosciForView(SposobPlatnosci sposobPlatnosci)
        {
            IdSposobuPlatnosci = sposobPlatnosci.IdSposobuPlatnosci;
            Nazwa = sposobPlatnosci.Nazwa;
            Uwagi = sposobPlatnosci?.Uwagi ?? " ";
            CzyAktywny = sposobPlatnosci.CzyAktywny;
        }
    }
}
