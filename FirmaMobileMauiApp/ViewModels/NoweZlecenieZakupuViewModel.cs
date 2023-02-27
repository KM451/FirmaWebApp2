using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.Services;
using System;
using System.Collections.Generic;

namespace FirmaMobileMauiApp.ViewModels
{
    public class NoweZlecenieZakupuViewModel : ANewItemViewModel<ZleceniaZakupuForView>
    {
        private string nrOferty;
        private bool czyPotwierdzone;
        private string nrPotwierdzenia;
        private string status;
        private DateTime dataWystawienia;
        private bool czyAktywne;
        private KontrahenciForView selectedKontrahent;
        private TypyTransakcjiForView selectedTypTransakcji;
        private SposobyDostawyForView selectedSposobDostawy;
        private RodzajeTransportuForView selectedRodzajTransportu;
        private SposobyPlatnosciForView selectedSposobPlatnosci;

        public NoweZlecenieZakupuViewModel() : base()
        {
            SelectedKontrahent = new KontrahenciForView();
            SelectedTypTransakcji = new TypyTransakcjiForView();
            SelectedSposobDostawy = new SposobyDostawyForView();
            SelectedRodzajTransportu = new RodzajeTransportuForView();
            SelectedSposobPlatnosci = new SposobyPlatnosciForView();
            DataWystawienia = DateTime.Now;
        }

        public List<KontrahenciForView> Kontrahenci => new KontrahenciDataStore().Items;
        public List<TypyTransakcjiForView> TypyTransakcji => new TypyTransakcjiDataStore().Items;
        public List<SposobyDostawyForView> SposobyDostawy => new SposobyDostawyDataStore().Items;
        public List<RodzajeTransportuForView> RodzajeTransportu => new RodzajeTransportuDataStore().Items;
        public List<SposobyPlatnosciForView> SposobyPlatnosci => new SposobyPlatnosciDataStore().Items;

        public string NrOferty { get => nrOferty; set => SetProperty(ref nrOferty, value); }
        public bool CzyPotwierdzone { get => czyPotwierdzone; set => SetProperty(ref czyPotwierdzone, value); }
        public string NrPotwierdzenia { get => nrPotwierdzenia; set => SetProperty(ref nrPotwierdzenia, value); }
        public string Status { get => status; set => SetProperty(ref status, value); }
        public DateTime DataWystawienia { get => dataWystawienia; set => SetProperty(ref dataWystawienia, value); }
        public bool CzyAktywne { get => czyAktywne; set => SetProperty(ref czyAktywne, value); }
        public KontrahenciForView SelectedKontrahent { get => selectedKontrahent; set => SetProperty(ref selectedKontrahent, value); }
        public TypyTransakcjiForView SelectedTypTransakcji { get => selectedTypTransakcji; set => SetProperty(ref selectedTypTransakcji, value); }
        public SposobyDostawyForView SelectedSposobDostawy { get => selectedSposobDostawy; set => SetProperty(ref selectedSposobDostawy, value); }
        public RodzajeTransportuForView SelectedRodzajTransportu { get => selectedRodzajTransportu; set => SetProperty(ref selectedRodzajTransportu, value); }
        public SposobyPlatnosciForView SelectedSposobPlatnosci { get => selectedSposobPlatnosci; set => SetProperty(ref selectedSposobPlatnosci, value); }

        public override ZleceniaZakupuForView SetItem() => new ZleceniaZakupuForView()
        {
            NrOferty = NrOferty,
            CzyPotwierdzone = CzyPotwierdzone,
            NrPotwierdzenia = NrPotwierdzenia,
            Status = Status,
            DataWystawienia = dataWystawienia,
            CzyAktywne = true,
            IdKontrahenta = selectedKontrahent.IdKontrahenta,
            KontrahentDane = selectedKontrahent.Nazwa + ", NIP: " + selectedKontrahent.Nip,
            IdTransakcji = selectedTypTransakcji.IdTypuTransakcji,
            TypTransakcjiNazwa = selectedTypTransakcji.Nazwa,
            IdSposobuDostawy = selectedSposobDostawy.IdSposobuDostawy,
            SposobDostawyNazwa = selectedSposobDostawy.Nazwa,
            IdRodzajuTransportu = selectedRodzajTransportu.IdRodzajuTransportu,
            RodzajTransportuNazwa = selectedRodzajTransportu.Nazwa,
            IdSposobuPlatnosci = selectedSposobPlatnosci.IdSposobuPlatnosci,
            SposobPlatnosciNazwa = selectedSposobPlatnosci.Nazwa
        };

        public override bool ValidateSave() => !String.IsNullOrWhiteSpace(Status)
                && !String.IsNullOrWhiteSpace(DataWystawienia.ToString())
                && !String.IsNullOrWhiteSpace(selectedKontrahent.Nazwa)
                && !String.IsNullOrWhiteSpace(selectedTypTransakcji.Nazwa)
                && !String.IsNullOrWhiteSpace(selectedSposobDostawy.Nazwa)
                && !String.IsNullOrWhiteSpace(selectedRodzajTransportu.Nazwa)
                && !String.IsNullOrWhiteSpace(selectedSposobPlatnosci.Nazwa);
    }
}
