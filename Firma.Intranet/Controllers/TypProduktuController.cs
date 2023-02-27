using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class TypProduktuController : Controller
    {
        private readonly FirmaDbContext _context;

        public TypProduktuController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: TypProduktu
        public async Task<IActionResult> Index()
        {
              return View(await _context.TypyProduktow.ToListAsync());
        }

        // GET: TypProduktu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypyProduktow == null)
            {
                return NotFound();
            }

            var typProduktu = await _context.TypyProduktow
                .FirstOrDefaultAsync(m => m.IdTypuProduktu == id);
            if (typProduktu == null)
            {
                return NotFound();
            }

            return View(typProduktu);
        }

        // GET: TypProduktu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypProduktu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTypuProduktu,Nazwa,Uwagi,FotoURL,CzySklep,CzyAktywny")] TypProduktu typProduktu)
        {

            if (ModelState.IsValid)
            {
                _context.Add(typProduktu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typProduktu);
        }

        // GET: TypProduktu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypyProduktow == null)
            {
                return NotFound();
            }

            var typProduktu = await _context.TypyProduktow.FindAsync(id);
            if (typProduktu == null)
            {
                return NotFound();
            }
            return View(typProduktu);
        }

        // POST: TypProduktu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTypuProduktu,Nazwa,Uwagi,FotoURL,CzySklep,CzyAktywny")] TypProduktu typProduktu)
        {
            if (id != typProduktu.IdTypuProduktu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typProduktu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypProduktuExists(typProduktu.IdTypuProduktu))
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
            return View(typProduktu);
        }

        // GET: TypProduktu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypyProduktow == null)
            {
                return NotFound();
            }

            var typProduktu = await _context.TypyProduktow
                .FirstOrDefaultAsync(m => m.IdTypuProduktu == id);
            if (typProduktu == null)
            {
                return NotFound();
            }

            return View(typProduktu);
        }

        // POST: TypProduktu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypyProduktow == null)
            {
                return Problem("Entity set 'FirmaDbContext.TypyProduktow'  is null.");
            }
            var typProduktu = await _context.TypyProduktow.FindAsync(id);
            if (typProduktu != null)
            {
                _context.TypyProduktow.Remove(typProduktu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypProduktuExists(int id)
        {
          return _context.TypyProduktow.Any(e => e.IdTypuProduktu == id);
        }
    }
}
