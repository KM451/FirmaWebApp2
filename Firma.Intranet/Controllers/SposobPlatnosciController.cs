using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class SposobPlatnosciController : Controller
    {
        private readonly FirmaDbContext _context;

        public SposobPlatnosciController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: SposobPlatnosci
        public async Task<IActionResult> Index()
        {
            return View(await _context.SposobyPlatnosci.ToListAsync());
        }

        // GET: SposobPlatnosci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SposobyPlatnosci == null)
            {
                return NotFound();
            }

            var sposobPlatnosci = await _context.SposobyPlatnosci
                .FirstOrDefaultAsync(m => m.IdSposobuPlatnosci == id);
            if (sposobPlatnosci == null)
            {
                return NotFound();
            }

            return View(sposobPlatnosci);
        }

        // GET: SposobPlatnosci/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SposobPlatnosci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSposobuPlatnosci,Nazwa,Uwagi,CzyAktywny")] SposobPlatnosci sposobPlatnosci)
        {

            if (ModelState.IsValid)
            {
                _context.Add(sposobPlatnosci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sposobPlatnosci);
        }

        // GET: SposobPlatnosci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SposobyPlatnosci == null)
            {
                return NotFound();
            }

            var sposobPlatnosci = await _context.SposobyPlatnosci.FindAsync(id);
            if (sposobPlatnosci == null)
            {
                return NotFound();
            }
            return View(sposobPlatnosci);
        }

        // POST: SposobPlatnosci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSposobuPlatnosci,Nazwa,Uwagi,CzyAktywny")] SposobPlatnosci sposobPlatnosci)
        {
            if (id != sposobPlatnosci.IdSposobuPlatnosci)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sposobPlatnosci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SposobPlatnosciExists(sposobPlatnosci.IdSposobuPlatnosci))
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
            return View(sposobPlatnosci);
        }

        // GET: SposobPlatnosci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SposobyPlatnosci == null)
            {
                return NotFound();
            }

            var sposobPlatnosci = await _context.SposobyPlatnosci
                .FirstOrDefaultAsync(m => m.IdSposobuPlatnosci == id);
            if (sposobPlatnosci == null)
            {
                return NotFound();
            }

            return View(sposobPlatnosci);
        }

        // POST: SposobPlatnosci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SposobyPlatnosci == null)
            {
                return Problem("Entity set 'FirmaDbContext.SposobyPlatnosci'  is null.");
            }
            var sposobPlatnosci = await _context.SposobyPlatnosci.FindAsync(id);
            if (sposobPlatnosci != null)
            {
                _context.SposobyPlatnosci.Remove(sposobPlatnosci);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SposobPlatnosciExists(int id)
        {
            return _context.SposobyPlatnosci.Any(e => e.IdSposobuPlatnosci == id);
        }
    }
}
