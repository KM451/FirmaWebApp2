using FirmaMobileMauiApp.ViewModels;


namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CenyDetailPage : ContentPage
    {
        public CenyDetailPage()
        {
            InitializeComponent();
            BindingContext = new DetailCenaViewModel("Dane szczegółowe ceny");
        }
    }
}