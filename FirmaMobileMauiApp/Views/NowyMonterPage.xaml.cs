using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowyMonterPage : ContentPage
    {
        public MonterzyForView Item { get; set; }
        public NowyMonterPage()
        {
            InitializeComponent();
            BindingContext = new NowyMonterViewModel();
        }
    }
}