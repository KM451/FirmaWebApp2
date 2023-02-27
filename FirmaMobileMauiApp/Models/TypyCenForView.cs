using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Models
{
    public class TypyCenForView
    {
        public int IdTypuCeny { get; set; }
        public string Typ { get; set; }
        public string Uwagi { get; set; }
        public bool CzyAktywny { get; set; }
        public TypyCenForView() { }
        public TypyCenForView(TypCeny typCeny)
        {
            IdTypuCeny = typCeny.IdTypuCeny;
            Typ = typCeny.Typ;
            Uwagi = typCeny?.Uwagi ?? " ";
            CzyAktywny = typCeny.CzyAktywny;
        }
    }
}
