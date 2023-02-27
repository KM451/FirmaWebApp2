using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowaPozycjaZZPage : ContentPage
    {
        public PozycjeZZForView Item { get; set; }
        public NowaPozycjaZZPage()
        {
            InitializeComponent();
            BindingContext = new NowaPozycjaZZViewModel();
        }
    }
}