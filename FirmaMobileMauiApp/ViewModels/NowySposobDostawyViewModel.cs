using FirmaMobileMauiApp.Models;
using System;

namespace FirmaMobileMauiApp.ViewModels
{
    public class NowySposobDostawyViewModel : ANewItemViewModel<SposobyDostawyForView>
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
        public NowySposobDostawyViewModel(): base(){}

        public override SposobyDostawyForView SetItem() => new SposobyDostawyForView()
        {
            Nazwa = Nazwa,
            Uwagi = Uwagi,
            CzyAktywny = true
        };

        public override bool ValidateSave() => !String.IsNullOrWhiteSpace(Nazwa);
    }
}
