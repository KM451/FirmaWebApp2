using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Model
{
    public class Kontrahent
    {
        [Required]
        [Key]
        public int IdKontrahenta { get; set; }

        [Required]
        [Display(Name = "Akronim")]
        [Column(TypeName = "nvarchar(40)")]
        public string Akronim { get; set; }
        [Required]
        [Display(Name = "Nazwa klienta")]
        [Column(TypeName = "nvarchar(255)")]
        public string Nazwa { get; set; }

        [Display(Name = "NIP")]
        [Column(TypeName = "nvarchar(20)")]
        [DefaultValue("000-000-00-00")]
        public string? Nip { get; set; }

       // [Required]
        [Display(Name = "Sposób płatności")]
        //[Column(TypeName = "nvarchar(32)")]
        public int IdSposobuPlatnosci { get; set; }

       // [Required]
       // [Display(Name = "Czy aktywny")]
        public bool CzyAktywny { get; set; }

        [ForeignKey("IdSposobuPlatnosci")]
      //  [Display(Name = "Sposób płatności")]
        public virtual SposobPlatnosci? SposobPlatnosci { get; set; }

        public virtual ICollection<Adres>? Adres { get; set; }
      
    }
}
