using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.Views;
using System;

namespace FirmaMobileMauiApp.ViewModels
{
    internal class MonterzyViewModel : AItemsViewModel<MonterzyForView>
    {
        public MonterzyViewModel(): base("Monterzy")
        {
        }

        public override void GoToAddPage()
        {
            throw new NotImplementedException();
        }

        public override void GoToDetailsPage(MonterzyForView item)
        {
            throw new NotImplementedException();
        }

        //public override async void GoToAddPage() => await Shell.Current.GoToAsync(nameof(NowyMonterPage));

    }
}
