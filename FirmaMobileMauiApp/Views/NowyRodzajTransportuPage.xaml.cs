using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowyRodzajTransportuPage : ContentPage
    {
        public RodzajeTransportuForView Item { get; set; }
        public NowyRodzajTransportuPage()
        {
            InitializeComponent();
            BindingContext = new NowyRodzajTransportuViewModel();
        }
    }
}