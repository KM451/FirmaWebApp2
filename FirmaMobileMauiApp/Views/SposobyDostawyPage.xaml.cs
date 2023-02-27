using FirmaMobileMauiApp.ViewModels;


namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SposobyDostawyPage : ContentPage
    {
        SposobyDostawyViewModel _viewModel;
        public SposobyDostawyPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SposobyDostawyViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}