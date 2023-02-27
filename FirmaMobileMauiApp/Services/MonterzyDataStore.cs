using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Services
{
    internal class MonterzyDataStore : ADataStore, IDataStore<MonterzyForView>
    {
        public List<MonterzyForView> Items { get; set; }
        public MonterzyDataStore() => RefreshList();

        public async Task RefreshList()
        {
            var itemsFromService = firmaMobileService.MonterAllAsync().Result;
            Items = new List<MonterzyForView>();
            Items = itemsFromService.Select(monter => new MonterzyForView(monter)).ToList();
        }
        public async Task<bool> AddItemAsync(MonterzyForView item)
        {
            var itemToAdd = new Monter()
            {
                Nazwa = item.Nazwa,
                Uwagi = item.Uwagi,
                CzyAktywny = true,
            };
            await firmaMobileService.MonterPOSTAsync(itemToAdd);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(MonterzyForView item)
        {
            await firmaMobileService.MonterDELETEAsync(item.IdMontera);
            RefreshList();
            return await Task.FromResult(true);
        }

        public async Task<MonterzyForView> GetItemAsync(int id) => await Task.FromResult(Items.FirstOrDefault(s => s.IdMontera == id));

        public async Task<IEnumerable<MonterzyForView>> GetItemsAsync(bool forceRefresh = false) => await Task.FromResult(Items);

        public async Task<bool> UpdateItemAsync(MonterzyForView item)
        {
            var oldItem = Items.Where((MonterzyForView arg) => arg.IdMontera == item.IdMontera).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }

    }
}
