using FirmaMobileMauiApp.Services;

namespace FirmaMobileMauiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            DependencyService.Register<KontrahenciDataStore>();
            DependencyService.Register<MonterzyDataStore>();
            DependencyService.Register<RodzajeTransportuDataStore>();
            DependencyService.Register<SposobyDostawyDataStore>();
            DependencyService.Register<TypyTransakcjiDataStore>();
            DependencyService.Register<SposobyPlatnosciDataStore>();
            DependencyService.Register<TypyCenDataStore>();
            DependencyService.Register<TypyProduktowDataStore>();
            DependencyService.Register<CenyDataStore>();
            DependencyService.Register<PozycjeZZDataStore>();
            DependencyService.Register<ProduktyDataStore>();
            DependencyService.Register<ProduktyUboczneZKDataStore>();
            DependencyService.Register<SkladnikZKDataStore>();
            DependencyService.Register<ZlecenieKompletacjiDataStore>();
            DependencyService.Register<ZlecenieZakupuDataStore>();
        }
    }
}