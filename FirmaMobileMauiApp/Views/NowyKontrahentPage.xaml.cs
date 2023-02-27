using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowyKontrahentPage : ContentPage
    {
        public KontrahenciForView Item { get; set; }
        public NowyKontrahentPage()
        {
            InitializeComponent();
            BindingContext = new NowyKontrahentViewModel();
        }
    }
}