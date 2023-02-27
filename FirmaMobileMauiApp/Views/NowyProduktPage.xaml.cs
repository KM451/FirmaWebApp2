using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowyProduktPage : ContentPage
    {
        public ProduktyForView  Item { get; set; }
        public NowyProduktPage()
        {
            InitializeComponent();
            BindingContext = new NowyProduktViewModel("Nowy produkt");
        }
    }
}