using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class SkladnikZKController : Controller
    {
        private readonly FirmaDbContext _context;

        public SkladnikZKController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: SkladnikZK
        public async Task<IActionResult> Index()
        {
            var firmaDbContext = _context.SkładnikiZleceniaKompletacji
                .Include(s => s.Produkt)
                .Include(s => s.ZlecenieKompletacji);
            return View(await firmaDbContext.ToListAsync());
        }

        // GET: SkladnikZK/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SkładnikiZleceniaKompletacji == null)
            {
                return NotFound();
            }

            var skladnikZK = await _context.SkładnikiZleceniaKompletacji
                .Include(s => s.Produkt)
                .Include(s => s.ZlecenieKompletacji)
                .FirstOrDefaultAsync(m => m.IdSkladnika == id);
            if (skladnikZK == null)
            {
                return NotFound();
            }

            return View(skladnikZK);
        }

        // GET: SkladnikZK/Create
        public IActionResult Create()
        {
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa");
            ViewData["IdZleceniaKompletacji"] = new SelectList(_context.ZleceniaKompletacji, "IdZleceniaKompletacji", "IdZleceniaKompletacji");
            return View();
        }

        // POST: SkladnikZK/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSkladnika,IdZleceniaKompletacji,IdProduktu,Ilosc,CzyAktywny")] SkladnikZK skladnikZK)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skladnikZK);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", skladnikZK.IdProduktu);
            ViewData["IdZleceniaKompletacji"] = new SelectList(_context.ZleceniaKompletacji, "IdZleceniaKompletacji", "IdZleceniaKompletacji", skladnikZK.IdZleceniaKompletacji);
            return View(skladnikZK);
        }

        // GET: SkladnikZK/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SkładnikiZleceniaKompletacji == null)
            {
                return NotFound();
            }

            var skladnikZK = await _context.SkładnikiZleceniaKompletacji.FindAsync(id);
            if (skladnikZK == null)
            {
                return NotFound();
            }
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", skladnikZK.IdProduktu);
            ViewData["IdZleceniaKompletacji"] = new SelectList(_context.ZleceniaKompletacji, "IdZleceniaKompletacji", "IdZleceniaKompletacji", skladnikZK.IdZleceniaKompletacji);
            return View(skladnikZK);
        }

        // POST: SkladnikZK/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSkladnika,IdZleceniaKompletacji,IdProduktu,Ilosc,CzyAktywny")] SkladnikZK skladnikZK)
        {
            if (id != skladnikZK.IdSkladnika)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skladnikZK);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkladnikZKExists(skladnikZK.IdSkladnika))
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
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", skladnikZK.IdProduktu);
            ViewData["IdZleceniaKompletacji"] = new SelectList(_context.ZleceniaKompletacji, "IdZleceniaKompletacji", "IdZleceniaKompletacji", skladnikZK.IdZleceniaKompletacji);
            return View(skladnikZK);
        }

        // GET: SkladnikZK/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SkładnikiZleceniaKompletacji == null)
            {
                return NotFound();
            }

            var skladnikZK = await _context.SkładnikiZleceniaKompletacji
                .Include(s => s.Produkt)
                .Include(s => s.ZlecenieKompletacji)
                .FirstOrDefaultAsync(m => m.IdSkladnika == id);
            if (skladnikZK == null)
            {
                return NotFound();
            }

            return View(skladnikZK);
        }

        // POST: SkladnikZK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SkładnikiZleceniaKompletacji == null)
            {
                return Problem("Entity set 'FirmaDbContext.SkładnikiZleceniaKompletacji'  is null.");
            }
            var skladnikZK = await _context.SkładnikiZleceniaKompletacji.FindAsync(id);
            if (skladnikZK != null)
            {
                _context.SkładnikiZleceniaKompletacji.Remove(skladnikZK);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkladnikZKExists(int id)
        {
            return _context.SkładnikiZleceniaKompletacji.Any(e => e.IdSkladnika == id);
        }
    }
}
