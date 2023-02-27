using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoweZlecenieKompletacjiPage : ContentPage
    {
        public ZleceniaKompletacjiForView Item { get; set; }
        public NoweZlecenieKompletacjiPage()
        {
            InitializeComponent();
            BindingContext = new NoweZlecenieKompletacjiViewModel();
        }
    }
}