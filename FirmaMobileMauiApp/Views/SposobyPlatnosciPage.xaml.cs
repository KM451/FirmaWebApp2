using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SposobyPlatnosciPage : ContentPage
    {
        SposobyPlatnosciViewModel _viewModel;
        public SposobyPlatnosciPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SposobyPlatnosciViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}