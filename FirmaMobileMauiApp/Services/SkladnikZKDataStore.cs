using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Services
{
    public class SkladnikZKDataStore : ADataStore, IDataStore<SkladnikZKForView>
    {
        public List<SkladnikZKForView> Items { get; set; }
        public SkladnikZKDataStore() => RefreshList();
        public async Task RefreshList()
        {
            var itemsFromService = firmaMobileService.SkladnikZKAllAsync().Result;
            Items = itemsFromService.ToList();
        }
        public async Task<bool> AddItemAsync(SkladnikZKForView item)
        {
            var itemToAdd = new SkladnikZK
            {
                IdSkladnika = item.IdSkladnika,
                IdZleceniaKompletacji = item.IdZleceniaKompletacji,
                IdProduktu = item.IdProduktu,
                Ilosc = item.Ilosc,
                CzyAktywny = item.CzyAktywny,
            };

            await firmaMobileService.SkladnikZKPOSTAsync(itemToAdd);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(SkladnikZKForView item)
        {
            await firmaMobileService.SkladnikZKDELETEAsync(item.IdSkladnika);
            RefreshList();
            return await Task.FromResult(true);
        }

        public async Task<SkladnikZKForView> GetItemAsync(int id) => await Task.FromResult(Items.FirstOrDefault(item => item.IdSkladnika == id));

        public async Task<IEnumerable<SkladnikZKForView>> GetItemsAsync(bool forceRefresh = false) => await Task.FromResult(Items);

        public async Task<bool> UpdateItemAsync(SkladnikZKForView item)
        {
            var oldItem = Items.Where((SkladnikZKForView arg) => arg.IdSkladnika == item.IdSkladnika).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }

    }
}
