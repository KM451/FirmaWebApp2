using FirmaMobileMauiApp.ViewModels;


namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TypyProduktowPage : ContentPage
    {
        TypyProduktowViewModel _viewModel;
        public TypyProduktowPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TypyProduktowViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}