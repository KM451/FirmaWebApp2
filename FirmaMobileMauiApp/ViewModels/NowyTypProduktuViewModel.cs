using FirmaMobileMauiApp.Models;
using System;

namespace FirmaMobileMauiApp.ViewModels
{
    public class NowyTypProduktuViewModel : ANewItemViewModel<TypyProduktowForView>
    {
        private string nazwa;
        private string uwagi;
        private bool czySklep;
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
        public bool CzySklep
        {
            get => czySklep;
            set => SetProperty(ref czySklep, value);
        }
        public NowyTypProduktuViewModel() : base() { }
        public override TypyProduktowForView SetItem() => new TypyProduktowForView()
        {
            Nazwa = Nazwa,
            Uwagi = Uwagi,
            CzySklep = CzySklep,
            CzyAktywny = true
        };
        public override bool ValidateSave() => !String.IsNullOrWhiteSpace(Nazwa);

    }
}