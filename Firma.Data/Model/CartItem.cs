using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Model
{
    public class CartItem
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string IdSession { get; set; }
        public decimal Ilosc { get; set; }
        public int IdProduktu { get; set; }
        [ForeignKey("IdProduktu")]
        public virtual Produkt? Produkt { get; set; }
    }
}
