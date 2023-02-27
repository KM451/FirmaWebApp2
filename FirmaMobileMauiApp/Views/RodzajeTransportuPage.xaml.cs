using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RodzajeTransportuPage : ContentPage
    {
        RodzajeTransportuViewModel _viewModel;
        public RodzajeTransportuPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RodzajeTransportuViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}