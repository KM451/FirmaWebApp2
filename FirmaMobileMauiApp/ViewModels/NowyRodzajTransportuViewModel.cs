using FirmaMobileMauiApp.Models;
using System;

namespace FirmaMobileMauiApp.ViewModels
{
    public class NowyRodzajTransportuViewModel : ANewItemViewModel<RodzajeTransportuForView>
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
        public NowyRodzajTransportuViewModel():base()
        {}
        public override RodzajeTransportuForView SetItem() => new RodzajeTransportuForView()
        {
            Nazwa = Nazwa,
            Uwagi = Uwagi,
            CzyAktywny = true
        };

        public override bool ValidateSave() => !String.IsNullOrWhiteSpace(Nazwa);
    }
}
