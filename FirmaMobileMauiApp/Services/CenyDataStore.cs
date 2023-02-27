using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Services
{
    public class CenyDataStore : ADataStore, IDataStore<CenyForView>
    {
        public List<CenyForView> Items { get; set; }
        public CenyDataStore() => RefreshList();

        public void RefreshList() => Items = firmaMobileService.CenaAllAsync().Result.ToList();
        public async Task<bool> AddItemAsync(CenyForView item)
        {
            var itemToAdd = new Cena
            {
                IdCeny = item.IdCeny,
                IdProduktu = item.IdProduktu,
                IdTypuCeny = item.IdTypuCeny,
                Wartosc = item.Wartosc,
                Waluta = item.Waluta,
                CzyAktywna = true
            };
            await firmaMobileService.CenaPOSTAsync(itemToAdd);
            RefreshList();

            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(CenyForView item)
        {
            await firmaMobileService.CenaDELETEAsync(item.IdCeny);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<CenyForView> GetItemAsync(int id) => await Task.FromResult(Items.FirstOrDefault(s => s.IdCeny == id));

        public async Task<IEnumerable<CenyForView>> GetItemsAsync(bool forceRefresh = false) => await Task.FromResult(Items);

        public async Task<bool> UpdateItemAsync(CenyForView item)
        {
            //var oldItem = Items.Where((CenyForView arg) => arg.IdCeny == item.IdCeny).FirstOrDefault();
            //Items.Remove(oldItem);
            //Items.Add(item);

            var oldItem = firmaMobileService.CenaAllAsync().Result.Where((CenyForView arg) => arg.IdCeny == item.IdCeny).FirstOrDefault();
            await firmaMobileService.CenaPUTAsync(item.IdCeny,new Cena()
 
            {
                IdCeny = item.IdCeny,
                IdProduktu = item.IdProduktu,
                IdTypuCeny = item.IdTypuCeny,
                Wartosc = item.Wartosc,
                Waluta = item.Waluta,
                CzyAktywna = item.CzyAktywna
            });

            RefreshList();
            return await Task.FromResult(true);
        }

    }
}
