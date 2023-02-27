using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Services
{
    public class PozycjeZZDataStore : ADataStore, IDataStore<PozycjeZZForView>
    {
        public List<PozycjeZZForView> Items;
        public PozycjeZZDataStore() => RefreshList();
        public async Task RefreshList()
        {
            var itemsFromService = firmaMobileService.PozycjaZZAllAsync().Result;
            Items = itemsFromService.ToList();
        }

        public async Task<bool> AddItemAsync(PozycjeZZForView item)
        {
            var itemToAdd = new PozycjaZZ
            {
                IdPozycjiZleceniaZakupu=item.IdPozycjiZleceniaZakupu,
                IdZleceniaZakupu=item.IdZleceniaZakupu,
                IdProduktu=item.IdProduktu,
                Ilosc = item.Ilosc,
                Rabat = item.Rabat,
                DataRealizacji = item.DataRealizacji,
                CzyAktywna = true
            };
            await firmaMobileService.PozycjaZZPOSTAsync(itemToAdd);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(PozycjeZZForView item)
        {
            await firmaMobileService.PozycjaZZDELETEAsync(item.IdPozycjiZleceniaZakupu);
            RefreshList();
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(PozycjeZZForView item)
        {
            var oldItem = Items.Where((PozycjeZZForView arg) => arg.IdPozycjiZleceniaZakupu == item.IdPozycjiZleceniaZakupu).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<PozycjeZZForView> GetItemAsync(int id) => await Task.FromResult(Items.FirstOrDefault(s => s.IdPozycjiZleceniaZakupu == id));

        public async Task<IEnumerable<PozycjeZZForView>> GetItemsAsync(bool forceRefresh = false) => await Task.FromResult(Items);

    }
}
