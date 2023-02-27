using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class CenaController : Controller
    {
        private readonly FirmaDbContext _context;

        public CenaController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: Cena
        public async Task<IActionResult> Index()
        {
            var firmaDbContext = _context.Ceny.Include(c => c.Produkt).Include(c => c.TypCeny);
            return View(await firmaDbContext.ToListAsync());
        }

        // GET: Cena/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ceny == null)
            {
                return NotFound();
            }

            var cena = await _context.Ceny
                .Include(c => c.Produkt)
                .Include(c => c.TypCeny)
                .FirstOrDefaultAsync(m => m.IdCeny == id);
            if (cena == null)
            {
                return NotFound();
            }

            return View(cena);
        }

        // GET: Cena/Create
        public IActionResult Create()
        {
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa");
            ViewData["IdTypuCeny"] = new SelectList(_context.TypyCen, "IdTypuCeny", "Typ");
            return View();
        }

        // POST: Cena/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCeny,IdProduktu,IdTypuCeny,Wartosc,Waluta,CzyAktywna")] Cena cena)
        {

            if (ModelState.IsValid)
            {
                _context.Add(cena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", cena.IdProduktu);
            ViewData["IdTypuCeny"] = new SelectList(_context.TypyCen, "IdTypuCeny", "Typ", cena.IdTypuCeny);
            return View(cena);
        }

        // GET: Cena/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ceny == null)
            {
                return NotFound();
            }

            var cena = await _context.Ceny.FindAsync(id);
            if (cena == null)
            {
                return NotFound();
            }
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", cena.IdProduktu);
            ViewData["IdTypuCeny"] = new SelectList(_context.TypyCen, "IdTypuCeny", "Typ", cena.IdTypuCeny);
            return View(cena);
        }

        // POST: Cena/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCeny,IdProduktu,IdTypuCeny,Wartosc,Waluta,CzyAktywna")] Cena cena)
        {
            if (id != cena.IdCeny)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CenaExists(cena.IdCeny))
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
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", cena.IdProduktu);
            ViewData["IdTypuCeny"] = new SelectList(_context.TypyCen, "IdTypuCeny", "Typ", cena.IdTypuCeny);
            return View(cena);
        }

        // GET: Cena/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ceny == null)
            {
                return NotFound();
            }

            var cena = await _context.Ceny
                .Include(c => c.Produkt)
                .Include(c => c.TypCeny)
                .FirstOrDefaultAsync(m => m.IdCeny == id);
            if (cena == null)
            {
                return NotFound();
            }

            return View(cena);
        }

        // POST: Cena/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ceny == null)
            {
                return Problem("Entity set 'FirmaDbContext.Ceny'  is null.");
            }
            var cena = await _context.Ceny.FindAsync(id);
            if (cena != null)
            {
                _context.Ceny.Remove(cena);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CenaExists(int id)
        {
          return _context.Ceny.Any(e => e.IdCeny == id);
        }
    }
}
