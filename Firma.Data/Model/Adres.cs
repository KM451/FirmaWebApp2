using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Firma.Data.Model
{
    public class Adres
    {
        [Key]
        public int IdAdresu { get; set; }

        [Required(ErrorMessage = "Podaj nazwę ulicy")]
        [MaxLength(50, ErrorMessage = "Nazwa ulicy powinna zawierać maks. 50 znaków")]
        [Display(Name = "Nazwa ulicy")]
        public string Ulica { get; set; }

        [Required(ErrorMessage = "Podaj nazwę miejscowości")]
        [MaxLength(50, ErrorMessage = "Nazwa miejscowości powinna zawierać maks. 50 znaków")]
        [Display(Name = "Nazwa miejscowości")]
        public string Miejscowosc { get; set; }

        [Required(ErrorMessage = "Podaj nr domu")]
        [MaxLength(10, ErrorMessage = "Nr domu powinien zawierać maks. 10 znaków")]
        [Display(Name = "Nr domu")]
        public string NrDomu { get; set; }

        [Display(Name = "Nr lokalu")]
        public string? NrLokalu { get; set; }

        [Required(ErrorMessage = "Podaj kod pocztowy")]
        [MaxLength(10, ErrorMessage = "Kod pocztowy powinien zawierać maks. 10 znaków")]
        [Display(Name = "Kod pocztowy")]
        public string KodPoczowy { get; set; }

        [Required(ErrorMessage = "Podaj nazwę poczty")]
        [MaxLength(10, ErrorMessage = "Nazwa poczty powinien zawierać maks. 50 znaków")]
        [Display(Name = "Poczta")]
        public string? Poczta { get; set; }

        [Required(ErrorMessage = "Podaj kraj")]
        [MaxLength(10, ErrorMessage = "Kraj powinien zawierać maks. 50 znaków")]
        [Display(Name = "Kraj")]
        public string Kraj { get; set; }

        [Required]
        [Display(Name = "Adres siedziby")]
        public bool Siedziba { get; set; }

        [Required]
        [Display(Name = "Adres główny")]
        public bool Glowny { get; set; }
        [Display(Name = "Czy aktywny")]
        public bool CzyAktywny { get; set; }

        
        public int IdKontrahenta { get; set; }

        [ForeignKey("IdKontrahenta")]
        public virtual Kontrahent? Kontrahent { get; set; }


    }
}