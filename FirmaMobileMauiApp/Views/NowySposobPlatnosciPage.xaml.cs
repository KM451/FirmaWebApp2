using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ViewModels;


namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowySposobPlatnosciPage : ContentPage
    {
        public SposobyPlatnosciForView Item { get; set; }

        public NowySposobPlatnosciPage()
        {
            InitializeComponent();
            BindingContext = new NowySposobPlatnosciViewModel();
        }
    }
}