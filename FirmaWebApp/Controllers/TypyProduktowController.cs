using Firma.Data.Model;
using FirmaWebApp.Models.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApp.Controllers
{
    public class TypyProduktowController : ControllerWithLoggerAndContext
    {
        public TypyProduktowController(ILogger<HomeController> logger, FirmaDbContext context) 
            : base(logger, context)
        {
        }

        public async Task<IActionResult> Index()
        {
            var typyproduktow = _context.TypyProduktow.Where(tp=>tp.CzySklep==true).ToList();
            ViewData["TypyProduktow"] = typyproduktow;
            var categories = await _context.TypyProduktow.Where(tp => tp.CzySklep == true).ToListAsync();
            return View(categories);
        }
        public async Task<IActionResult> Details(int id)
        {
            var typyproduktow = _context.TypyProduktow.ToList();
            ViewData["TypyProduktow"] = typyproduktow;
            var categories = await _context.TypyProduktow
                .Include(typProduktu => typProduktu.Produkt)
                .ThenInclude(produkt=>produkt.Cena)
                .FirstOrDefaultAsync(produkt => produkt.IdTypuProduktu == id);
            return View(categories);
        }
        public ActionResult AddToCart(int id)
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            var item = _context.Produkty.Find(id);
            cart.AddToCart(item);
            return RedirectToAction("Details" , new { id = item.IdTypu });
        }
        public ActionResult GoBack(int id)
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            var item = _context.Produkty.Find(id);
            return RedirectToAction("Details", new { id = item.IdTypu });
        }

    }
}
