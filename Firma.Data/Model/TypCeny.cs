using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Model
{
    public class TypCeny
    {
        [Key]
        public int IdTypuCeny { get; set; }

        [Required]
        [Display(Name = "Typ")]
        public string Typ { get; set; }

        [Display(Name = "Uwagi")]
        public string? Uwagi { get; set; }

        [Display(Name = "Czy aktywny")]
        public bool CzyAktywny { get; set; }

        public virtual ICollection<Cena>? Cena { get; set; }

    }
}
