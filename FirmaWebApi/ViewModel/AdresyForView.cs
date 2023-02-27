using Firma.Data.Model;

namespace FirmaWebApi.ViewModel
{
    public class AdresyForView
    {
        public int IdAdresu { get; set; }
        public string Ulica { get; set; }
        public string Miejscowosc { get; set; }
        public string NrDomu { get; set; }
        public string NrLokalu { get; set; }
        public string KodPoczowy { get; set; }
        public string Poczta { get; set; }
        public string Kraj { get; set; }
        public bool Siedziba { get; set; }
        public bool Glowny { get; set; }
        public int IdKontrahenta { get; set; }
        public AdresyForView() { }
        public AdresyForView(Adres adres)
        {
            IdAdresu = adres.IdAdresu;
            Ulica = adres.Ulica;
            Miejscowosc = adres.Miejscowosc;
            NrDomu = adres.NrDomu;
            NrLokalu = adres.NrLokalu;
            KodPoczowy = adres.KodPoczowy;
            Poczta = adres.Poczta;
            Kraj = adres.Kraj;
            Siedziba = adres.Siedziba;
            Glowny = adres.Glowny;
            IdKontrahenta = adres.IdKontrahenta;
        }

        public static explicit operator Adres(AdresyForView adresyForView)
        {
            return new Adres()
            {
                IdAdresu = adresyForView.IdAdresu,
                Ulica = adresyForView.Ulica,
                Miejscowosc = adresyForView.Miejscowosc,
                NrDomu = adresyForView.NrDomu,
                NrLokalu = adresyForView.NrLokalu,
                KodPoczowy = adresyForView.KodPoczowy,
                Poczta = adresyForView.Poczta,
                Kraj = adresyForView.Kraj,
                Siedziba = adresyForView.Siedziba,
                CzyAktywny = true
            };
        }
        public static explicit operator AdresyForView(Adres adres)
        {
            return new AdresyForView()
            {
                IdAdresu = adres.IdAdresu,
                Ulica = adres.Ulica,
                Miejscowosc = adres.Miejscowosc,
                NrDomu = adres.NrDomu,
                NrLokalu = adres?.NrLokalu ?? "",
                KodPoczowy = adres?.KodPoczowy ?? "",
                Poczta = adres?.Poczta ?? "",
                Kraj = adres?.Kraj ?? "",
                Siedziba = adres?.Siedziba ?? false,
                Glowny = adres?.Glowny ?? false,
                IdKontrahenta = adres.IdKontrahenta,
            };
        }





    }
}
