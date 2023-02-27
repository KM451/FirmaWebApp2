using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.ViewModels;
using FirmaMobileMauiApp.Views;
using System;
using System.Diagnostics;


namespace FirmaMobileMauiApp.ViewModels
{
    [QueryProperty(nameof(IdProduktu), nameof(IdProduktu))]
    public class DetailProduktViewModel : ADetailViewModel<ProduktyForView>
    {
        public Command<ProduktyForView> EditItemCommand { get; }
        public DetailProduktViewModel(string title)
        {
            Title = title;
            produktForView = DataStore.GetItemAsync(IdProduktu).Result;
            EditItemCommand = new Command<ProduktyForView>(OnEditItem);
        }

        private void OnEditItem(ProduktyForView obj)
        {
            GoToEditPage(produktForView);
        }

        private int idProduktu;
        private string kod;
        private string nazwa;
        private string dodatkowaNazwa;
        private string jednostkaMiary;
        private string symbol;
        private string sWW_PKWiU;
        private string producent;
        private int idTypu;
        private string typProduktuNazwa;
        private string fotoURL;
        private decimal stawkaVatZakupu;
        private decimal stawkaVatSprzedazy;
        private bool odwrotneObciazenie;
        private bool podzielonaPlatnosc;
        private decimal? stawkaCla;
        private decimal? stwkaAkcyzy;
        private string kodPcn;
        private string kraj;
        private int? czasKompletacji;
        private bool czyAktywna;
        private int idDostawcy;
        private string dostawcaDane;
        private ProduktyForView produktForView;

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
        public int IdTypu { get => idTypu; set => SetProperty(ref idTypu, value); }
        public string TypProduktuNazwa { get => typProduktuNazwa; set => SetProperty(ref typProduktuNazwa, value); }
        public string FotoURL { get => fotoURL; set => SetProperty(ref fotoURL, value); }
        public decimal StawkaVatZakupu { get => stawkaVatZakupu; set => SetProperty(ref stawkaVatZakupu, value); }
        public decimal StawkaVatSprzedazy { get => stawkaVatSprzedazy; set => SetProperty(ref stawkaVatSprzedazy, value); }
        public bool OdwrotneObciazenie { get => odwrotneObciazenie; set => SetProperty(ref odwrotneObciazenie, value); }
        public bool PodzielonaPlatnosc { get => podzielonaPlatnosc; set => SetProperty(ref podzielonaPlatnosc, value); }
        public decimal? StawkaCla { get => stawkaCla; set => SetProperty(ref stawkaCla, value); }
        public decimal? StwkaAkcyzy { get => stwkaAkcyzy; set => SetProperty(ref stwkaAkcyzy, value); }
        public string KodPcn { get => kodPcn; set => SetProperty(ref kodPcn, value); }
        public string Kraj { get => kraj; set => SetProperty(ref kraj, value); }
        public int? CzasKompletacji { get => czasKompletacji; set => SetProperty(ref czasKompletacji, value); }
        public bool CzyAktywna { get => czyAktywna; set => SetProperty(ref czyAktywna, value); }
        public int IdDostawcy { get => idDostawcy; set => SetProperty(ref idDostawcy, value); }
        public string DostawcaDane { get => dostawcaDane; set => SetProperty(ref dostawcaDane, value); }
        public ProduktyForView ProduktForView { get => produktForView; set => SetProperty(ref produktForView, value); }

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
                IdTypu = item.IdTypu;
                TypProduktuNazwa = item.TypProduktuNazwa;
                FotoURL = item.FotoURL;
                StawkaVatZakupu = item.StawkaVatZakupu;
                StawkaVatSprzedazy = item.StawkaVatSprzedazy;
                OdwrotneObciazenie = item.OdwrotneObciazenie;
                PodzielonaPlatnosc = item.PodzielonaPlatnosc;
                StawkaCla = item.StawkaCla;
                StwkaAkcyzy = item.StwkaAkcyzy;
                KodPcn = item.KodPcn;
                Kraj = item.Kraj;
                CzasKompletacji = item.CzasKompletacji;
                CzyAktywna = item.CzyAktywna;
                IdDostawcy = item.IdDostawcy;
                DostawcaDane = item.DostawcaDane;
                ProduktForView = item;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public async void GoToEditPage(ProduktyForView item)
        {
            await
            Shell.Current.GoToAsync($"{nameof(EditProduktPage)}?{nameof(EditProduktViewModel.IdProduktu)}={item.IdProduktu}");
        }


    }
}
