using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.ViewModels;


namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowyProduktUbocznyZKPage : ContentPage
    {
        public ProduktyUboczneZKForView Item { get; set; }
        public NowyProduktUbocznyZKPage()
        {
            InitializeComponent();
            BindingContext = new NowyProduktUbocznyZKViewModel();
        }
    }
}