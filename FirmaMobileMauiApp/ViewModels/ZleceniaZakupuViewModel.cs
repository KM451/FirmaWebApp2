using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.Views;
using System;

namespace FirmaMobileMauiApp.ViewModels
{
    public class ZleceniaZakupuViewModel : AItemsViewModel<ZleceniaZakupuForView>
    {
        public ZleceniaZakupuViewModel() : base("Zlecenia zakupu")
        {
        }
        public override async void GoToAddPage() => await Shell.Current.GoToAsync(nameof(NoweZlecenieZakupuPage));

        public override void GoToDetailsPage(ZleceniaZakupuForView item)
        {
            throw new NotImplementedException();
        }
    }
}
