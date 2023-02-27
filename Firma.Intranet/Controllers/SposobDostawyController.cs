using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class SposobDostawyController : Controller
    {
        private readonly FirmaDbContext _context;

        public SposobDostawyController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: SposobDostawy
        public async Task<IActionResult> Index()
        {
            return View(await _context.SposobyDostawy.ToListAsync());
        }

        // GET: SposobDostawy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SposobyDostawy == null)
            {
                return NotFound();
            }

            var sposobDostawy = await _context.SposobyDostawy
                .FirstOrDefaultAsync(m => m.IdSposobuDostawy == id);
            if (sposobDostawy == null)
            {
                return NotFound();
            }

            return View(sposobDostawy);
        }

        // GET: SposobDostawy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SposobDostawy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSposobuDostawy,Nazwa,Uwagi,CzyAktywny")] SposobDostawy sposobDostawy)
        {

            if (ModelState.IsValid)
            {
                _context.Add(sposobDostawy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sposobDostawy);
        }

        // GET: SposobDostawy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SposobyDostawy == null)
            {
                return NotFound();
            }

            var sposobDostawy = await _context.SposobyDostawy.FindAsync(id);
            if (sposobDostawy == null)
            {
                return NotFound();
            }
            return View(sposobDostawy);
        }

        // POST: SposobDostawy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSposobuDostawy,Nazwa,Uwagi,CzyAktywny")] SposobDostawy sposobDostawy)
        {
            if (id != sposobDostawy.IdSposobuDostawy)
            {
                return NotFound();
            }
   
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sposobDostawy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SposobDostawyExists(sposobDostawy.IdSposobuDostawy))
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
            return View(sposobDostawy);
        }

        // GET: SposobDostawy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SposobyDostawy == null)
            {
                return NotFound();
            }

            var sposobDostawy = await _context.SposobyDostawy
                .FirstOrDefaultAsync(m => m.IdSposobuDostawy == id);
            if (sposobDostawy == null)
            {
                return NotFound();
            }

            return View(sposobDostawy);
        }

        // POST: SposobDostawy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SposobyDostawy == null)
            {
                return Problem("Entity set 'FirmaDbContext.SposobyDostawy'  is null.");
            }
            var sposobDostawy = await _context.SposobyDostawy.FindAsync(id);
            if (sposobDostawy != null)
            {
                _context.SposobyDostawy.Remove(sposobDostawy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SposobDostawyExists(int id)
        {
            return _context.SposobyDostawy.Any(e => e.IdSposobuDostawy == id);
        }
    }
}
