using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Model
{
    public class TypProduktu
    {
        [Key]
        public int IdTypuProduktu { get; set; }

        [Required]
        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }

        [Display(Name = "Uwagi")]
        public string? Uwagi { get; set; }

        [Display(Name = "Wybierz zdjęcie")]
        public string? FotoURL { get; set; }

        [Display(Name = "Czy widoczny w sklepie")]
        public bool CzySklep { get; set; }

        [Display(Name = "Czy aktywny")]
        public bool CzyAktywny { get; set; }

        public virtual ICollection<Produkt>? Produkt { get; set; }
    }
}
