using FirmaMobileMauiApp.ServiceReference;
using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowySkladnikZKPage : ContentPage
    {
        public SkladnikZKForView Item { get; set; }
        public NowySkladnikZKPage()
        {
            InitializeComponent();
            BindingContext = new NowySkladnikZKViewModel();
        }
    }
}