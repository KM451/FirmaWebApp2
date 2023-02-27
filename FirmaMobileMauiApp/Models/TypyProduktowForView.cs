using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Models
{
    public class TypyProduktowForView
    {
        public int IdTypuProduktu { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public bool CzySklep { get; set; }
        public bool CzyAktywny { get; set; }
        public TypyProduktowForView(){}
        public TypyProduktowForView(TypProduktu typProduktu)
        {
            IdTypuProduktu = typProduktu.IdTypuProduktu;
            Nazwa = typProduktu.Nazwa;
            Uwagi = typProduktu?.Uwagi ?? " ";
            CzySklep = typProduktu.CzySklep;
            CzyAktywny = typProduktu.CzyAktywny;
        }
        
    }
}
