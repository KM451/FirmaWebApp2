using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowyTypCenyPage : ContentPage
    {
        public TypyCenForView Item { get; set; }
        public NowyTypCenyPage()
        {
            InitializeComponent();
            BindingContext = new NowyTypCenyViewModel();
        }
    }
}