using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.Services;
using System;
using System.Collections.Generic;

namespace FirmaMobileMauiApp.ViewModels
{
    public class NowaCenaViewModel : ANewItemViewModel<CenyForView>
    {
        private decimal wartosc;
        private string waluta;
        private ProduktyForView selectedProdukt;
        private TypyCenForView selectedTypCeny;
        public List<ProduktyForView> Produkt => new ProduktyDataStore().Items;
        public List<TypyCenForView> TypCeny => new TypyCenDataStore().Items;
        public NowaCenaViewModel() : base()
        {
            selectedProdukt = new ProduktyForView();
            selectedTypCeny = new TypyCenForView();
        }
        public decimal Wartosc
        {
            get => wartosc;
            set => SetProperty(ref wartosc, value);
        }
        public string Waluta
        {
            get => waluta;
            set => SetProperty(ref waluta, value);
        }
        public ProduktyForView SelectedProdukt
        {
            get => selectedProdukt;
            set => SetProperty(ref selectedProdukt, value);
        }
        public TypyCenForView SelectedTypCeny
        {
            get => selectedTypCeny;
            set => SetProperty(ref selectedTypCeny, value);
        }
        public override CenyForView SetItem()
        {
            return new CenyForView()
            {
                Wartosc = Wartosc,
                Waluta = Waluta,
                IdProduktu = selectedProdukt.IdProduktu,
                ProduktDane = selectedProdukt.Kod + ", " + selectedProdukt.Nazwa,
                IdTypuCeny = selectedTypCeny.IdTypuCeny,
                TypCenyNazwa = selectedTypCeny.Typ,
                CzyAktywna = true
            };
        }

        public override bool ValidateSave() =>
                      !String.IsNullOrWhiteSpace(Wartosc.ToString())
                   && !String.IsNullOrWhiteSpace(Waluta)
                   && !String.IsNullOrWhiteSpace(selectedProdukt.Kod)
                   && !String.IsNullOrWhiteSpace(selectedTypCeny.Typ);
    }
}
