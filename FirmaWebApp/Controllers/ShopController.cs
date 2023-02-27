using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly FirmaDbContext _context;
        public ShopController(FirmaDbContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.Typy = await _context.TypyProduktow.ToListAsync();
            if (id == null)
            {
                var pierwszy = await _context.TypyProduktow.FirstAsync();
                id = pierwszy.IdTypuProduktu;
            }
            return View(await _context.Produkty.Where(t => t.IdTypu == id)
                .Include(produkt=>produkt.Cena)
                .ToListAsync());
        }
    }
}

