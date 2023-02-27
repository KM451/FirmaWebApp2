using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.Views;
using System;

namespace FirmaMobileMauiApp.ViewModels
{
    public class TypyTransakcjiViewModel : AItemsViewModel<TypyTransakcjiForView>
    {
        public TypyTransakcjiViewModel(): base("Typy transakcji"){}
        public async override void GoToAddPage() => await Shell.Current.GoToAsync(nameof(NowyTypTransakcjiPage)); 
        public override void GoToDetailsPage(TypyTransakcjiForView item)
        {
            throw new NotImplementedException();
        }
    }
}
