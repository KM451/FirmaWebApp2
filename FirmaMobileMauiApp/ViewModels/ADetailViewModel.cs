

namespace FirmaMobileMauiApp.ViewModels
{
    public abstract class ADetailViewModel<T> : BaseViewModel<T>
    {
        public ADetailViewModel()
        {
            CancelCommand = new Command(OnCancel);
        }

        public Command CancelCommand { get; }
        
        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

    }

}
