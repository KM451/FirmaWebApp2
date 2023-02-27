using Firma.Data.Model;

namespace FirmaWebApi.ViewModel
{
    public class TypyTransakcjiForView
    {
        public int IdTypuTransakcji { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public bool CzyAktywny { get; set; }
        public TypyTransakcjiForView(){}
        public TypyTransakcjiForView(TypTransakcji typTransakcji)
        {
            IdTypuTransakcji = typTransakcji.IdTypuTransakcji;
            Nazwa = typTransakcji.Nazwa;
            Uwagi = typTransakcji?.Uwagi ??" ";
            CzyAktywny = typTransakcji.CzyAktywny;
        }
    }
}
