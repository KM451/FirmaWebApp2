using Firma.Data.Model;

namespace FirmaWebApi.ViewModel
{
    public class MonterzyForView
    {
        public int IdMontera { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public bool CzyAktywny { get; set; }
        public MonterzyForView(){}
        public MonterzyForView(Monter monter)
        {
            IdMontera = monter.IdMontera;
            Nazwa= monter.Nazwa;
            Uwagi= monter?.Uwagi ??" ";
            CzyAktywny= monter.CzyAktywny;
        }

    }
}
