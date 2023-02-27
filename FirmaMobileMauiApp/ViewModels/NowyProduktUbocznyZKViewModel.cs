using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.Services;
using System;
using System.Collections.Generic;

namespace FirmaMobileMauiApp.ViewModels
{
    public class NowyProduktUbocznyZKViewModel : ANewItemViewModel<ProduktyUboczneZKForView>
    {
        private decimal ilosc;
        private bool czyAktywny;
        private ZleceniaKompletacjiForView selectedZlecenieKompletacji;
        private ProduktyForView selectedProdukt;

        public List<ZleceniaKompletacjiForView> ZleceniaKompletacji => new ZlecenieKompletacjiDataStore().Items;
        public List<ProduktyForView> Produkty => new ProduktyDataStore().Items;

        public decimal Ilosc { get => ilosc; set => SetProperty(ref ilosc, value); }
        public bool CzyAktywny { get => czyAktywny; set => SetProperty(ref czyAktywny, value); }
        public ZleceniaKompletacjiForView SelectedZlecenieKompletacji { get => selectedZlecenieKompletacji; set => SetProperty(ref selectedZlecenieKompletacji, value); }
        public ProduktyForView SelectedProdukt { get => selectedProdukt; set => SetProperty(ref selectedProdukt, value); }

        public NowyProduktUbocznyZKViewModel() : base()
        {
            SelectedZlecenieKompletacji = new ZleceniaKompletacjiForView();
            SelectedProdukt = new ProduktyForView();
        }

        public override bool ValidateSave() => !String.IsNullOrWhiteSpace(Ilosc.ToString())
                   && !String.IsNullOrWhiteSpace(selectedZlecenieKompletacji.IdZleceniaKompletacji.ToString())
                   && !String.IsNullOrWhiteSpace(selectedProdukt.Nazwa);

        public override ProduktyUboczneZKForView SetItem() => new ProduktyUboczneZKForView()
        {
            Ilosc = Ilosc,
            CzyAktywny = true,
            IdZleceniaKompletacji = selectedZlecenieKompletacji.IdZleceniaKompletacji,
            ZlecenieKompletacjiDane = "Nr: " + selectedZlecenieKompletacji.IdZleceniaKompletacji
                                    + " z dnia: " + selectedZlecenieKompletacji.DataWystawienia.ToString("dd.MM.yyyy"),
            IdProduktu = selectedProdukt.IdProduktu,
            ProduktDane = selectedProdukt.Kod + ", " + selectedProdukt.Nazwa
        };
    }
}
