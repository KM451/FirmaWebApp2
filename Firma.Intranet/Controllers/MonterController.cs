using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class MonterController : Controller
    {
        private readonly FirmaDbContext _context;

        public MonterController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: Monter
        public async Task<IActionResult> Index()
        {
              return View(await _context.Monterzy.ToListAsync());
        }

        // GET: Monter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Monterzy == null)
            {
                return NotFound();
            }

            var monter = await _context.Monterzy
                .FirstOrDefaultAsync(m => m.IdMontera == id);
            if (monter == null)
            {
                return NotFound();
            }

            return View(monter);
        }

        // GET: Monter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMontera,Nazwa,Uwagi,CzyAktywny")] Monter monter)
        {

            if (ModelState.IsValid)
            {
                _context.Add(monter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monter);
        }

        // GET: Monter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Monterzy == null)
            {
                return NotFound();
            }

            var monter = await _context.Monterzy.FindAsync(id);
            if (monter == null)
            {
                return NotFound();
            }
            return View(monter);
        }

        // POST: Monter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMontera,Nazwa,Uwagi,CzyAktywny")] Monter monter)
        {
            if (id != monter.IdMontera)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonterExists(monter.IdMontera))
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
            return View(monter);
        }

        // GET: Monter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Monterzy == null)
            {
                return NotFound();
            }

            var monter = await _context.Monterzy
                .FirstOrDefaultAsync(m => m.IdMontera == id);
            if (monter == null)
            {
                return NotFound();
            }

            return View(monter);
        }

        // POST: Monter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Monterzy == null)
            {
                return Problem("Entity set 'FirmaDbContext.Monterzy'  is null.");
            }
            var monter = await _context.Monterzy.FindAsync(id);
            if (monter != null)
            {
                _context.Monterzy.Remove(monter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonterExists(int id)
        {
          return _context.Monterzy.Any(e => e.IdMontera == id);
        }
    }
}
