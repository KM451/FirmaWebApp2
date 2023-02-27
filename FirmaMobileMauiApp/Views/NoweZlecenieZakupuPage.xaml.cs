using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoweZlecenieZakupuPage : ContentPage
    {
        public ZleceniaZakupuForView Item { get; set; }
        public NoweZlecenieZakupuPage()
        {
            InitializeComponent();
            BindingContext = new NoweZlecenieZakupuViewModel();
        }
    }
}