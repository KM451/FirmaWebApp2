using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Model
{
    public class PozycjaZZ
    {

        [Key]
        public int IdPozycjiZleceniaZakupu { get; set; }

        [Display(Name = "Nr zlecenia zakupu")]
        public int IdZleceniaZakupu { get; set; }

        [Display(Name = "Produkt")]
        public int IdProduktu { get; set; }

        [Required]
        [Display(Name = "Ilość")]
        public decimal Ilosc { get; set; }

        [Required]
        [Display(Name = "Rabat")]
        public decimal Rabat { get; set; }

        [Display(Name = "Data realizacji")]
        public DateTime DataRealizacji { get; set; }

        [Display(Name = "Czy aktywna")]
        public bool CzyAktywna { get; set; }

        [ForeignKey("IdZleceniaZakupu")]
        public virtual ZlecenieZakupu? ZlecenieZakupu { get; set; }

        [ForeignKey("IdProduktu")]
        public virtual Produkt? Produkt { get; set; }

    }
}
