using Firma.Data.Model;
using FirmaWebApp.Models.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApp.Controllers
{
    public class OrderDataController : Controller
    {
        private readonly FirmaDbContext _context;
        
        public OrderDataController(FirmaDbContext context)
        {
            this._context = context;
        }

        public IActionResult KontrahentData()
        {
            return View();
        }

        public IActionResult AdresData()
        {
            return View();
        }

        public IActionResult ZZData()
        {
            ViewData["IdSposobuPlatnosci"] = new SelectList(_context.SposobyPlatnosci, "IdSposobuPlatnosci", "Nazwa");
            ViewData["IdSposobuDostawy"] = new SelectList(_context.SposobyDostawy, "IdSposobuDostawy", "Nazwa");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KontrahentData([Bind("Akronim, Nazwa, Nip")] Kontrahent kontrahent)
        {
            //ModelState.Remove("Status");
            if (ModelState.IsValid)
            {
                kontrahent.CzyAktywny = true;
                kontrahent.IdSposobuPlatnosci = _context.SposobyPlatnosci.Select(sp=>sp.IdSposobuPlatnosci).FirstOrDefault();
                //if
                await _context.AddAsync(kontrahent);
                await _context.SaveChangesAsync();

                return RedirectToAction("AdresData", new { id = kontrahent.IdKontrahenta });
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdresData([Bind("Ulica, Miejscowosc, NrDomu, NrLokalu, KodPoczowy, Poczta, Kraj")] Adres adres, int id)
        {
            //ModelState.Remove("Status");
            if (ModelState.IsValid)
            {
                adres.Glowny = true;
                adres.Siedziba = true;
                adres.CzyAktywny = true;
                adres.IdKontrahenta = id;

                await _context.AddAsync(adres);
                await _context.SaveChangesAsync();

                return RedirectToAction("ZZData", new { id });
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ZZData([Bind("IdSposobuDostawy, IdSposobuPlatnosci")] ZlecenieZakupu order, int id) 
        {
            CartB cartB = new CartB(this._context, this.HttpContext);
            var cartItems = await cartB.GetCartItems();

            ModelState.Remove("Status");
            if (ModelState.IsValid)
            {
                order.IdKontrahenta = id;
                order.IdTransakcji = 1;
                order.IdRodzajuTransportu = 1;
                order.DataWystawienia = DateTime.Now;
                order.Status = "w weryfikacji";
                order.NrOferty = "sklep internetowy";
                order.CzyAktywne = true;
                order.CzyPotwierdzone = false;
                order.TotalOrder = cartB.GetTotal().Result;

                await _context.AddAsync(order);
                await _context.SaveChangesAsync();

                foreach (var item in cartItems)
                {
                    var orderItem = new PozycjaZZ
                    {
                        IdProduktu = item.IdProduktu,
                        IdZleceniaZakupu = order.IdZleceniaZakupu,
                        Ilosc = item.Ilosc,
                        Rabat = 0,
                        DataRealizacji = DateTime.Now,
                        CzyAktywna = true
                    };
                    await _context.PozycjeZleceniaZakupu.AddAsync(orderItem);
                }
                await _context.SaveChangesAsync();
                
                cartB.ClearCart();

                return RedirectToAction("Summary", new { id = order.IdZleceniaZakupu });
            }
            return View();
        }
        public async Task<ActionResult> Summary(int id)
        {
            var order = await _context.ZleceniaZakupu
                .Include(z => z.RodzajTransportu)
                .Include(z => z.SposobDostawy)
                .Include(z => z.SposobPlatnosci)
                .Include(z => z.TypTransakcji)
                .Include(z => z.PozycjaZZ).ThenInclude(p=>p.Produkt).ThenInclude(c=>c.Cena)
                .Include(z => z.Kontrahent).ThenInclude(k => k.Adres)
                .FirstOrDefaultAsync(z => z.IdZleceniaZakupu == id);

            if (order == null)
            {
                return View("Error");
            }
            
            return View(order);
        }
    }
}
