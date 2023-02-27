using Firma.Data.Model;


namespace FirmaWebApi.ViewModel
{
    public class KontrahenciForView
    {
        public int IdKontrahenta { get; set; }
        public string Akronim { get; set; }
        public string Nazwa { get; set; }
        public string Nip { get; set; }
        public int IdSposobuPlatnosci { get; set; }
        public string SposobPlatnosciNazwa { get; set; }

        public static explicit operator Kontrahent(KontrahenciForView kontrahenciForView)
        {
            return new Kontrahent()
            {
                IdKontrahenta = kontrahenciForView.IdKontrahenta,
                Akronim = kontrahenciForView.Akronim,
                Nazwa = kontrahenciForView.Nazwa,
                Nip = kontrahenciForView.Nip,
                IdSposobuPlatnosci = kontrahenciForView.IdSposobuPlatnosci,
                CzyAktywny = true
            };
        }
        public static explicit operator KontrahenciForView(Kontrahent kontrahent)
        {
            return new KontrahenciForView() 
            {
                IdKontrahenta = kontrahent.IdKontrahenta,
                Akronim = kontrahent.Akronim,
                Nazwa = kontrahent.Nazwa,
                Nip = kontrahent.Nip,
                IdSposobuPlatnosci = kontrahent.IdSposobuPlatnosci,
                SposobPlatnosciNazwa = kontrahent.SposobPlatnosci?.Nazwa
            };
        }
    }
}
