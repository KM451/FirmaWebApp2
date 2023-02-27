using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.Services;
using System;
using System.Collections.Generic;

namespace FirmaMobileMauiApp.ViewModels
{
    internal class NoweZlecenieKompletacjiViewModel : ANewItemViewModel<ZleceniaKompletacjiForView>
    {
        private DateTime dataWystawienia;
        private DateTime oczekiwanaDataRealizacji;
        private DateTime potwierdzonaDataRealizacji;
        private decimal ilosc;
        private int priorytet;
        private int czasZlecenia;
        private string status;
        private bool czyAktywne;
        private KontrahenciForView selectedKontrahent;
        private ProduktyForView selectedProdukt;
        private MonterzyForView selectedMonter;
        public NoweZlecenieKompletacjiViewModel() : base()
        {
            selectedKontrahent = new KontrahenciForView();
            selectedProdukt = new ProduktyForView();
            selectedMonter = new MonterzyForView();
            dataWystawienia = DateTime.Now;
            oczekiwanaDataRealizacji = DateTime.Now;
        }

        public List<KontrahenciForView> Kontrahenci => new KontrahenciDataStore().Items;
        public List<ProduktyForView> Produkty => new ProduktyDataStore().Items;
        public List<MonterzyForView> Monterzy => new MonterzyDataStore().Items;

        public DateTime DataWystawienia { get => dataWystawienia; set => SetProperty(ref dataWystawienia, value); }
        public DateTime OczekiwanaDataRealizacji { get => oczekiwanaDataRealizacji; set => SetProperty(ref oczekiwanaDataRealizacji, value); }
        public DateTime PotwierdzonaDataRealizacji { get => potwierdzonaDataRealizacji; set => SetProperty(ref potwierdzonaDataRealizacji, value); }
        public decimal Ilosc { get => ilosc; set => SetProperty(ref ilosc, value); }
        public int Priorytet { get => priorytet; set => SetProperty(ref priorytet, value); }
        public int CzasZlecenia { get => czasZlecenia; set => SetProperty(ref czasZlecenia, value); }
        public string Status { get => status; set => SetProperty(ref status, value); }
        public bool CzyAktywne { get => czyAktywne; set => SetProperty(ref czyAktywne, value); }
        public KontrahenciForView SelectedKontrahent { get => selectedKontrahent; set => SetProperty(ref selectedKontrahent, value); }
        public ProduktyForView SelectedProdukt { get => selectedProdukt; set => SetProperty(ref selectedProdukt, value); }
        public MonterzyForView SelectedMonter { get => selectedMonter; set => SetProperty(ref selectedMonter, value); }

        public override ZleceniaKompletacjiForView SetItem() => new ZleceniaKompletacjiForView()
        {
            DataWystawienia = dataWystawienia,
            OczekiwanaDataRealizacji = oczekiwanaDataRealizacji,
            //PotwierdzonaDataRealizacji = PotwierdzonaDataRealizacji,
            Ilosc = Ilosc,
            Priorytet = Priorytet,
            CzasZlecenia = CzasZlecenia,
            Status = Status,
            CzyAktywne = true,
            IdKontrahenta = selectedKontrahent.IdKontrahenta,
            KontrahentDane = selectedKontrahent.Nazwa + ", NIP: " + selectedKontrahent.Nip,
            IdProduktu = selectedProdukt.IdProduktu,
            ProduktDane = selectedProdukt.Kod + ", " + selectedProdukt.Nazwa,
            IdMontera = selectedMonter.IdMontera,
            MonterNazwa = selectedMonter.Nazwa,
        };

        public override bool ValidateSave() => !String.IsNullOrWhiteSpace(DataWystawienia.ToString())
                   && !String.IsNullOrWhiteSpace(OczekiwanaDataRealizacji.ToString())
                   && !String.IsNullOrWhiteSpace(Ilosc.ToString())
                   && !String.IsNullOrWhiteSpace(Status)
                   && !String.IsNullOrWhiteSpace(selectedKontrahent.Nazwa)
                   && !String.IsNullOrWhiteSpace(selectedProdukt.Nazwa);
    }
}
