using FirmaMobileMauiApp.ViewModels;


namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProduktDetailPage : ContentPage
    {
        public ProduktDetailPage()
        {
            InitializeComponent();
            BindingContext = new DetailProduktViewModel("Dane szczegółowe produktu");
        }
       
    }
}