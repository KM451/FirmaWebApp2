using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Services
{
    public class TypyTransakcjiDataStore : ADataStore, IDataStore<TypyTransakcjiForView>
    {
        public List<TypyTransakcjiForView> Items { get; set; }
        public TypyTransakcjiDataStore() => RefreshList();
        public async Task RefreshList()
        {
            var itemsFromService = firmaMobileService.TypTransakcjiAllAsync().Result;
            Items = new List<TypyTransakcjiForView>();
            Items = itemsFromService.Select(typTransakcji => new TypyTransakcjiForView(typTransakcji)).ToList();
        }
        public async Task<bool> AddItemAsync(TypyTransakcjiForView item)
        {
            var itemToAdd = new TypTransakcji()
            {
                Nazwa = item.Nazwa,
                Uwagi = item.Uwagi,
                CzyAktywny = true,
            };
            await firmaMobileService.TypTransakcjiPOSTAsync(itemToAdd);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(TypyTransakcjiForView item)
        {
            await firmaMobileService.TypTransakcjiDELETEAsync(item.IdTypuTransakcji);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<TypyTransakcjiForView> GetItemAsync(int id) => await Task.FromResult(Items.FirstOrDefault(s => s.IdTypuTransakcji == id));

        public async Task<IEnumerable<TypyTransakcjiForView>> GetItemsAsync(bool forceRefresh = false) => await Task.FromResult(Items);

        public async Task<bool> UpdateItemAsync(TypyTransakcjiForView item)
        {
            var oldItem = Items.Where((TypyTransakcjiForView arg) => arg.IdTypuTransakcji == item.IdTypuTransakcji).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }

    }
}
