using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Model
{
    public class Cena
    {
        [Key]
        public int IdCeny { get; set; }

        [Display(Name = "Produkt")]
        public int IdProduktu { get; set; }

        [Display(Name = "Typ ceny")]
        public int IdTypuCeny { get; set; }

        [Required]
        [Display(Name = "Wartość")]
        public decimal Wartosc { get; set; }

        [Required]
        [Display(Name = "Waluta")]
        public string Waluta { get; set; }

        [Display(Name = "Czy aktywna")]
        public bool CzyAktywna { get; set; }

        [ForeignKey("IdProduktu")]
        public virtual Produkt? Produkt { get; set; }

        [ForeignKey("IdTypuCeny")]
        public virtual TypCeny? TypCeny { get; set; }
    }
}
