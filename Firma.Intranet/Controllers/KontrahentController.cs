using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class KontrahentController : Controller
    {
        private readonly FirmaDbContext _context;

        public KontrahentController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: Kontrahent
        public async Task<IActionResult> Index()
        {
            var firmaDbContext = _context.Kontrahenci
                .Include(k => k.SposobPlatnosci).Include(k=>k.Adres);
            return View(await firmaDbContext.ToListAsync());
        }

        // GET: Kontrahent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kontrahenci == null)
            {
                return NotFound();
            }

            var kontrahent = await _context.Kontrahenci
                .Include(k => k.SposobPlatnosci)
                .Include(k => k.Adres)
                .FirstOrDefaultAsync(m => m.IdKontrahenta == id);
            if (kontrahent == null)
            {
                return NotFound();
            }

            return View(kontrahent);
        }

        // GET: Kontrahent/Create
        public IActionResult Create()
        {
            ViewData["IdSposobuPlatnosci"] = new SelectList(_context.SposobyPlatnosci, "IdSposobuPlatnosci", "Nazwa");
            return View();
        }

        // POST: Kontrahent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKontrahenta,Akronim,Nazwa,Nip,IdSposobuPlatnosci,CzyAktywny")] Kontrahent kontrahent)
        {
 
            if (ModelState.IsValid)
            {
                _context.Add(kontrahent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSposobuPlatnosci"] = new SelectList(_context.SposobyPlatnosci, "IdSposobuPlatnosci", "Nazwa", kontrahent.IdSposobuPlatnosci);
            return View(kontrahent);
        }

        // GET: Kontrahent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kontrahenci == null)
            {
                return NotFound();
            }

            var kontrahent = await _context.Kontrahenci.FindAsync(id);
            if (kontrahent == null)
            {
                return NotFound();
            }
            ViewData["IdSposobuPlatnosci"] = new SelectList(_context.SposobyPlatnosci, "IdSposobuPlatnosci", "Nazwa", kontrahent.IdSposobuPlatnosci);
            return View(kontrahent);
        }

        // POST: Kontrahent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKontrahenta,Akronim,Nazwa,Nip,IdSposobuPlatnosci,CzyAktywny")] Kontrahent kontrahent)
        {
            if (id != kontrahent.IdKontrahenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kontrahent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KontrahentExists(kontrahent.IdKontrahenta))
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
            ViewData["IdSposobuPlatnosci"] = new SelectList(_context.SposobyPlatnosci, "IdSposobuPlatnosci", "Nazwa", kontrahent.IdSposobuPlatnosci);
            return View(kontrahent);
        }

        // GET: Kontrahent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kontrahenci == null)
            {
                return NotFound();
            }

            var kontrahent = await _context.Kontrahenci
                .Include(k => k.SposobPlatnosci)
                .Include(k => k.Adres)
                .FirstOrDefaultAsync(m => m.IdKontrahenta == id);
            if (kontrahent == null)
            {
                return NotFound();
            }

            return View(kontrahent);
        }

        // POST: Kontrahent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kontrahenci == null)
            {
                return Problem("Entity set 'FirmaDbContext.Kontrahenci'  is null.");
            }
            var kontrahent = await _context.Kontrahenci.FindAsync(id);
            if (kontrahent != null)
            {
                _context.Kontrahenci.Remove(kontrahent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KontrahentExists(int id)
        {
          return _context.Kontrahenci.Any(e => e.IdKontrahenta == id);
        }
    }
}
