using FirmaMobileMauiApp.Models;
using System;

namespace FirmaMobileMauiApp.ViewModels
{
    public class NowyTypTransakcjiViewModel : ANewItemViewModel<TypyTransakcjiForView>
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
        public NowyTypTransakcjiViewModel():base() { }

        public override TypyTransakcjiForView SetItem() => new TypyTransakcjiForView()
        {
            Nazwa = Nazwa,
            Uwagi = Uwagi,
            CzyAktywny = true
        };

        public override bool ValidateSave() => !String.IsNullOrWhiteSpace(Nazwa);
    }
}
