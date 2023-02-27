using Firma.Data.Model;
namespace FirmaWebApi.ViewModel
{
    public class ProduktyUboczneZKForView
    {
        public int IdPrUbocznego { get; set; }
        public int IdZleceniaKompletacji { get; set; }
        public string? ZlecenieKompletacjiDane { get; set; }
        public int? IdProduktu { get; set; }
        public string? ProduktDane { get; set; }
        public decimal Ilosc { get; set; }
        public bool CzyAktywny { get; set; }

        public static explicit operator ProduktUbocznyZK(ProduktyUboczneZKForView produktyUboczneZKForView)
        {
            return new ProduktUbocznyZK()
            {
                IdPrUbocznego = produktyUboczneZKForView.IdPrUbocznego,
                IdZleceniaKompletacji = produktyUboczneZKForView.IdZleceniaKompletacji,
                IdProduktu = produktyUboczneZKForView.IdProduktu,
                Ilosc = produktyUboczneZKForView.Ilosc,
                CzyAktywny = produktyUboczneZKForView.CzyAktywny
            };
        }
        public static explicit operator ProduktyUboczneZKForView(ProduktUbocznyZK produktUbocznyZK)
        {
            return new ProduktyUboczneZKForView() {
                IdPrUbocznego = produktUbocznyZK.IdPrUbocznego,
                IdZleceniaKompletacji = produktUbocznyZK.IdZleceniaKompletacji,
                IdProduktu = produktUbocznyZK.IdProduktu,
                Ilosc = produktUbocznyZK.Ilosc,
                CzyAktywny = produktUbocznyZK.CzyAktywny,
                ZlecenieKompletacjiDane = "Nr: " + produktUbocznyZK.ZlecenieKompletacji.IdZleceniaKompletacji
                                              + " z dnia: " + produktUbocznyZK.ZlecenieKompletacji?.DataWystawienia.ToString("d"),
                ProduktDane = produktUbocznyZK.Produkt?.Kod + ", " + produktUbocznyZK.Produkt?.Nazwa
            };
        }
    }
}
