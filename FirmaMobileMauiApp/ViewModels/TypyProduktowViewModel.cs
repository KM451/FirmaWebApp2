using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.Views;
using System;

namespace FirmaMobileMauiApp.ViewModels
{
    public class TypyProduktowViewModel : AItemsViewModel<TypyProduktowForView>
    {
        public TypyProduktowViewModel() : base("Typy produktów") { }
        public async override void GoToAddPage() => await Shell.Current.GoToAsync(nameof(NowyTypProduktuPage));

        public override void GoToDetailsPage(TypyProduktowForView item)
        {
            throw new NotImplementedException();
        }
    }
}
