using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class ProduktUbocznyZKController : Controller
    {
        private readonly FirmaDbContext _context;

        public ProduktUbocznyZKController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: ProduktUbocznyZK
        public async Task<IActionResult> Index()
        {
            var firmaDbContext = _context.PrUboczneZleceniaKompletacji
                .Include(p => p.Produkt)
                .Include(p => p.ZlecenieKompletacji);
            return View(await firmaDbContext.ToListAsync());
        }

        // GET: ProduktUbocznyZK/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PrUboczneZleceniaKompletacji == null)
            {
                return NotFound();
            }

            var produktUbocznyZK = await _context.PrUboczneZleceniaKompletacji
                .Include(p => p.Produkt)
                .Include(p => p.ZlecenieKompletacji)
                .FirstOrDefaultAsync(m => m.IdPrUbocznego == id);
            if (produktUbocznyZK == null)
            {
                return NotFound();
            }

            return View(produktUbocznyZK);
        }

        // GET: ProduktUbocznyZK/Create
        public IActionResult Create()
        {
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa");
            ViewData["IdZleceniaKompletacji"] = new SelectList(_context.ZleceniaKompletacji, "IdZleceniaKompletacji", "IdZleceniaKompletacji");
            return View();
        }

        // POST: ProduktUbocznyZK/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrUbocznego,IdZleceniaKompletacji,IdProduktu,Ilosc,CzyAktywny")] ProduktUbocznyZK produktUbocznyZK)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produktUbocznyZK);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", produktUbocznyZK.IdProduktu);
            ViewData["IdZleceniaKompletacji"] = new SelectList(_context.ZleceniaKompletacji, "IdZleceniaKompletacji", "IdZleceniaKompletacji", produktUbocznyZK.IdZleceniaKompletacji);
            return View(produktUbocznyZK);
        }

        // GET: ProduktUbocznyZK/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PrUboczneZleceniaKompletacji == null)
            {
                return NotFound();
            }

            var produktUbocznyZK = await _context.PrUboczneZleceniaKompletacji.FindAsync(id);
            if (produktUbocznyZK == null)
            {
                return NotFound();
            }
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", produktUbocznyZK.IdProduktu);
            ViewData["IdZleceniaKompletacji"] = new SelectList(_context.ZleceniaKompletacji, "IdZleceniaKompletacji", "IdZleceniaKompletacji", produktUbocznyZK.IdZleceniaKompletacji);
            return View(produktUbocznyZK);
        }

        // POST: ProduktUbocznyZK/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrUbocznego,IdZleceniaKompletacji,IdProduktu,Ilosc,CzyAktywny")] ProduktUbocznyZK produktUbocznyZK)
        {
            if (id != produktUbocznyZK.IdPrUbocznego)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produktUbocznyZK);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduktUbocznyZKExists(produktUbocznyZK.IdPrUbocznego))
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
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", produktUbocznyZK.IdProduktu);
            ViewData["IdZleceniaKompletacji"] = new SelectList(_context.ZleceniaKompletacji, "IdZleceniaKompletacji", "IdZleceniaKompletacji", produktUbocznyZK.IdZleceniaKompletacji);
            return View(produktUbocznyZK);
        }

        // GET: ProduktUbocznyZK/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PrUboczneZleceniaKompletacji == null)
            {
                return NotFound();
            }

            var produktUbocznyZK = await _context.PrUboczneZleceniaKompletacji
                .Include(p => p.Produkt)
                .Include(p => p.ZlecenieKompletacji)
                .FirstOrDefaultAsync(m => m.IdPrUbocznego == id);
            if (produktUbocznyZK == null)
            {
                return NotFound();
            }

            return View(produktUbocznyZK);
        }

        // POST: ProduktUbocznyZK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PrUboczneZleceniaKompletacji == null)
            {
                return Problem("Entity set 'FirmaDbContext.PrUboczneZleceniaKompletacji'  is null.");
            }
            var produktUbocznyZK = await _context.PrUboczneZleceniaKompletacji.FindAsync(id);
            if (produktUbocznyZK != null)
            {
                _context.PrUboczneZleceniaKompletacji.Remove(produktUbocznyZK);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduktUbocznyZKExists(int id)
        {
            return _context.PrUboczneZleceniaKompletacji.Any(e => e.IdPrUbocznego == id);
        }
    }
}
