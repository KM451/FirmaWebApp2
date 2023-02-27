using FirmaMobileMauiApp.ServiceReference;


namespace FirmaMobileMauiApp.Services
{
    public class KontrahenciDataStore : ADataStore, IDataStore<KontrahenciForView>
    {
        public List<KontrahenciForView> Items { get; set; }
        public KontrahenciDataStore() => RefreshList();
        public async Task RefreshList()
        {
            var itemsFromService = firmaMobileService.KontrahentAllAsync().Result;
            Items = itemsFromService.ToList();
        }
        public async Task<bool> AddItemAsync(KontrahenciForView item)
        {
            var itemToAdd = new Kontrahent
            {
                IdKontrahenta=item.IdKontrahenta,
                Akronim = item.Akronim,
                Nazwa = item.Nazwa,
                Nip = item.Nip,
                IdSposobuPlatnosci=item.IdSposobuPlatnosci,
                CzyAktywny = true
            };
            await firmaMobileService.KontrahentPOSTAsync(itemToAdd);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(KontrahenciForView item)
        {
            await firmaMobileService.KontrahentDELETEAsync(item.IdKontrahenta);
            RefreshList();
            return await Task.FromResult(true);
        }

        public async Task<KontrahenciForView> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.IdKontrahenta == id));
        }

        public async Task<IEnumerable<KontrahenciForView>> GetItemsAsync(bool forceRefresh = true) => await Task.FromResult(Items);

        public async Task<bool> UpdateItemAsync(KontrahenciForView item)
        {
            var oldItem = Items.Where((KontrahenciForView arg) => arg.IdKontrahenta == item.IdKontrahenta).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }
    }
}
