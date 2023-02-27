using Firma.Data.Model;

namespace FirmaWebApp.Models.Shop
{
    public class CartData
    {
        public List<CartItem> CartItems { get; set; }
        public decimal Total { get; set; }
    }
}

