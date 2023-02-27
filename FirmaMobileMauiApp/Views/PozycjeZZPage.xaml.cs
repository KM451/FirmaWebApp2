using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PozycjeZZPage : ContentPage
    {
        PozycjeZZViewModel _viewModel;
        public PozycjeZZPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PozycjeZZViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}