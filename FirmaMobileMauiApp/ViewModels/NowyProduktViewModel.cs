using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.Services;
using System;
using System.Collections.Generic;

namespace FirmaMobileMauiApp.ViewModels
{
    public class NowyProduktViewModel : ANewItemViewModel<ProduktyForView>
    {
        private string kod;
        private string nazwa;
        private string dodatkowaNazwa;
        private string jednostkaMiary;
        private string symbol;
        private string sWW_PKWiU;
        private string producent;
        private TypyProduktowForView selectedTypProduktu;
        private string fotoURL;
        private decimal stawkaVatZakupu;
        private decimal stawkaVatSprzedazy;
        private bool odwrotneObciazenie;
        private bool podzielonaPlatnosc;
        private decimal stawkaCla;
        private decimal stwkaAkcyzy;
        private string kodPcn;
        private string kraj;
        private int czasKompletacji;
        private bool czyAktywna;
        private KontrahenciForView selectedDostawca;

        public List<TypyProduktowForView> TypProduktu => new TypyProduktowDataStore().Items;
        public List<KontrahenciForView> Dostawcy => new KontrahenciDataStore().Items;
        public NowyProduktViewModel(string title) 
        {
            SelectedTypProduktu = new TypyProduktowForView();
            SelectedDostawca = new KontrahenciForView();
        }
        public string Kod { get => kod; set => SetProperty(ref kod, value); }
        public string Nazwa { get => nazwa; set => SetProperty(ref nazwa, value); }
        public string DodatkowaNazwa { get => dodatkowaNazwa; set => SetProperty(ref dodatkowaNazwa, value); }
        public string JednostkaMiary { get => jednostkaMiary; set => SetProperty(ref jednostkaMiary, value); }
        public string Symbol { get => symbol; set => SetProperty(ref symbol, value); }
        public string SWW_PKWiU { get => sWW_PKWiU; set => SetProperty(ref sWW_PKWiU, value); }
        public string Producent { get => producent; set => SetProperty(ref producent, value); }
        public TypyProduktowForView SelectedTypProduktu { get => selectedTypProduktu; set => SetProperty(ref selectedTypProduktu, value); }
        public string FotoURL { get => fotoURL; set => SetProperty(ref fotoURL, value); }
        public decimal StawkaVatZakupu { get => stawkaVatZakupu; set => SetProperty(ref stawkaVatZakupu, value); }
        public decimal StawkaVatSprzedazy { get => stawkaVatSprzedazy; set => SetProperty(ref stawkaVatSprzedazy, value); }
        public bool OdwrotneObciazenie { get => odwrotneObciazenie; set => SetProperty(ref odwrotneObciazenie, value); }
        public bool PodzielonaPlatnosc { get => podzielonaPlatnosc; set => SetProperty(ref podzielonaPlatnosc, value); }
        public decimal StawkaCla { get => stawkaCla; set => SetProperty(ref stawkaCla, value); }
        public decimal StwkaAkcyzy { get => stwkaAkcyzy; set => SetProperty(ref stwkaAkcyzy, value); }
        public string KodPcn { get => kodPcn; set => SetProperty(ref kodPcn, value); }
        public string Kraj { get => kraj; set => SetProperty(ref kraj, value); }
        public int CzasKompletacji { get => czasKompletacji; set => SetProperty(ref czasKompletacji, value); }
        public bool CzyAktywna { get => czyAktywna; set => SetProperty(ref czyAktywna, value); }
        public KontrahenciForView SelectedDostawca { get => selectedDostawca; set => SetProperty(ref selectedDostawca, value); }

        public override ProduktyForView SetItem() => new ProduktyForView()
        {
            Kod = Kod,
            Nazwa = Nazwa,
            DodatkowaNazwa = DodatkowaNazwa,
            JednostkaMiary = JednostkaMiary,
            Symbol = Symbol,
            SwW_PKWiU = SWW_PKWiU,
            Producent = Producent,
            IdTypu = selectedTypProduktu.IdTypuProduktu,
            TypProduktuNazwa = selectedTypProduktu.Nazwa,
            FotoURL = FotoURL,
            StawkaVatZakupu = StawkaVatZakupu,
            StawkaVatSprzedazy = StawkaVatSprzedazy,
            OdwrotneObciazenie = OdwrotneObciazenie,
            PodzielonaPlatnosc = PodzielonaPlatnosc,
            StawkaCla = StawkaCla,
            StwkaAkcyzy = StwkaAkcyzy,
            KodPcn = KodPcn,
            Kraj = Kraj,
            CzasKompletacji = CzasKompletacji,
            CzyAktywna = true,
            IdDostawcy = selectedDostawca.IdKontrahenta,
            DostawcaDane = selectedDostawca.Nazwa
        };
        public override bool ValidateSave() => !String.IsNullOrWhiteSpace(Kod)
                   && !String.IsNullOrWhiteSpace(Nazwa)
                   && !String.IsNullOrWhiteSpace(JednostkaMiary)
                   && !String.IsNullOrWhiteSpace(Producent)
                   && !String.IsNullOrWhiteSpace(selectedTypProduktu.Nazwa)
                   && !String.IsNullOrWhiteSpace(StawkaVatZakupu.ToString())
                   && !String.IsNullOrWhiteSpace(StawkaVatSprzedazy.ToString())
                   && !String.IsNullOrWhiteSpace(selectedDostawca.Nazwa);

    }
}
