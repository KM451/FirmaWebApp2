using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Services
{
    public class ZlecenieZakupuDataStore : ADataStore, IDataStore<ZleceniaZakupuForView>
    {
        public List<ZleceniaZakupuForView> Items { get; set; }
        public ZlecenieZakupuDataStore() => RefreshList();
        public async Task RefreshList()
        {
            var itemsFromService = firmaMobileService.ZlecenieZakupuAllAsync().Result;
            Items = itemsFromService.ToList();
        }
        public async Task<bool> AddItemAsync(ZleceniaZakupuForView item)
        {
            var itemToAdd = new ZlecenieZakupu
            {
                IdZleceniaZakupu = item.IdZleceniaZakupu,
                IdKontrahenta = item.IdKontrahenta,
                IdTransakcji = item.IdTransakcji,
                IdSposobuDostawy = item.IdSposobuDostawy,
                IdRodzajuTransportu = item.IdRodzajuTransportu,
                IdSposobuPlatnosci = item.IdSposobuPlatnosci,
                NrOferty = item.NrOferty,
                CzyPotwierdzone = item.CzyPotwierdzone,
                NrPotwierdzenia = item.NrPotwierdzenia,
                Status = item.Status,
                DataWystawienia = item.DataWystawienia,
                CzyAktywne = item.CzyAktywne,
            };

            await firmaMobileService.ZlecenieZakupuPOSTAsync(itemToAdd);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(ZleceniaZakupuForView item)
        {
            await firmaMobileService.ZlecenieZakupuDELETEAsync(item.IdZleceniaZakupu);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<ZleceniaZakupuForView> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(item => item.IdZleceniaZakupu == id));
        }

        public async Task<IEnumerable<ZleceniaZakupuForView>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }

        public async Task<bool> UpdateItemAsync(ZleceniaZakupuForView item)
        {
            var oldItem = Items.Where((ZleceniaZakupuForView arg) => arg.IdZleceniaZakupu == item.IdZleceniaZakupu).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }

    }
}
