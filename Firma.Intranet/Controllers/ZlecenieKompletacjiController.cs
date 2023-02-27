using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class ZlecenieKompletacjiController : Controller
    {
        private readonly FirmaDbContext _context;

        public ZlecenieKompletacjiController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: ZlecenieKompletacji
        public async Task<IActionResult> Index()
        {
            var firmaDbContext = _context.ZleceniaKompletacji
                .Include(z => z.Kontrahent)
                .Include(z => z.Monter)
                .Include(z => z.Produkt)
                .Include(z => z.ProduktUbocznyZK)
                .Include(z => z.SkladnikZK);
            return View(await firmaDbContext.ToListAsync());
        }

        // GET: ZlecenieKompletacji/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ZleceniaKompletacji == null)
            {
                return NotFound();
            }

            var zlecenieKompletacji = await _context.ZleceniaKompletacji
                .Include(z => z.Kontrahent)
                .Include(z => z.Monter)
                .Include(z => z.Produkt)
                .Include(z => z.ProduktUbocznyZK)
                .Include(z => z.SkladnikZK)
                .FirstOrDefaultAsync(m => m.IdZleceniaKompletacji == id);
            if (zlecenieKompletacji == null)
            {
                return NotFound();
            }
            ViewData["IdKontrahenta"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa");
            ViewData["IdMontera"] = new SelectList(_context.Monterzy, "IdMontera", "Nazwa");
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa");
            return View(zlecenieKompletacji);
        }

        // GET: ZlecenieKompletacji/Create
        public IActionResult Create()
        {
            ViewData["IdKontrahenta"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa");
            ViewData["IdMontera"] = new SelectList(_context.Monterzy, "IdMontera", "Nazwa");
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa");
            return View();
        }

        // POST: ZlecenieKompletacji/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZleceniaKompletacji,IdKontrahenta,DataWystawienia,OczekiwanaDataRealizacji,PotwierdzonaDataRealizacji,IdProduktu,Ilosc,IdMontera,Priorytet,Status,CzyAktywne,CzasZlecenia")] ZlecenieKompletacji zlecenieKompletacji)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zlecenieKompletacji);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKontrahenta"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa", zlecenieKompletacji.IdKontrahenta);
            ViewData["IdMontera"] = new SelectList(_context.Monterzy, "IdMontera", "Nazwa", zlecenieKompletacji.IdMontera);
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", zlecenieKompletacji.IdProduktu);
            return View(zlecenieKompletacji);
        }

        // GET: ZlecenieKompletacji/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ZleceniaKompletacji == null)
            {
                return NotFound();
            }

            var zlecenieKompletacji = await _context.ZleceniaKompletacji.FindAsync(id);
            if (zlecenieKompletacji == null)
            {
                return NotFound();
            }
            ViewData["IdKontrahenta"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa", zlecenieKompletacji.IdKontrahenta);
            ViewData["IdMontera"] = new SelectList(_context.Monterzy, "IdMontera", "Nazwa", zlecenieKompletacji.IdMontera);
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", zlecenieKompletacji.IdProduktu);
            return View(zlecenieKompletacji);
        }

        // POST: ZlecenieKompletacji/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZleceniaKompletacji,IdKontrahenta,DataWystawienia,OczekiwanaDataRealizacji,PotwierdzonaDataRealizacji,IdProduktu,Ilosc,IdMontera,Priorytet,Status,CzyAktywne,CzasZlecenia")] ZlecenieKompletacji zlecenieKompletacji)
        {
            if (id != zlecenieKompletacji.IdZleceniaKompletacji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zlecenieKompletacji);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZlecenieKompletacjiExists(zlecenieKompletacji.IdZleceniaKompletacji))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKontrahenta"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa", zlecenieKompletacji.IdKontrahenta);
            ViewData["IdMontera"] = new SelectList(_context.Monterzy, "IdMontera", "Nazwa", zlecenieKompletacji.IdMontera);
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", zlecenieKompletacji.IdProduktu);
            return View(zlecenieKompletacji);
        }

        // GET: ZlecenieKompletacji/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ZleceniaKompletacji == null)
            {
                return NotFound();
            }

            var zlecenieKompletacji = await _context.ZleceniaKompletacji
                .Include(z => z.Kontrahent)
                .Include(z => z.Monter)
                .Include(z => z.Produkt)
                .Include(z => z.ProduktUbocznyZK)
                .Include(z => z.SkladnikZK)
                .FirstOrDefaultAsync(m => m.IdZleceniaKompletacji == id);
            if (zlecenieKompletacji == null)
            {
                return NotFound();
            }

            return View(zlecenieKompletacji);
        }

        // POST: ZlecenieKompletacji/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ZleceniaKompletacji == null)
            {
                return Problem("Entity set 'FirmaDbContext.ZleceniaKompletacji'  is null.");
            }
            var zlecenieKompletacji = await _context.ZleceniaKompletacji.FindAsync(id);
            if (zlecenieKompletacji != null)
            {
                _context.ZleceniaKompletacji.Remove(zlecenieKompletacji);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZlecenieKompletacjiExists(int id)
        {
            return _context.ZleceniaKompletacji.Any(e => e.IdZleceniaKompletacji == id);
        }
    }
}
