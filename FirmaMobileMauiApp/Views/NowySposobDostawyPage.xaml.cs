using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ViewModels;


namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowySposobDostawyPage : ContentPage
    {
        public SposobyDostawyForView Item { get; set; }

        public NowySposobDostawyPage()
        {
            InitializeComponent();
            BindingContext = new NowySposobDostawyViewModel();
        }
    }
}