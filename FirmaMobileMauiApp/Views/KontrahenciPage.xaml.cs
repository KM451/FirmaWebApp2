using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KontrahenciPage : ContentPage
    {
        KontrahenciViewModel _viewModel;
        public KontrahenciPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new KontrahenciViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

    }
}