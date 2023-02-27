using FirmaMobileMauiApp.Views;
using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.ViewModels
{
    public class KontrahenciViewModel : AItemsViewModel<KontrahenciForView>
    {
        public KontrahenciViewModel(): base("Kontrahenci")
        {
        }

        public override async void GoToAddPage() => await Shell.Current.GoToAsync(nameof(NowyKontrahentPage));

        public override void GoToDetailsPage(KontrahenciForView item)
        {
            throw new System.NotImplementedException();
        }
    }
}
