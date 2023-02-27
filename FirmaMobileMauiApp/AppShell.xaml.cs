using FirmaMobileMauiApp.Views;

namespace FirmaMobileMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NotePage), typeof(NotePage));
            Routing.RegisterRoute(nameof(NowyKontrahentPage), typeof(NowyKontrahentPage));
            Routing.RegisterRoute(nameof(NowyMonterPage), typeof(NowyMonterPage));
            Routing.RegisterRoute(nameof(NowyRodzajTransportuPage), typeof(NowyRodzajTransportuPage));
            Routing.RegisterRoute(nameof(NowySposobDostawyPage), typeof(NowySposobDostawyPage));
            Routing.RegisterRoute(nameof(NowyTypTransakcjiPage), typeof(NowyTypTransakcjiPage));
            Routing.RegisterRoute(nameof(NowySposobPlatnosciPage), typeof(NowySposobPlatnosciPage));
            Routing.RegisterRoute(nameof(NowyTypCenyPage), typeof(NowyTypCenyPage));
            Routing.RegisterRoute(nameof(NowyTypProduktuPage), typeof(NowyTypProduktuPage));
            Routing.RegisterRoute(nameof(NowaCenaPage), typeof(NowaCenaPage));
            Routing.RegisterRoute(nameof(NowaPozycjaZZPage), typeof(NowaPozycjaZZPage));
            Routing.RegisterRoute(nameof(NowyProduktPage), typeof(NowyProduktPage));
            Routing.RegisterRoute(nameof(NowyProduktUbocznyZKPage), typeof(NowyProduktUbocznyZKPage));
            Routing.RegisterRoute(nameof(NowySkladnikZKPage), typeof(NowySkladnikZKPage));
            Routing.RegisterRoute(nameof(NoweZlecenieKompletacjiPage), typeof(NoweZlecenieKompletacjiPage));
            Routing.RegisterRoute(nameof(NoweZlecenieZakupuPage), typeof(NoweZlecenieZakupuPage));
            Routing.RegisterRoute(nameof(ProduktDetailPage), typeof(ProduktDetailPage));
            Routing.RegisterRoute(nameof(CenyDetailPage), typeof(CenyDetailPage));
            Routing.RegisterRoute(nameof(PozycjaZZDetailPage), typeof(PozycjaZZDetailPage));
            Routing.RegisterRoute(nameof(EditCenaPage), typeof(EditCenaPage));
            Routing.RegisterRoute(nameof(EditProduktPage), typeof(EditProduktPage));
            Routing.RegisterRoute(nameof(EditPozycjaZZPage), typeof(EditPozycjaZZPage));
        }
    }
}