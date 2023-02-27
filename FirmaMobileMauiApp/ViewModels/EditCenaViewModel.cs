using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace FirmaMobileMauiApp.ViewModels
{
    [QueryProperty(nameof(IdCeny), nameof(IdCeny))]
    public class EditCenaViewModel : AEditViewModel<CenyForView>
    {
        private int idCeny;
        private decimal wartosc;
        private string waluta;
        private CenyForView cenaForView;
        private ProduktyForView selectedProdukt;
        private TypyCenForView selectedTypCeny;
        public List<ProduktyForView> Produkt => new ProduktyDataStore().Items;
        public List<TypyCenForView> TypCeny => new TypyCenDataStore().Items;
        public EditCenaViewModel()
        {
            cenaForView = DataStore.GetItemAsync(IdCeny).Result;
        }

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

        public decimal Wartosc { get => wartosc; set => SetProperty(ref wartosc, value); }
        public string Waluta { get => waluta; set => SetProperty(ref waluta, value); }
        public ProduktyForView SelectedProdukt { get { return selectedProdukt; } set { SetProperty(ref selectedProdukt, value); } }
        public TypyCenForView SelectedTypCeny { get => selectedTypCeny; set => SetProperty(ref selectedTypCeny, value); }
        public CenyForView CenaForView { get => cenaForView; set => SetProperty(ref cenaForView, value); }

        public async void LoadIdCeny(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.IdCeny;
                SelectedProdukt = Produkt.Where(p => p.IdProduktu == item.IdProduktu).FirstOrDefault();
                SelectedTypCeny = TypCeny.Where(tc => tc.IdTypuCeny == item.IdTypuCeny).FirstOrDefault();
                Wartosc = item.Wartosc;
                Waluta = item.Waluta;
                CenaForView = item;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        public override CenyForView SetItem() => new CenyForView()
        {
            IdCeny = IdCeny,
            Wartosc = Wartosc,
            Waluta = Waluta,
            IdProduktu = selectedProdukt.IdProduktu,
            ProduktDane = selectedProdukt.Kod + ", " + selectedProdukt.Nazwa,
            IdTypuCeny = selectedTypCeny.IdTypuCeny,
            TypCenyNazwa = selectedTypCeny.Typ,
            CzyAktywna = true
        };


    }
}
