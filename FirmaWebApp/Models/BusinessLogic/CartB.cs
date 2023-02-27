using Firma.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApp.Models.BusinessLogic
{
    public class CartB
    {
        private readonly FirmaDbContext _dbContext;
        private string IdSession;
        public CartB(FirmaDbContext dbContext, HttpContext httpContext)
        {
            _dbContext = dbContext;
            IdSession = GetSessionId(httpContext);
        }
        public string GetSessionId(HttpContext httpContext)
        {
            //Jeżeli w Sesji IdSesjiKoszyka jest null-em
            if (httpContext.Session.GetString("IdSession") == null)
            {
                //Jeżeli context.User.Identity.Name nie jest puste i nie posiada białych zanków
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("IdSession", httpContext.User.Identity.Name);
                }
                else
                {
                    // W przeciwnym wypadku wygeneruj przy pomocy random Guid IdSesjiKoszyka
                    Guid tempIdSession = Guid.NewGuid();
                    // Wyślij wygenerowane IdSesjiKoszyka jako cookie
                    httpContext.Session.SetString("IdSession", tempIdSession.ToString());
                }
            }
            return httpContext.Session.GetString("IdSession").ToString();
        }
        public void AddToCart(Produkt produkt)
        {
            //Najpierw sprawdzamy czy dany towar już istnieje w koszyku danego klienta
            var cartItem = _dbContext.CartItem
                .Where(item => item.IdSession == this.IdSession && item.IdProduktu == produkt.IdProduktu)
                .Select(item => item)
                .FirstOrDefault();

            // jeżeli brak tego towaru w koszyku
            if (cartItem == null)
            {
                // Wtedy tworzymy nowy element w koszyku
                cartItem = new CartItem()
                {
                    IdSession = this.IdSession,
                    IdProduktu = produkt.IdProduktu,
                    Produkt = _dbContext.Produkty.Find(produkt.IdProduktu),
                    Ilosc = 1
                };
                //i dodajemy do kolekcji lokalne
                _dbContext.CartItem.Add(cartItem);
            }
            else
            {
                // Jeżeli dany towar istnieje już w koszyku to liczbe sztuk zwiekszamy o 1
                cartItem.Ilosc++;
            }
            // Zapisujemy zmiany do bazy
            _dbContext.SaveChanges();
        }

        public void RemoveFromCart(int id)
        {
            var cartItem = _dbContext.CartItem
                .Where(item => item.IdSession == this.IdSession && item.Id == id)
                .Select(item => item)
                .FirstOrDefault();
            if (cartItem != null)
            {
                _dbContext.CartItem.Remove(cartItem);
            }
            _dbContext.SaveChanges();
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            return await
               _dbContext.CartItem.Where(item => item.IdSession == this.IdSession)
               .Include(item => item.Produkt)
               .Include(item => item.Produkt.Cena).ToListAsync();
        }

        public async Task<decimal> GetTotal()
        {
            var ceny = await _dbContext.CartItem.Where(item => item.IdSession == this.IdSession)
                .Select(item => item.Ilosc * item.Produkt.Cena
                                            .Where(c => c.IdTypuCeny == 1)
                                            .Select(c => c.Wartosc)
                                            .FirstOrDefault()).ToListAsync();
            return ceny.Sum();
        }
        public void ClearCart()
        {
            _dbContext.CartItem.ExecuteDelete();
        }

    }
}
