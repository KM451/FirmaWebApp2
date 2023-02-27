using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Model
{
    public class Produkt
    {
        [Key]
        public int IdProduktu { get; set; }

        [Required]
        [Display(Name = "Kod")]
        public string Kod { get; set; }

        [Required]
        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }

        [Display(Name = "Dodatkowa nazwa")]
        public string? DodatkowaNazwa { get; set; }

        [Required]
        [Display(Name = "Jednostka miary")]
        public string JednostkaMiary { get; set; }

        [Display(Name = "Symbol")]
        public string? Symbol { get; set; }

        [Display(Name = "Numer SWW/PKWiU")]
        public string? SWW_PKWiU { get; set; }

        [Required]
        [Display(Name = "Producent")]
        public string Producent { get; set; }

        [Display(Name = "Typ")]
        public int IdTypu { get; set; }

        [Display(Name = "Wybierz zdjęcie")]
        public string? FotoURL { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Stawka Vat zakupu")]
        public decimal StawkaVatZakupu { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Stawka Vat sprzedaży")]
        public decimal StawkaVatSprzedazy { get; set; }

        [Display(Name = "Odwrotne obciążenie")]
        public bool OdwrotneObciazenie { get; set; }

        [Display(Name = "Podzielona płatność")]
        public bool PodzielonaPlatnosc { get; set; }

        [Display(Name = "Stawka cła")]
        public decimal? StawkaCla { get; set; }

        [Display(Name = "Stawka akcyzy")]
        public decimal? StwkaAkcyzy { get; set; }

        [Display(Name = "Kod taryfy celnej")]
        public string? KodPcn { get; set; }

        [Display(Name = "Kraj pochodzenia")]
        public string? Kraj { get; set; }

        [Display(Name = "Czas kompletacji")]
        public int? CzasKompletacji { get; set; }

        [Display(Name = "Czy aktywna")]
        public bool CzyAktywna { get; set; }

        [Display(Name = "Dostawca")]
        public int IdDostawcy { get; set; }

        [ForeignKey("IdTypu")]
        public virtual TypProduktu? TypProduktu { get; set; }

        [ForeignKey("IdDostawcy")]
        public virtual Kontrahent? Dostawca { get; set; }

        public virtual ICollection<PozycjaZZ>? PozycjaZZ { get; set; }

        public virtual ICollection<Cena>? Cena { get; set; }

        public virtual ICollection<ZlecenieKompletacji>? ZlecenieKompletacji { get; set; }

        public virtual ICollection<ProduktUbocznyZK>? ProduktUbocznyZK { get; set; }

        public virtual ICollection<SkladnikZK>? SkladnikZK { get; set; }

    }
}
