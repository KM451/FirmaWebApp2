using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PozycjaZZDetailPage : ContentPage
    {
        public PozycjaZZDetailPage()
        {
            InitializeComponent();
            BindingContext = new DetailPozycjaZZViewModel("Dane szczegółowe pozycji zlecenia zakupu");
        }
    }
}