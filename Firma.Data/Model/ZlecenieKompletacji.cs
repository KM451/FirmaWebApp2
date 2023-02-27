using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Model
{
    public class ZlecenieKompletacji
    {
        [Key]
        [Display(Name = "Nr zlecenia")]
        public int IdZleceniaKompletacji { get; set; }

        [Display(Name = "Kontrahent")]
        public int IdKontrahenta { get; set; }

        [Required]
        [Display(Name = "Data wystawienia")]
        public DateTime DataWystawienia { get; set; }

        [Required]
        [Display(Name = "Wymagana data realizacji")]
        public DateTime OczekiwanaDataRealizacji { get; set; }

        [Display(Name = "Potwierdzona data realizacji")]
        public DateTime? PotwierdzonaDataRealizacji { get; set; }

        [Display(Name = "Produkt")]
        public int IdProduktu { get; set; }

        [Required]
        [Display(Name = "Ilość")]
        public decimal Ilosc { get; set; }

        [Display(Name = "Monter")]
        public int? IdMontera { get; set; }

        [Display(Name = "Priorytet")]
        public int? Priorytet { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Czy aktywne")]
        public bool CzyAktywne { get; set; }

        [Display(Name = "Czas realizacji [min]")]
        public int? CzasZlecenia { get; set; }

        [ForeignKey("IdKontrahenta")]
        public virtual Kontrahent? Kontrahent { get; set; }

        [ForeignKey("IdMontera")]
        public virtual Monter? Monter { get; set; }

        [ForeignKey("IdProduktu")]
        public virtual Produkt? Produkt { get; set; }

       public virtual ICollection<ProduktUbocznyZK>? ProduktUbocznyZK { get; set; }

       public virtual ICollection<SkladnikZK>? SkladnikZK { get; set; }
    }
}
