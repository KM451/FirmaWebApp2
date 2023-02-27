using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Services
{
    public class TypyCenDataStore : ADataStore, IDataStore<TypyCenForView>
    {
        public List<TypyCenForView> Items { get; set; }
        public TypyCenDataStore() => RefreshList();
        public async Task RefreshList()
        {
            var itemsFromService = firmaMobileService.TypCenyAllAsync().Result;
            Items = new List<TypyCenForView>();
            Items = itemsFromService.Select(typCeny => new TypyCenForView(typCeny)).ToList();
        }
        public async Task<bool> AddItemAsync(TypyCenForView item)
        {
            var itemToAdd = new TypCeny()
            {
                Typ = item.Typ,
                Uwagi = item.Uwagi,
                CzyAktywny = true,
            };
            await firmaMobileService.TypCenyPOSTAsync(itemToAdd);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(TypyCenForView item)
        {
            await firmaMobileService.TypCenyDELETEAsync(item.IdTypuCeny);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<TypyCenForView> GetItemAsync(int id) => await Task.FromResult(Items.FirstOrDefault(s => s.IdTypuCeny == id));

        public async Task<IEnumerable<TypyCenForView>> GetItemsAsync(bool forceRefresh = false) => await Task.FromResult(Items);

        public async Task<bool> UpdateItemAsync(TypyCenForView item)
        {
            var oldItem = Items.Where((TypyCenForView arg) => arg.IdTypuCeny == item.IdTypuCeny).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }
 
    }
}
