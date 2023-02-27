using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Model
{
    public class ZlecenieZakupu
    {
        [Key]
        [Display(Name = "Nr zlecenia zakupu")]
        public int IdZleceniaZakupu { get; set; }

        [Display(Name = "Kontrahent")]
        public int IdKontrahenta { get; set; }

        [Display(Name = "Typ transakcji")]
        public int IdTransakcji { get; set; }

        [Display(Name = "Sposób dostawy")]
        public int IdSposobuDostawy { get; set; }

        [Display(Name = "Rodzaj transportu")]
        public int IdRodzajuTransportu { get; set; }

        [Display(Name = "Sposób płatności")]
        public int IdSposobuPlatnosci { get; set; }

        [Display(Name = "Nr oferty zakupu")]
        public string? NrOferty { get; set; }

        [Display(Name = "Czy potwierdzone")]
        public bool CzyPotwierdzone { get; set; }

        [Display(Name = "Nr potwierdzenia")]
        public string? NrPotwierdzenia { get; set; }

        [Display(Name = "Status zlecenia")]
        public string Status { get; set; }

        [Display(Name = "Wartość zamówienia")]
        public decimal? TotalOrder { get; set; }

        [Required]
        [Display(Name = "Data wystawienia")]
        public DateTime DataWystawienia { get; set; }

        [Display(Name = "Czy aktywne")]
        public bool CzyAktywne { get; set; }

        [ForeignKey("IdKontrahenta")]
        public virtual Kontrahent? Kontrahent { get; set; }

        [ForeignKey("IdSposobuDostawy")]
        [Display(Name = "Sposób dostawy")]
        public virtual SposobDostawy? SposobDostawy { get; set; }

        [ForeignKey("IdTransakcji")]
        [Display(Name = "Typ transakcji")]
        public virtual TypTransakcji? TypTransakcji { get; set; }

        [ForeignKey("IdRodzajuTransportu")]
        [Display(Name = "Rodzaj transportu")]
        public virtual RodzajTransportu? RodzajTransportu { get; set; }

        [ForeignKey("IdSposobuPlatnosci")]
        [Display(Name = "Sposób płatności")]
        public virtual SposobPlatnosci? SposobPlatnosci { get; set; }
        public virtual ICollection<PozycjaZZ>? PozycjaZZ { get; set; }


    }
}
