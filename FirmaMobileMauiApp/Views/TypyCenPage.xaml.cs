using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TypyCenPage : ContentPage
    {
        TypyCenViewModel _viewModel;
        public TypyCenPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TypyCenViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}