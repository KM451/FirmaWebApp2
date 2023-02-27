using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.Views;
using System;

namespace FirmaMobileMauiApp.ViewModels
{
    internal class SkladnikZKViewModel : AItemsViewModel<SkladnikZKForView>
    {
        public SkladnikZKViewModel() : base("Składniki zlecenia kompletacji")
        {
        }
        public override async void GoToAddPage() => await Shell.Current.GoToAsync(nameof(NowySkladnikZKPage));

        public override void GoToDetailsPage(SkladnikZKForView item)
        {
            throw new NotImplementedException();
        }
    }
}
