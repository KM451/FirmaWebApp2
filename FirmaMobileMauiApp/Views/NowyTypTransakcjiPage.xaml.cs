using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ViewModels;

namespace FirmaMobileMauiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowyTypTransakcjiPage : ContentPage
    {
        public TypyTransakcjiForView Item { get; set; }
        public NowyTypTransakcjiPage()
        {
            InitializeComponent();
            BindingContext = new NowyTypTransakcjiViewModel();
        }
    }
}