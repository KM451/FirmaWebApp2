using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class TypCenyController : Controller
    {
        private readonly FirmaDbContext _context;

        public TypCenyController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: TypCeny
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypyCen.ToListAsync());
        }

        // GET: TypCeny/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypyCen == null)
            {
                return NotFound();
            }

            var typCeny = await _context.TypyCen
                .FirstOrDefaultAsync(m => m.IdTypuCeny == id);
            if (typCeny == null)
            {
                return NotFound();
            }

            return View(typCeny);
        }

        // GET: TypCeny/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypCeny/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTypuCeny,Typ,Uwagi,CzyAktywny")] TypCeny typCeny)
        {
  
            if (ModelState.IsValid)
            {
                _context.Add(typCeny);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typCeny);
        }

        // GET: TypCeny/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypyCen == null)
            {
                return NotFound();
            }

            var typCeny = await _context.TypyCen.FindAsync(id);
            if (typCeny == null)
            {
                return NotFound();
            }
            return View(typCeny);
        }

        // POST: TypCeny/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTypuCeny,Typ,Uwagi,CzyAktywny")] TypCeny typCeny)
        {
            if (id != typCeny.IdTypuCeny)
            {
                return NotFound();
            }
 
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typCeny);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypCenyExists(typCeny.IdTypuCeny))
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
            return View(typCeny);
        }

        // GET: TypCeny/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypyCen == null)
            {
                return NotFound();
            }

            var typCeny = await _context.TypyCen
                .FirstOrDefaultAsync(m => m.IdTypuCeny == id);
            if (typCeny == null)
            {
                return NotFound();
            }

            return View(typCeny);
        }

        // POST: TypCeny/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypyCen == null)
            {
                return Problem("Entity set 'FirmaDbContext.TypyCen'  is null.");
            }
            var typCeny = await _context.TypyCen.FindAsync(id);
            if (typCeny != null)
            {
                _context.TypyCen.Remove(typCeny);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypCenyExists(int id)
        {
            return _context.TypyCen.Any(e => e.IdTypuCeny == id);
        }
    }
}
