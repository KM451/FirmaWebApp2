using Firma.Data.Model;

namespace FirmaWebApi.ViewModel
{
    public class ZleceniaZakupuForView
    {
        public int IdZleceniaZakupu { get; set; }
        public int IdKontrahenta { get; set; }
        public string? KontrahentDane { get; set; }
        public int IdTransakcji { get; set; }
        public string? TypTransakcjiNazwa { get; set; }
        public int IdSposobuDostawy { get; set; }
        public string? SposobDostawyNazwa { get; set; }
        public int IdRodzajuTransportu { get; set; }
        public string? RodzajTransportuNazwa { get; set; }
        public int IdSposobuPlatnosci { get; set; }
        public string? SposobPlatnosciNazwa { get; set; }
        public string? NrOferty { get; set; }
        public bool CzyPotwierdzone { get; set; }
        public string? NrPotwierdzenia { get; set; }
        public string Status { get; set; }
        public DateTime DataWystawienia { get; set; }
        public bool CzyAktywne { get; set; }

        public static explicit operator ZlecenieZakupu(ZleceniaZakupuForView zleceniaZakupuForView)
        {
            return new ZlecenieZakupu()
            {
                IdZleceniaZakupu = zleceniaZakupuForView.IdZleceniaZakupu,
                IdKontrahenta = zleceniaZakupuForView.IdKontrahenta,
                IdTransakcji = zleceniaZakupuForView.IdTransakcji,
                IdSposobuDostawy = zleceniaZakupuForView.IdSposobuDostawy,
                IdRodzajuTransportu = zleceniaZakupuForView.IdRodzajuTransportu,
                IdSposobuPlatnosci = zleceniaZakupuForView.IdSposobuPlatnosci,
                NrOferty = zleceniaZakupuForView.NrOferty,
                CzyPotwierdzone = zleceniaZakupuForView.CzyPotwierdzone,
                NrPotwierdzenia = zleceniaZakupuForView.NrPotwierdzenia,
                Status = zleceniaZakupuForView.Status,
                DataWystawienia = zleceniaZakupuForView.DataWystawienia,
                CzyAktywne = zleceniaZakupuForView.CzyAktywne
            };
        }
        public static explicit operator ZleceniaZakupuForView(ZlecenieZakupu zlecenieZakupu)
        {
            return new ZleceniaZakupuForView()
            {
                IdZleceniaZakupu = zlecenieZakupu.IdZleceniaZakupu,
                IdKontrahenta = zlecenieZakupu.IdKontrahenta,
                IdTransakcji = zlecenieZakupu.IdTransakcji,
                IdSposobuDostawy = zlecenieZakupu.IdSposobuDostawy,
                IdRodzajuTransportu = zlecenieZakupu.IdRodzajuTransportu,
                IdSposobuPlatnosci = zlecenieZakupu.IdSposobuPlatnosci,
                NrOferty = zlecenieZakupu.NrOferty,
                CzyPotwierdzone = zlecenieZakupu.CzyPotwierdzone,
                NrPotwierdzenia = zlecenieZakupu.NrPotwierdzenia,
                Status = zlecenieZakupu.Status,
                DataWystawienia = zlecenieZakupu.DataWystawienia,
                CzyAktywne = zlecenieZakupu.CzyAktywne,
                KontrahentDane = zlecenieZakupu.Kontrahent?.Nazwa + ", NIP: " + zlecenieZakupu.Kontrahent?.Nip,
                TypTransakcjiNazwa = zlecenieZakupu.TypTransakcji?.Nazwa,
                SposobDostawyNazwa = zlecenieZakupu.SposobDostawy?.Nazwa,
                RodzajTransportuNazwa = zlecenieZakupu.RodzajTransportu?.Nazwa,
                SposobPlatnosciNazwa = zlecenieZakupu.SposobPlatnosci?.Nazwa
            };
        }
    }
}
