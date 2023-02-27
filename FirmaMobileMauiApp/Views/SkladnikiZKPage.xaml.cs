using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkladnikiZKPage : ContentPage
    {
        SkladnikZKViewModel _viewModel;
        public SkladnikiZKPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SkladnikZKViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}