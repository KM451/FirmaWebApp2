using FirmaMobileMauiApp.ViewModels;


namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProduktyUboczneZKPage : ContentPage
    {
        ProduktyUboczneZKViewModel _viewModel;
        public ProduktyUboczneZKPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ProduktyUboczneZKViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}