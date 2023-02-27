using Firma.Data.Model;


namespace FirmaWebApi.ViewModel
{
    public class CenyForView
    {
        public int IdCeny { get; set; }
        public int IdProduktu { get; set; }
        public string? ProduktDane { get; set; }
        public int IdTypuCeny { get; set; }
        public string? TypCenyNazwa { get; set; }
        public decimal Wartosc { get; set; }
        public string Waluta { get; set; }
        public bool CzyAktywna { get; set; }

        public static explicit operator Cena(CenyForView cenyForView)
        {
            return new Cena()
            {
                IdCeny = cenyForView.IdCeny,
                IdProduktu = cenyForView.IdProduktu,
                IdTypuCeny = cenyForView.IdTypuCeny,
                Wartosc = cenyForView.Wartosc,
                Waluta = cenyForView.Waluta,
                CzyAktywna = cenyForView.CzyAktywna
            };
        }
        public static explicit operator CenyForView(Cena cena)
        {
            return new CenyForView()
            {
                IdCeny = cena.IdCeny,
                IdProduktu = cena.IdProduktu,
                IdTypuCeny = cena.IdTypuCeny,
                Wartosc = cena.Wartosc,
                Waluta = cena.Waluta,
                CzyAktywna = cena.CzyAktywna,
                ProduktDane = cena.Produkt?.Kod + ", " + cena.Produkt?.Nazwa,
                TypCenyNazwa = cena.TypCeny?.Typ
            };     
        }
    }
}
