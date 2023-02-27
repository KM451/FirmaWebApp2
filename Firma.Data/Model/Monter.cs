using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Model
{
    public class Monter
    {
        [Key]
        public int IdMontera { get; set; }

        [Required(ErrorMessage = "Podaj imię i nazwisko")]
        [Display(Name = "Imię i Nazwisko")]
        public string Nazwa { get; set; }

        [Display(Name = "Uwagi")]
        public string? Uwagi { get; set; }

        [Display(Name = "Czy aktywny")]
        public bool CzyAktywny { get; set; }

        public virtual ICollection<ZlecenieKompletacji>? ZlecenieKompletacji { get; set; }
    }
}
