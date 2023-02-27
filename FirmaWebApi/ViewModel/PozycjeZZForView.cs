using Firma.Data.Model;


namespace FirmaWebApi.ViewModel
{
    public class PozycjeZZForView
    {
        public int IdPozycjiZleceniaZakupu { get; set; }
        public int IdZleceniaZakupu { get; set; }
        public string? ZlecenieZakupuDane { get; set; }
        public int IdProduktu { get; set; }
        public string? ProduktDane { get; set; }
        public string? ProduktJednostkaMiary { get; set; }
        public decimal Ilosc { get; set; }
        public decimal Rabat { get; set; }
        public DateTime DataRealizacji { get; set; }

        public static explicit operator PozycjaZZ(PozycjeZZForView pozycjeZZForView)
        {
            return new PozycjaZZ()
            {
                IdPozycjiZleceniaZakupu = pozycjeZZForView.IdPozycjiZleceniaZakupu,
                IdZleceniaZakupu = pozycjeZZForView.IdPozycjiZleceniaZakupu,
                IdProduktu = pozycjeZZForView.IdProduktu,
                Ilosc = pozycjeZZForView.Ilosc,
                Rabat = pozycjeZZForView.Rabat,
                DataRealizacji = pozycjeZZForView.DataRealizacji,
                CzyAktywna = true
            };
        }
        public static explicit operator PozycjeZZForView(PozycjaZZ pozycjaZZ)
        {
            return new PozycjeZZForView() {
                IdPozycjiZleceniaZakupu = pozycjaZZ.IdPozycjiZleceniaZakupu,
                IdZleceniaZakupu = pozycjaZZ.IdPozycjiZleceniaZakupu,
                IdProduktu = pozycjaZZ.IdProduktu,
                Ilosc = pozycjaZZ.Ilosc,
                Rabat = pozycjaZZ.Rabat,
                DataRealizacji = pozycjaZZ.DataRealizacji,
                ZlecenieZakupuDane = "Nr: " + pozycjaZZ.ZlecenieZakupu.IdZleceniaZakupu.ToString() + " z dnia: " +
                                                    pozycjaZZ.ZlecenieZakupu?.DataWystawienia.ToString("d"),
                ProduktDane = pozycjaZZ.Produkt?.Kod + ", " + pozycjaZZ.Produkt?.Nazwa,
                ProduktJednostkaMiary = pozycjaZZ.Produkt?.JednostkaMiary
            };
        }
    }
}
