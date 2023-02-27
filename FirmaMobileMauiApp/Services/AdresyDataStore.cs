using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Services
{
    internal class AdresyDataStore : ADataStore, IDataStore<AdresyForView>
    {
        public List<AdresyForView> Items { get; set; }
        public AdresyDataStore() => RefreshList();
        public async Task RefreshList()
        {
            var itemsFromService = firmaMobileService.AdresAllAsync().Result;
            Items = itemsFromService.ToList();
        }
        public async Task<bool> AddItemAsync(AdresyForView item)
        {
            var itemToAdd = new Adres
            {
                IdAdresu = item.IdAdresu,
                Ulica = item.Ulica,
                Miejscowosc = item.Miejscowosc,
                NrDomu = item.NrDomu,
                NrLokalu = item.NrLokalu,
                KodPoczowy = item.KodPoczowy,
                Poczta = item.Poczta,
                Kraj = item.Kraj,
                Siedziba = item.Siedziba,
                CzyAktywny = true
            };

            await firmaMobileService.AdresPOSTAsync(itemToAdd);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(AdresyForView item)
        {
            await firmaMobileService.AdresDELETEAsync(item.IdAdresu);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<AdresyForView> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(item => item.IdAdresu == id));
        }

        public async Task<IEnumerable<AdresyForView>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }

        public async Task<bool> UpdateItemAsync(AdresyForView item)
        {
            var oldItem = Items.FirstOrDefault((AdresyForView arg) => arg.IdAdresu == item.IdAdresu);
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }

    }
}