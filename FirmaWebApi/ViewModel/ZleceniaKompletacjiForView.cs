using Firma.Data.Model;

namespace FirmaWebApi.ViewModel
{
    public class ZleceniaKompletacjiForView
    {
        public int IdZleceniaKompletacji { get; set; }
        public int IdKontrahenta { get; set; }
        public string? KontrahentDane { get; set; }
        public DateTime DataWystawienia { get; set; }
        public DateTime OczekiwanaDataRealizacji { get; set; }
        public DateTime? PotwierdzonaDataRealizacji { get; set; }
        public int IdProduktu { get; set; }
        public string? ProduktDane { get; set; }
        public decimal Ilosc { get; set; }
        public int? IdMontera { get; set; }
        public string? MonterNazwa { get; set; }
        public int? Priorytet { get; set; }
        public string Status { get; set; }
        public bool CzyAktywne { get; set; }
        public int? CzasZlecenia { get; set; }

        public static explicit operator ZlecenieKompletacji(ZleceniaKompletacjiForView zleceniaKompletacjiForView)
        {
            return new ZlecenieKompletacji()
            {
                IdZleceniaKompletacji = zleceniaKompletacjiForView.IdZleceniaKompletacji,
                IdKontrahenta = zleceniaKompletacjiForView.IdKontrahenta,
                DataWystawienia = zleceniaKompletacjiForView.DataWystawienia,
                OczekiwanaDataRealizacji = zleceniaKompletacjiForView.OczekiwanaDataRealizacji,
                PotwierdzonaDataRealizacji = zleceniaKompletacjiForView.PotwierdzonaDataRealizacji,
                IdProduktu = zleceniaKompletacjiForView.IdProduktu,
                Ilosc = zleceniaKompletacjiForView.Ilosc,
                IdMontera = zleceniaKompletacjiForView.IdMontera,
                Priorytet = zleceniaKompletacjiForView.Priorytet,
                Status = zleceniaKompletacjiForView.Status,
                CzyAktywne = zleceniaKompletacjiForView.CzyAktywne,
                CzasZlecenia = zleceniaKompletacjiForView.CzasZlecenia,
        };
        }
        public static explicit operator ZleceniaKompletacjiForView(ZlecenieKompletacji zlecenieKompletacji)
        {
            return new ZleceniaKompletacjiForView() {
                IdZleceniaKompletacji = zlecenieKompletacji.IdZleceniaKompletacji,
                IdKontrahenta = zlecenieKompletacji.IdKontrahenta,
                DataWystawienia = zlecenieKompletacji.DataWystawienia,
                OczekiwanaDataRealizacji = zlecenieKompletacji.OczekiwanaDataRealizacji,
                PotwierdzonaDataRealizacji = zlecenieKompletacji.PotwierdzonaDataRealizacji,
                IdProduktu = zlecenieKompletacji.IdProduktu,
                Ilosc = zlecenieKompletacji.Ilosc,
                IdMontera = zlecenieKompletacji.IdMontera,
                Priorytet = zlecenieKompletacji.Priorytet,
                Status = zlecenieKompletacji.Status,
                CzyAktywne = zlecenieKompletacji.CzyAktywne,
                CzasZlecenia = zlecenieKompletacji.CzasZlecenia,
                KontrahentDane = zlecenieKompletacji.Kontrahent?.Nazwa + ", NIP: " + zlecenieKompletacji.Kontrahent?.Nip,
                ProduktDane = zlecenieKompletacji.Produkt?.Kod + ", " + zlecenieKompletacji.Produkt?.Nazwa,
                MonterNazwa = zlecenieKompletacji.Monter?.Nazwa
            };
        }
    }
}
