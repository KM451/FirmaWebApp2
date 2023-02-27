using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Services
{
    public  class ADataStore
    {
        protected FirmaMobileService firmaMobileService;

        public ADataStore()
        {
            firmaMobileService = new FirmaMobileService("http://localhost:5033", new HttpClient());
        }
    }
}
