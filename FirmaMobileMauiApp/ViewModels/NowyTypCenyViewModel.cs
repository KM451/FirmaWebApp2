using FirmaMobileMauiApp.Models;
using System;

namespace FirmaMobileMauiApp.ViewModels
{
    public class NowyTypCenyViewModel : ANewItemViewModel<TypyCenForView>
    {
        private string typ;
        private string uwagi;
        public string Typ
        {
            get => typ;
            set => SetProperty(ref typ, value);
        }
        public string Uwagi
        {
            get => uwagi;
            set => SetProperty(ref uwagi, value);
        }
        public NowyTypCenyViewModel() : base() { }

        public override TypyCenForView SetItem() => new TypyCenForView()
        {
            Typ = Typ,
            Uwagi = Uwagi,
            CzyAktywny = true
        };

        public override bool ValidateSave() => !String.IsNullOrWhiteSpace(Typ);
    }
}
