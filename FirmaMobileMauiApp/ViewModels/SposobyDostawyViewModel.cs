using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.Views;
using System;

namespace FirmaMobileMauiApp.ViewModels
{
    public class SposobyDostawyViewModel : AItemsViewModel<SposobyDostawyForView>
    {
        public SposobyDostawyViewModel(): base("Sposoby dostawy"){}
        public async override void GoToAddPage() => await Shell.Current.GoToAsync(nameof(NowySposobDostawyPage)); 
        public override void GoToDetailsPage(SposobyDostawyForView item)
        {
            throw new NotImplementedException();
        }
    }
}
