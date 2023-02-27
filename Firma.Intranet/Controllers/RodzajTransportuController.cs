using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class RodzajTransportuController : Controller
    {
        private readonly FirmaDbContext _context;

        public RodzajTransportuController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: RodzajTransportu
        public async Task<IActionResult> Index()
        {
            return View(await _context.RodzajeTransportu.ToListAsync());
        }

        // GET: RodzajTransportu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RodzajeTransportu == null)
            {
                return NotFound();
            }

            var rodzajTransportu = await _context.RodzajeTransportu
                .FirstOrDefaultAsync(m => m.IdRodzajuTransportu == id);
            if (rodzajTransportu == null)
            {
                return NotFound();
            }

            return View(rodzajTransportu);
        }

        // GET: RodzajTransportu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RodzajTransportu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRodzajuTransportu,Nazwa,Uwagi,CzyAktywny")] RodzajTransportu rodzajTransportu)
        {

            if (ModelState.IsValid)
            {
                _context.Add(rodzajTransportu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rodzajTransportu);
        }

        // GET: RodzajTransportu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RodzajeTransportu == null)
            {
                return NotFound();
            }

            var rodzajTransportu = await _context.RodzajeTransportu.FindAsync(id);
            if (rodzajTransportu == null)
            {
                return NotFound();
            }
            return View(rodzajTransportu);
        }

        // POST: RodzajTransportu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRodzajuTransportu,Nazwa,Uwagi,CzyAktywny")] RodzajTransportu rodzajTransportu)
        {
            if (id != rodzajTransportu.IdRodzajuTransportu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rodzajTransportu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RodzajTransportuExists(rodzajTransportu.IdRodzajuTransportu))
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
            return View(rodzajTransportu);
        }

        // GET: RodzajTransportu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RodzajeTransportu == null)
            {
                return NotFound();
            }

            var rodzajTransportu = await _context.RodzajeTransportu
                .FirstOrDefaultAsync(m => m.IdRodzajuTransportu == id);
            if (rodzajTransportu == null)
            {
                return NotFound();
            }

            return View(rodzajTransportu);
        }

        // POST: RodzajTransportu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RodzajeTransportu == null)
            {
                return Problem("Entity set 'FirmaDbContext.RodzajeTransportu'  is null.");
            }
            var rodzajTransportu = await _context.RodzajeTransportu.FindAsync(id);
            if (rodzajTransportu != null)
            {
                _context.RodzajeTransportu.Remove(rodzajTransportu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RodzajTransportuExists(int id)
        {
            return _context.RodzajeTransportu.Any(e => e.IdRodzajuTransportu == id);
        }
    }
}
