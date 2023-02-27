using Firma.Data.Model;


namespace FirmaWebApi.ViewModel
{
    public class ProduktyForView
    {
        public int IdProduktu { get; set; }
        public string Kod { get; set; }
        public string Nazwa { get; set; }
        public string? DodatkowaNazwa { get; set; }
        public string JednostkaMiary { get; set; }
        public string? Symbol { get; set; }
        public string? SWW_PKWiU { get; set; }
        public string Producent { get; set; }
        public int IdTypu { get; set; }
        public string? TypProduktuNazwa { get; set; }
        public string? FotoURL { get; set; }
        public decimal StawkaVatZakupu { get; set; }
        public decimal StawkaVatSprzedazy { get; set; }
        public bool OdwrotneObciazenie { get; set; }
        public bool PodzielonaPlatnosc { get; set; }
        public decimal? StawkaCla { get; set; }
        public decimal? StwkaAkcyzy { get; set; }
        public string? KodPcn { get; set; }
        public string? Kraj { get; set; }
        public int? CzasKompletacji { get; set; }
        public bool CzyAktywna { get; set; }
        public int IdDostawcy { get; set; }
        public string? DostawcaDane { get; set; }

        public static explicit operator Produkt(ProduktyForView produktyForView)
        {
            return new Produkt()
            {
                IdProduktu = produktyForView.IdProduktu,
                Kod = produktyForView.Kod,
                Nazwa = produktyForView.Nazwa,
                DodatkowaNazwa = produktyForView.Nazwa,
                JednostkaMiary = produktyForView.JednostkaMiary,
                Symbol = produktyForView.Symbol,
                SWW_PKWiU = produktyForView.SWW_PKWiU,
                Producent = produktyForView.Producent,
                IdTypu = produktyForView.IdTypu,
                FotoURL = produktyForView.FotoURL,
                StawkaVatZakupu = produktyForView.StawkaVatZakupu,
                StawkaVatSprzedazy = produktyForView.StawkaVatSprzedazy,
                OdwrotneObciazenie = produktyForView.OdwrotneObciazenie,
                PodzielonaPlatnosc = produktyForView.PodzielonaPlatnosc,
                StawkaCla = produktyForView.StawkaCla,
                StwkaAkcyzy = produktyForView.StwkaAkcyzy,
                KodPcn = produktyForView.KodPcn,
                Kraj = produktyForView.Kraj,
                CzasKompletacji = produktyForView.CzasKompletacji,
                CzyAktywna = produktyForView.CzyAktywna,
                IdDostawcy = produktyForView.IdDostawcy
            };
        }
        public static explicit operator ProduktyForView(Produkt produkt)
        {
            return new ProduktyForView() {
                IdProduktu = produkt.IdProduktu,
                Kod = produkt.Kod,
                Nazwa = produkt.Nazwa,
                DodatkowaNazwa = produkt.Nazwa,
                JednostkaMiary = produkt.JednostkaMiary,
                Symbol = produkt.Symbol,
                SWW_PKWiU = produkt.SWW_PKWiU,
                Producent = produkt.Producent,
                IdTypu = produkt.IdTypu,
                FotoURL = produkt.FotoURL,
                StawkaVatZakupu = produkt.StawkaVatZakupu,
                StawkaVatSprzedazy = produkt.StawkaVatSprzedazy,
                OdwrotneObciazenie = produkt.OdwrotneObciazenie,
                PodzielonaPlatnosc = produkt.PodzielonaPlatnosc,
                StawkaCla = produkt.StawkaCla,
                StwkaAkcyzy = produkt.StwkaAkcyzy,
                KodPcn = produkt.KodPcn,
                Kraj = produkt.Kraj,
                CzasKompletacji = produkt.CzasKompletacji,
                CzyAktywna = produkt.CzyAktywna,
                IdDostawcy = produkt.IdDostawcy,
                TypProduktuNazwa = produkt.TypProduktu?.Nazwa,
                DostawcaDane = produkt.Dostawca?.Nazwa
            };
        }
    }
}
