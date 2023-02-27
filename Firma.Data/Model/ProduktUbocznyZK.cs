using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Model
{
    public class ProduktUbocznyZK
    {
        [Key]
        public int IdPrUbocznego { get; set; }

        [Display(Name = "Nr zlecenia kompletacji")]
        public int IdZleceniaKompletacji { get; set; }

        [Display(Name = "Składnik")]
        public int? IdProduktu { get; set; }

        [Required]
        [Display(Name = "Ilość")]
        public decimal Ilosc { get; set; }

        [Display(Name = "Czy aktywny")]
        public bool CzyAktywny { get; set; }

        [ForeignKey("IdZleceniaKompletacji")]

        [Display(Name = "Nr zlecenia kompletacji")]
        public virtual ZlecenieKompletacji? ZlecenieKompletacji { get; set; }

        [ForeignKey("IdProduktu")]
        public virtual Produkt? Produkt { get; set; }

    }
}
