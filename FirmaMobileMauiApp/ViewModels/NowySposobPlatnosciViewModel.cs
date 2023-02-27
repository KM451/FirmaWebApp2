using FirmaMobileMauiApp.Models;
using System;

namespace FirmaMobileMauiApp.ViewModels
{
    public class NowySposobPlatnosciViewModel : ANewItemViewModel<SposobyPlatnosciForView>
    {
        private string nazwa;
        private string uwagi;
        public string Nazwa
        {
            get => nazwa;
            set => SetProperty(ref nazwa, value);
        }
        public string Uwagi
        {
            get => uwagi;
            set => SetProperty(ref uwagi, value);
        }
        public NowySposobPlatnosciViewModel():base(){}

        public override SposobyPlatnosciForView SetItem() => new SposobyPlatnosciForView()
        {
            Nazwa = Nazwa,
            Uwagi = Uwagi,
            CzyAktywny = true
        };
        public override bool ValidateSave() => !String.IsNullOrWhiteSpace(Nazwa);
    }
}
