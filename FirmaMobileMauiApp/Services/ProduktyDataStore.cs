using FirmaMobileMauiApp.ServiceReference;

namespace FirmaMobileMauiApp.Services
{
    public class ProduktyDataStore : ADataStore, IDataStore<ProduktyForView>
    {
        public List<ProduktyForView> Items { get; set; }
        public ProduktyDataStore() => RefreshList();
        public async Task RefreshList() => Items = firmaMobileService.ProduktAllAsync().Result.ToList();

        public async Task<bool> AddItemAsync(ProduktyForView item)
        {
            var itemToAdd = new Produkt
            {
                IdProduktu = item.IdProduktu,
                Kod = item.Kod,
                Nazwa = item.Nazwa,
                DodatkowaNazwa = item.DodatkowaNazwa,
                JednostkaMiary = item.JednostkaMiary,
                Symbol = item.Symbol,
                SwW_PKWiU = item.SwW_PKWiU,
                Producent = item.Producent,
                IdTypu = item.IdTypu,
                FotoURL = item.FotoURL,
                StawkaVatZakupu = item.StawkaVatZakupu,
                StawkaVatSprzedazy = item.StawkaVatSprzedazy,
                OdwrotneObciazenie = item.OdwrotneObciazenie,
                PodzielonaPlatnosc = item.PodzielonaPlatnosc,
                StawkaCla = item.StawkaCla,
                StwkaAkcyzy = item.StwkaAkcyzy,
                KodPcn = item.KodPcn,
                Kraj = item.Kraj,
                CzasKompletacji = item.CzasKompletacji,
                CzyAktywna = true,
                IdDostawcy = item.IdDostawcy
            };
            await firmaMobileService.ProduktPOSTAsync(itemToAdd);
            RefreshList();
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(ProduktyForView item)
        {
            await firmaMobileService.ProduktDELETEAsync(item.IdProduktu);
            RefreshList();
            return await Task.FromResult(true);
        }

        public async Task<ProduktyForView> GetItemAsync(int id) => await Task.FromResult(Items.FirstOrDefault(item => item.IdProduktu == id));

        public async Task<IEnumerable<ProduktyForView>> GetItemsAsync(bool forceRefresh = false) => await Task.FromResult(Items);

        public async Task<bool> UpdateItemAsync(ProduktyForView item)
        {
            var oldItem = Items.Where((ProduktyForView arg) => arg.IdProduktu == item.IdProduktu).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }
    }
}
