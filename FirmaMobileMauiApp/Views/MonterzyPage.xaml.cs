using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonterzyPage : ContentPage
    {
        MonterzyViewModel _viewModel;
        public MonterzyPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MonterzyViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}

    
