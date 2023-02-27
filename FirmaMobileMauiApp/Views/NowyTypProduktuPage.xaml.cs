using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowyTypProduktuPage : ContentPage
    {
        public TypyProduktowForView Item { get; set; }
        public NowyTypProduktuPage()
        {
            InitializeComponent();
            BindingContext = new NowyTypProduktuViewModel();
        }
    }
}