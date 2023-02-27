using FirmaMobileMauiApp.ViewModels;


namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProduktyPage : ContentPage
    {
        ProduktyViewModel _viewModel;
        public ProduktyPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ProduktyViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}