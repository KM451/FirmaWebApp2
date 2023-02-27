using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.Services;

namespace FirmaMobileMauiApp.ViewModels
{
    public class NowaPozycjaZZViewModel : ANewItemViewModel<PozycjeZZForView>
    {
        private decimal ilosc;
        private decimal rabat;
        private DateTime dataRealizacji;
        private ZleceniaZakupuForView selectedZlecenieZakupu;
        private ProduktyForView selectedProdukt;

        public List<ZleceniaZakupuForView> ZlecenieZakupu => new ZlecenieZakupuDataStore().Items;
        public List<ProduktyForView> Produkt => new ProduktyDataStore().Items;

        public NowaPozycjaZZViewModel():base()
        {
            selectedZlecenieZakupu = new ZleceniaZakupuForView();
            selectedProdukt = new ProduktyForView();
            rabat = 0;
            dataRealizacji= DateTime.Now;
        }
        public decimal Ilosc
        {
            get => ilosc;
            set => SetProperty(ref ilosc, value);
        }
        public decimal Rabat
        {
            get => rabat;
            set => SetProperty(ref rabat, value);
        }
        public DateTime DataRealizacji
        {
            get => dataRealizacji;
            set => SetProperty(ref dataRealizacji, value);
        }
        public ZleceniaZakupuForView SelectedZlecenieZakupu
        {
            get => selectedZlecenieZakupu;
            set => SetProperty(ref selectedZlecenieZakupu, value);
        }
        public ProduktyForView SelectedProdukt
        {
            get => selectedProdukt;
            set => SetProperty(ref selectedProdukt, value);
        }
        public override PozycjeZZForView SetItem() => new PozycjeZZForView()
        {
            Ilosc = Ilosc,
            Rabat = Rabat,
            DataRealizacji = DataRealizacji,
            IdZleceniaZakupu = selectedZlecenieZakupu.IdZleceniaZakupu,
            IdProduktu = selectedProdukt.IdProduktu,
            ProduktJednostkaMiary = selectedProdukt.JednostkaMiary,
            ProduktDane = selectedProdukt.Kod + ", " + selectedProdukt.Nazwa,
            ZlecenieZakupuDane = "Nr: " + selectedZlecenieZakupu.IdZleceniaZakupu.ToString() + " z dnia: " + selectedZlecenieZakupu.DataWystawienia.ToString("dd.MM.yyyy")
        };

        public override bool ValidateSave() =>
                      !String.IsNullOrWhiteSpace(Ilosc.ToString())
                   && !String.IsNullOrWhiteSpace(DataRealizacji.ToString())
                   && !String.IsNullOrWhiteSpace(selectedZlecenieZakupu.IdZleceniaZakupu.ToString())
                   && !String.IsNullOrWhiteSpace(selectedProdukt.TypProduktuNazwa);
    }
}
