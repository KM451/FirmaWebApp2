using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.Views;
using System;

namespace FirmaMobileMauiApp.ViewModels
{
    public class RodzajeTransportuViewModel : AItemsViewModel<RodzajeTransportuForView>
    {
        public RodzajeTransportuViewModel(): base("Rodzaje transportu"){}
        public async override void GoToAddPage() => await Shell.Current.GoToAsync(nameof(NowyRodzajTransportuPage));

        public override void GoToDetailsPage(RodzajeTransportuForView item)
        {
            throw new NotImplementedException();
        }
    }
}
