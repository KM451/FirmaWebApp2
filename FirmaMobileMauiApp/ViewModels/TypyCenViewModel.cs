using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.Views;

namespace FirmaMobileMauiApp.ViewModels
{
    public class TypyCenViewModel : AItemsViewModel<TypyCenForView>
    {
        public TypyCenViewModel(): base("Typy cen"){}
        public async override void GoToAddPage() => await Shell.Current.GoToAsync(nameof(NowyTypCenyPage)); 
        public override void GoToDetailsPage(TypyCenForView item)
        {
            throw new NotImplementedException();
        }
    }
}
