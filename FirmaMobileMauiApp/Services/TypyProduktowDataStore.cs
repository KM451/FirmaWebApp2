using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Services
{
    public class TypyProduktowDataStore : ADataStore, IDataStore<TypyProduktowForView>
    {
        public List<TypyProduktowForView> Items { get; set; }
        public TypyProduktowDataStore() => RefreshList();
        public async Task RefreshList()
        {
            var itemsFromService = firmaMobileService.TypProduktuAllAsync().Result;
            Items = new List<TypyProduktowForView>();
            Items = itemsFromService.Select(typProduktu => new TypyProduktowForView(typProduktu)).ToList();
        }
        public async Task<bool> AddItemAsync(TypyProduktowForView item)
        {
            var itemToAdd = new TypProduktu()
            {
                Nazwa = item.Nazwa,
                Uwagi = item.Uwagi,
                CzySklep = item.CzySklep,
                CzyAktywny = true,
            };
            await firmaMobileService.TypProduktuPOSTAsync(itemToAdd);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(TypyProduktowForView item)
        {
            await firmaMobileService.TypProduktuDELETEAsync(item.IdTypuProduktu);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<TypyProduktowForView> GetItemAsync(int id) => await Task.FromResult(Items.FirstOrDefault(s => s.IdTypuProduktu == id));
        public async Task<IEnumerable<TypyProduktowForView>> GetItemsAsync(bool forceRefresh = false) => await Task.FromResult(Items);
        public async Task<bool> UpdateItemAsync(TypyProduktowForView item)
        {
            var oldItem = Items.Where((TypyProduktowForView arg) => arg.IdTypuProduktu == item.IdTypuProduktu).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }

    }
}
