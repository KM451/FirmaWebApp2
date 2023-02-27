using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.ViewModels;
using FirmaMobileMauiApp.Views;
using System;
using System.Diagnostics;


namespace FirmaMobileMauiApp.ViewModels
{
    [QueryProperty(nameof(IdCeny), nameof(IdCeny))]
    public class DetailCenaViewModel : ADetailViewModel<CenyForView>
    {
        public Command<CenyForView> EditItemCommand { get; }
        public DetailCenaViewModel(string title)
        {
            Title = title;
            cenaForView = DataStore.GetItemAsync(IdCeny).Result;
            EditItemCommand = new Command<CenyForView>(OnEditItem);
        }

        private void OnEditItem(CenyForView obj)
        {
            GoToEditPage(cenaForView);
        }

        private int idCeny;
        private int idProduktu;
        private string produktDane;
        private int idTypuCeny;
        private string typCenyNazwa;
        private decimal wartosc;
        private string waluta;
        private bool czyAktywna;
        private CenyForView cenaForView;

        public int Id;
        public int IdCeny
        {
            get
            {
                return idCeny;
            }
            set
            {
                idCeny = value;
                LoadIdCeny(value);
            }
        }

        public int IdProduktu { get => idProduktu; set => SetProperty(ref idProduktu, value); }
        public string ProduktDane { get => produktDane; set => SetProperty(ref produktDane, value); }
        public int IdTypuCeny { get => idTypuCeny; set => SetProperty(ref idTypuCeny, value); }
        public string TypCenyNazwa { get => typCenyNazwa; set => SetProperty(ref typCenyNazwa, value); }
        public decimal Wartosc { get => wartosc; set => SetProperty(ref wartosc, value); }
        public string Waluta { get => waluta; set => SetProperty(ref waluta, value); }
        public bool CzyAktywna { get => czyAktywna; set => SetProperty(ref czyAktywna, value); }
        public CenyForView CenaForView { get => cenaForView; set => SetProperty(ref cenaForView, value); }

        public async void LoadIdCeny(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.IdCeny;
                IdProduktu = item.IdProduktu;
                ProduktDane = item.ProduktDane;
                IdTypuCeny = item.IdTypuCeny;
                TypCenyNazwa = item.TypCenyNazwa;
                Wartosc = item.Wartosc;
                Waluta = item.Waluta;
                CzyAktywna = item.CzyAktywna;
                CenaForView = item;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public async void GoToEditPage(CenyForView item)
        {
            await
            Shell.Current.GoToAsync($"{nameof(EditCenaPage)}?{nameof(EditCenaViewModel.IdCeny)}={item.IdCeny}");
        }
    }
}
