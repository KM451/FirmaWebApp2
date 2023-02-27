using FirmaMobileMauiApp.Services;
using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.ViewModels
{
    public abstract class AEditViewModel<T> : BaseViewModel<T>
    {
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
        public Command CancelCommand { get; }
        public Command UpdateCommand { get; }
        public AEditViewModel()
        {
            UpdateCommand = new Command(OnUpdate);
            CancelCommand = new Command(OnCancel);
        }

        

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        public abstract T SetItem();

        private async void OnUpdate(object obj)
        {
            await DataStore.UpdateItemAsync(SetItem());
            await Shell.Current.GoToAsync("..");
        }
    }
}
