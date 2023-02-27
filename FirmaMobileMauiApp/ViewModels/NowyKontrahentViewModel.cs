using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.Services;
using System;
using System.Collections.Generic;

namespace FirmaMobileMauiApp.ViewModels
{
    public class NowyKontrahentViewModel : ANewItemViewModel<KontrahenciForView>
    {
        private string akronim;
        private string nazwa;
        private string nip;

        private SposobyPlatnosciForView selectedSposobPlatnosci;
        public List<SposobyPlatnosciForView> SposobPlatnosci => new SposobyPlatnosciDataStore().Items;
        public NowyKontrahentViewModel() : base()
        {
            selectedSposobPlatnosci = new SposobyPlatnosciForView();
        }
        public string Akronim
        {
            get => akronim;
            set => SetProperty(ref akronim, value);
        }
        public string Nazwa
        {
            get => nazwa;
            set => SetProperty(ref nazwa, value);
        }
        public string Nip
        {
            get => nip;
            set => SetProperty(ref nip, value);
        }
        public SposobyPlatnosciForView SelectedSposobPlatnosci
        {
            get => selectedSposobPlatnosci;
            set => SetProperty(ref selectedSposobPlatnosci, value);
        }

        public override KontrahenciForView SetItem() => new KontrahenciForView()
        {
            Akronim = this.Akronim,
            Nazwa = this.Nazwa,
            Nip = this.Nip,
            IdSposobuPlatnosci = selectedSposobPlatnosci.IdSposobuPlatnosci,
            SposobPlatnosciNazwa = selectedSposobPlatnosci.Nazwa
        };
        public override bool ValidateSave() =>!String.IsNullOrWhiteSpace(Akronim)
                                           && !String.IsNullOrWhiteSpace(Nazwa)
                                           && !String.IsNullOrWhiteSpace(Nip)
                                           && !String.IsNullOrWhiteSpace(selectedSposobPlatnosci.Nazwa);
    }
}
