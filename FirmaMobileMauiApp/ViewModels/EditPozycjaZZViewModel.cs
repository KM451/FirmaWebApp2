using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.Services;
using System.Diagnostics;

namespace FirmaMobileMauiApp.ViewModels
{
    [QueryProperty(nameof(IdPozycjiZleceniaZakupu), nameof(IdPozycjiZleceniaZakupu))]
    public class EditPozycjaZZViewModel : AEditViewModel<PozycjeZZForView>
    {
        private int idPozycjiZleceniaZakupu;
        private decimal ilosc;
        private decimal rabat;
        private DateTime dataRealizacji;
        private ZleceniaZakupuForView selectedZlecenieZakupu;
        private ProduktyForView selectedProdukt;
        private PozycjeZZForView pozycjaZZForView;

        public List<ZleceniaZakupuForView> ZlecenieZakupu => new ZlecenieZakupuDataStore().Items;
        public List<ProduktyForView> Produkt => new ProduktyDataStore().Items;
        public EditPozycjaZZViewModel()
        {
            pozycjaZZForView = DataStore.GetItemAsync(IdPozycjiZleceniaZakupu).Result;
            LoadIdPozycjiZleceniaZakupu(IdPozycjiZleceniaZakupu);
        }
        public int Id;
        public int IdPozycjiZleceniaZakupu
        {
            get
            {
                return idPozycjiZleceniaZakupu;
            }
            set
            {
                idPozycjiZleceniaZakupu = value;
                LoadIdPozycjiZleceniaZakupu(value);
            }
        }
        public decimal Ilosc { get => ilosc; set => SetProperty(ref ilosc, value); }
        public decimal Rabat { get => rabat; set => SetProperty(ref rabat, value); }
        public DateTime DataRealizacji { get => dataRealizacji; set => SetProperty(ref dataRealizacji, value); }
        public ZleceniaZakupuForView SelectedZlecenieZakupu { get => selectedZlecenieZakupu; set => SetProperty(ref selectedZlecenieZakupu, value); }
        public ProduktyForView SelectedProdukt
        {
            get
            {
                return selectedProdukt;
            }

            set
            {
                if (selectedProdukt != value)
                {
                    SetProperty(ref selectedProdukt, value);
                }
            }
        }
        public PozycjeZZForView PozycjaZZForView { get => pozycjaZZForView; set => SetProperty(ref pozycjaZZForView, value); }

        public async void LoadIdPozycjiZleceniaZakupu(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.IdPozycjiZleceniaZakupu;
                selectedProdukt = Produkt.FirstOrDefault(p => p.IdProduktu == item.IdProduktu);
                selectedZlecenieZakupu = ZlecenieZakupu.FirstOrDefault(tc => tc.IdZleceniaZakupu == item.IdZleceniaZakupu);
                Ilosc = item.Ilosc;
                Rabat = item.Rabat;
                DataRealizacji = ConvertFromDateTimeOffset(item.DataRealizacji);
                PozycjaZZForView = item;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        public override PozycjeZZForView SetItem() => new PozycjeZZForView()
        {
            IdPozycjiZleceniaZakupu = IdPozycjiZleceniaZakupu,
            Ilosc = Ilosc,
            Rabat = Rabat,
            DataRealizacji = DataRealizacji,
            IdZleceniaZakupu = selectedZlecenieZakupu.IdZleceniaZakupu,
            IdProduktu = selectedProdukt.IdProduktu,
            ProduktJednostkaMiary = selectedProdukt.JednostkaMiary,
            ProduktDane = selectedProdukt.Kod + ", " + selectedProdukt.Nazwa,
            ZlecenieZakupuDane = "Nr: " + selectedZlecenieZakupu.IdZleceniaZakupu.ToString() + " z dnia: " + selectedZlecenieZakupu.DataWystawienia.ToString("dd.MM.yyyy")
        };
        static DateTime ConvertFromDateTimeOffset(DateTimeOffset dateTime)
        {
            if (dateTime.Offset.Equals(TimeSpan.Zero))
                return dateTime.UtcDateTime;
            else if (dateTime.Offset.Equals(TimeZoneInfo.Local.GetUtcOffset(dateTime.DateTime)))
                return DateTime.SpecifyKind(dateTime.DateTime, DateTimeKind.Local);
            else
                return dateTime.DateTime;
        }
    }
}
