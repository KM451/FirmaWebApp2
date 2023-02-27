using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class TypTransakcjiController : Controller
    {
        private readonly FirmaDbContext _context;

        public TypTransakcjiController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: TypTransakcji
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypyTransakcji.ToListAsync());
        }

        // GET: TypTransakcji/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypyTransakcji == null)
            {
                return NotFound();
            }

            var typTransakcji = await _context.TypyTransakcji
                .FirstOrDefaultAsync(m => m.IdTypuTransakcji == id);
            if (typTransakcji == null)
            {
                return NotFound();
            }

            return View(typTransakcji);
        }

        // GET: TypTransakcji/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypTransakcji/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTypuTransakcji,Nazwa,Uwagi,CzyAktywny")] TypTransakcji typTransakcji)
        {
 
            if (ModelState.IsValid)
            {
                _context.Add(typTransakcji);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typTransakcji);
        }

        // GET: TypTransakcji/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypyTransakcji == null)
            {
                return NotFound();
            }

            var typTransakcji = await _context.TypyTransakcji.FindAsync(id);
            if (typTransakcji == null)
            {
                return NotFound();
            }
            return View(typTransakcji);
        }

        // POST: TypTransakcji/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTypuTransakcji,Nazwa,Uwagi,CzyAktywny")] TypTransakcji typTransakcji)
        {
            if (id != typTransakcji.IdTypuTransakcji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typTransakcji);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypTransakcjiExists(typTransakcji.IdTypuTransakcji))
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
            return View(typTransakcji);
        }

        // GET: TypTransakcji/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypyTransakcji == null)
            {
                return NotFound();
            }

            var typTransakcji = await _context.TypyTransakcji
                .FirstOrDefaultAsync(m => m.IdTypuTransakcji == id);
            if (typTransakcji == null)
            {
                return NotFound();
            }

            return View(typTransakcji);
        }

        // POST: TypTransakcji/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypyTransakcji == null)
            {
                return Problem("Entity set 'FirmaDbContext.TypyTransakcji'  is null.");
            }
            var typTransakcji = await _context.TypyTransakcji.FindAsync(id);
            if (typTransakcji != null)
            {
                _context.TypyTransakcji.Remove(typTransakcji);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypTransakcjiExists(int id)
        {
            return _context.TypyTransakcji.Any(e => e.IdTypuTransakcji == id);
        }
    }
}
