using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Services
{
    public class ProduktyUboczneZKDataStore : ADataStore, IDataStore<ProduktyUboczneZKForView>
    {
        public List<ProduktyUboczneZKForView> Items { get; set; }
        public ProduktyUboczneZKDataStore() => RefreshList();
        public async Task RefreshList()
        {
            var itemsFromService = firmaMobileService.ProduktUbocznyZKAllAsync().Result;
            Items = itemsFromService.ToList();
        }

        public async Task<bool> AddItemAsync(ProduktyUboczneZKForView item)
        {
            var itemToAdd = new ProduktUbocznyZK
            {
                IdPrUbocznego = item.IdPrUbocznego,
                IdZleceniaKompletacji = item.IdZleceniaKompletacji,
                IdProduktu = item.IdProduktu,
                Ilosc = item.Ilosc,
                CzyAktywny = item.CzyAktywny,
            };
            await firmaMobileService.ProduktUbocznyZKPOSTAsync(itemToAdd);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(ProduktyUboczneZKForView item)
        {
            await firmaMobileService.ProduktUbocznyZKDELETEAsync(item.IdPrUbocznego);
            RefreshList();
            return await Task.FromResult(true);
        }

        public async Task<ProduktyUboczneZKForView> GetItemAsync(int id) => await Task.FromResult(Items.FirstOrDefault(s => s.IdPrUbocznego == id));

        public async Task<IEnumerable<ProduktyUboczneZKForView>> GetItemsAsync(bool forceRefresh = false) => await Task.FromResult(Items);

        public async Task<bool> UpdateItemAsync(ProduktyUboczneZKForView item)
        {
            var oldItem = Items.Where((ProduktyUboczneZKForView arg) => arg.IdPrUbocznego == item.IdPrUbocznego).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }
    }
}
