using FirmaMobileMauiApp.Models;
using System;

namespace FirmaMobileMauiApp.ViewModels
{
    internal class NowyMonterViewModel : ANewItemViewModel<MonterzyForView>
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
        public NowyMonterViewModel():base() { }

        public override MonterzyForView SetItem() => new MonterzyForView()
        {
            Nazwa = Nazwa,
            Uwagi = Uwagi,
            CzyAktywny = true
        };

        public override bool ValidateSave() => !String.IsNullOrWhiteSpace(Nazwa);
    }
}
