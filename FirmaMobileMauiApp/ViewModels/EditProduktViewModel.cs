using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace FirmaMobileMauiApp.ViewModels
{
    [QueryProperty(nameof(IdProduktu), nameof(IdProduktu))]
    public class EditProduktViewModel : AEditViewModel<ProduktyForView>
    {
        private int idProduktu;
        private int idTypu;
        private int idDostawcy;
        private int czasKompletacji;
        private decimal stawkaVatZakupu;
        private decimal stawkaVatSprzedazy;
        private decimal stawkaCla;
        private decimal stwkaAkcyzy;
        private string kod;
        private string nazwa;
        private string dodatkowaNazwa;
        private string jednostkaMiary;
        private string symbol;
        private string sWW_PKWiU;
        private string producent;
        private string fotoURL;
        private string kodPcn;
        private string kraj;
        private string dostawcaDane;
        private string typProduktuNazwa;
        private bool odwrotneObciazenie;
        private bool podzielonaPlatnosc;
        private bool czyAktywna;
        private TypyProduktowForView selectedTypProduktu;
        private KontrahenciForView selectedDostawca;
        private ProduktyForView produktForView;
        public EditProduktViewModel()
        {
            produktForView = DataStore.GetItemAsync(IdProduktu).Result;
        }
        public List<TypyProduktowForView> TypProduktu => new TypyProduktowDataStore().Items;
        public List<KontrahenciForView> Dostawcy => new KontrahenciDataStore().Items;

        public int Id;
        public int IdProduktu
        {
            get
            {
                return idProduktu;
            }
            set
            {
                idProduktu = value;
                LoadIdProduktu(value);
            }
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
        public int IdTypu { get => idTypu; set => SetProperty(ref idTypu, value); }
        public string TypProduktuNazwa { get => typProduktuNazwa; set => SetProperty(ref typProduktuNazwa, value); }
        public int IdDostawcy { get => idDostawcy; set => SetProperty(ref idDostawcy, value); }
        public string DostawcaDane { get => dostawcaDane; set => SetProperty(ref dostawcaDane, value); }

        public async void LoadIdProduktu(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.IdProduktu;
                Kod = item.Kod;
                Nazwa = item.Nazwa;
                DodatkowaNazwa = item.DodatkowaNazwa;
                JednostkaMiary = item.JednostkaMiary;
                Symbol = item.Symbol;
                SWW_PKWiU = item.SwW_PKWiU;
                Producent = item.Producent;
                SelectedTypProduktu = TypProduktu.Where(tp => tp.IdTypuProduktu == item.IdTypu).FirstOrDefault();
                FotoURL = item.FotoURL;
                StawkaVatZakupu = item.StawkaVatZakupu;
                StawkaVatSprzedazy = item.StawkaVatSprzedazy;
                OdwrotneObciazenie = item.OdwrotneObciazenie;
                PodzielonaPlatnosc = item.PodzielonaPlatnosc;
                StawkaCla = item?.StawkaCla ?? 0;
                StwkaAkcyzy = item?.StwkaAkcyzy ?? 0;
                KodPcn = item.KodPcn;
                Kraj = item.Kraj;
                CzasKompletacji = item?.CzasKompletacji ?? 0;
                CzyAktywna = item.CzyAktywna;
                SelectedDostawca = Dostawcy.Where(d=>d.IdKontrahenta == item.IdDostawcy).FirstOrDefault();
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        public override ProduktyForView SetItem() => new ProduktyForView()
        {
            IdProduktu = IdProduktu,
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
    }
}

