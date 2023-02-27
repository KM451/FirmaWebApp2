using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.ViewModels;
using FirmaMobileMauiApp.Views;
using System;
using System.Diagnostics;


namespace FirmaMobileMauiApp.ViewModels
{
    [QueryProperty(nameof(IdPozycjiZZ), nameof(IdPozycjiZZ))]
    public class DetailPozycjaZZViewModel : ADetailViewModel<PozycjeZZForView>
    {
        public Command<PozycjeZZForView> EditItemCommand { get; }
        public DetailPozycjaZZViewModel(string title)
        {
            Title = title;
            pozycjaZZForView = DataStore.GetItemAsync(IdPozycjiZZ).Result;
            EditItemCommand = new Command<PozycjeZZForView>(OnEditItem);
        }

        private void OnEditItem(PozycjeZZForView obj)
        {
            GoToEditPage(pozycjaZZForView);
        }

        private int idPozycjiZZ;
        private decimal ilosc;
        private decimal rabat;
        private DateTimeOffset dataRealizacji;
        private int idZleceniaZakupu;
        private string zlecenieZakupuDane;
        private int idProduktu;
        private string produktDane;
        private string produktJednostkaMiary;
        private PozycjeZZForView pozycjaZZForView;

        public int Id;
        public int IdPozycjiZZ
        {
            get
            {
                return idPozycjiZZ;
            }
            set
            {
                idPozycjiZZ = value;
                LoadIdPozycjiZZ(value);
            }
        }
        public decimal Ilosc { get => ilosc; set => SetProperty(ref ilosc, value); }
        public decimal Rabat { get => rabat; set => SetProperty(ref rabat, value); }
        public DateTimeOffset DataRealizacji { get => dataRealizacji; set => SetProperty(ref dataRealizacji, value); }
        public string ZlecenieZakupuDane { get => zlecenieZakupuDane; set => SetProperty(ref zlecenieZakupuDane, value); }
        public string ProduktDane { get => produktDane; set => SetProperty(ref produktDane, value); }
        public int IdZleceniaZakupu { get => idZleceniaZakupu; set => SetProperty(ref idZleceniaZakupu, value); }
        public int IdProduktu { get => idProduktu; set => SetProperty(ref idProduktu, value); }
        public string ProduktJednostkaMiary { get => produktJednostkaMiary; set => SetProperty(ref produktJednostkaMiary, value); }
        public PozycjeZZForView PozycjaZZForView { get => pozycjaZZForView; set => SetProperty(ref pozycjaZZForView, value); }

        public async void LoadIdPozycjiZZ(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.IdPozycjiZleceniaZakupu;
                Ilosc = item.Ilosc;
                Rabat = item.Rabat;
                DataRealizacji = item.DataRealizacji;
                IdZleceniaZakupu = item.IdZleceniaZakupu;
                ZlecenieZakupuDane = item.ZlecenieZakupuDane;
                IdProduktu = item.IdProduktu;
                ProduktDane = item.ProduktDane;
                ProduktJednostkaMiary = item.ProduktJednostkaMiary;
                PozycjaZZForView = item;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        public async void GoToEditPage(PozycjeZZForView item)
        {
            await
            Shell.Current.GoToAsync($"{nameof(EditPozycjaZZPage)}?{nameof(EditPozycjaZZViewModel.IdPozycjiZleceniaZakupu)}={item.IdPozycjiZleceniaZakupu}");
        }

    }
}
