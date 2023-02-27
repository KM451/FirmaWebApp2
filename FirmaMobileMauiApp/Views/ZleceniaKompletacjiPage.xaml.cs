using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZleceniaKompletacjiPage : ContentPage
    {
        ZleceniaKompletacjiViewModel _viewModel;
        public ZleceniaKompletacjiPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ZleceniaKompletacjiViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}