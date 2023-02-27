using FirmaMobileMauiApp.Models;
using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Services
{
    public class SposobyPlatnosciDataStore : ADataStore, IDataStore<SposobyPlatnosciForView>
    {
        public List<SposobyPlatnosciForView> Items { get; set; }
        public SposobyPlatnosciDataStore() => RefreshList();
        public async Task RefreshList()
        {
            var itemsFromService = firmaMobileService.SposobPlatnosciAllAsync().Result;
            Items = new List<SposobyPlatnosciForView>();
            Items = itemsFromService.Select(sposobPlatnosci => new SposobyPlatnosciForView(sposobPlatnosci)).ToList();
        }
        public async Task<bool> AddItemAsync(SposobyPlatnosciForView item)
        {
            var itemToAdd = new SposobPlatnosci()
            {
                Nazwa = item.Nazwa,
                Uwagi = item.Uwagi,
                CzyAktywny = true,
            };
            await firmaMobileService.SposobPlatnosciPOSTAsync(itemToAdd);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(SposobyPlatnosciForView item)
        {
            await firmaMobileService.SposobPlatnosciDELETEAsync(item.IdSposobuPlatnosci);
            RefreshList();
            return await Task.FromResult(true);
        }
        public async Task<SposobyPlatnosciForView> GetItemAsync(int id) => await Task.FromResult(Items.FirstOrDefault(s => s.IdSposobuPlatnosci == id));

        public async Task<IEnumerable<SposobyPlatnosciForView>> GetItemsAsync(bool forceRefresh = false) => await Task.FromResult(Items);

        public async Task<bool> UpdateItemAsync(SposobyPlatnosciForView item)
        {
            var oldItem = Items.Where((SposobyPlatnosciForView arg) => arg.IdSposobuPlatnosci == item.IdSposobuPlatnosci).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }
  
    }
}
