using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowaCenaPage : ContentPage
    {
        public CenyForView Item { get; set; }
        public NowaCenaPage()
        {
            InitializeComponent();
            BindingContext = new NowaCenaViewModel();
        }
    }
}