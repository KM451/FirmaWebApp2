using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZleceniaZakupuPage : ContentPage
    {
        ZleceniaZakupuViewModel _viewModel;
        public ZleceniaZakupuPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ZleceniaZakupuViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}