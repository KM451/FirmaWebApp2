using Firma.Data.Model;
using FirmaWebApp.Models.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApp.Controllers
{
    public class ProduktController : ControllerWithLoggerAndContext
    {
        public ProduktController(ILogger<HomeController> logger, FirmaDbContext context) 
            : base(logger, context)
        {
        }
        public async Task<IActionResult> ProduktDetails(int id)
        {
            var typyproduktow = _context.TypyProduktow.ToList();
            ViewData["TypyProduktow"] = typyproduktow;
            var produkt = await _context.Produkty
                .Include(produkt=>produkt.Cena)
                .FirstOrDefaultAsync(p => p.IdProduktu == id && p.Cena
                                            .Where(c=>c.IdTypuCeny==1)
                                            .Any());
            return View(produkt);
        }
        public ActionResult AddToCart(int id)
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            var item = _context.Produkty.Find(id);
            cart.AddToCart(item);
            return RedirectToAction("ProduktDetails", new { id = item.IdProduktu });
        }
    }
}
