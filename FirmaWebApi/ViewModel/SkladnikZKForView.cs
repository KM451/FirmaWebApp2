using Firma.Data.Model;

namespace FirmaWebApi.ViewModel
{
    public class SkladnikZKForView
    {
        public int IdSkladnika { get; set; }
        public int IdZleceniaKompletacji { get; set; }
        public string? ZlecenieKompletacjiDane { get; set; }
        public int? IdProduktu { get; set; }
        public string? ProduktDane { get; set; }
        public decimal Ilosc { get; set; }
        public bool CzyAktywny { get; set; }

        public static explicit operator SkladnikZK(SkladnikZKForView skladnikZKForView)
        {
            return new SkladnikZK()
            {
                IdSkladnika = skladnikZKForView.IdSkladnika,
                IdZleceniaKompletacji = skladnikZKForView.IdZleceniaKompletacji,
                IdProduktu = skladnikZKForView.IdProduktu,
                Ilosc = skladnikZKForView.Ilosc,
                CzyAktywny = skladnikZKForView.CzyAktywny
            };
        }
        public static explicit operator SkladnikZKForView(SkladnikZK skladnikZK)
        {
            return new SkladnikZKForView() {
                IdSkladnika = skladnikZK.IdSkladnika,
                IdZleceniaKompletacji = skladnikZK.IdZleceniaKompletacji,
                IdProduktu = skladnikZK.IdProduktu,
                Ilosc = skladnikZK.Ilosc,
                CzyAktywny = skladnikZK.CzyAktywny,
                ZlecenieKompletacjiDane = "Nr: " + skladnikZK.ZlecenieKompletacji.IdZleceniaKompletacji
                                              + " z dnia: " + skladnikZK.ZlecenieKompletacji?.DataWystawienia.ToString("d"),
                ProduktDane = skladnikZK.Produkt?.Kod + ", " + skladnikZK.Produkt?.Nazwa
            };
        }
    }
}
