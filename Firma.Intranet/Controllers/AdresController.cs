using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class AdresController : Controller
    {
        private readonly FirmaDbContext _context;

        public AdresController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: Adres
        public async Task<IActionResult> Index()
        {
            var firmaDbContext = _context.Adresy.Include(a => a.Kontrahent);
            return View(await firmaDbContext.ToListAsync());
        }

        // GET: Adres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Adresy == null)
            {
                return NotFound();
            }

            var adres = await _context.Adresy
                .Include(a => a.Kontrahent)
                .FirstOrDefaultAsync(m => m.IdAdresu == id);
            if (adres == null)
            {
                return NotFound();
            }

            return View(adres);
        }

        // GET: Adres/Create
        public IActionResult Create()
        {
            ViewData["IdKontrahenta"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa");
            return View();
        }

        // POST: Adres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdresu,Ulica,Miejscowosc,NrDomu,NrLokalu,KodPoczowy,Poczta,Kraj,Siedziba,Glowny,CzyAktywny,IdKontrahenta")] Adres adres)
        {

            if (ModelState.IsValid)
            {
                _context.Add(adres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKontrahenta"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa", adres.IdKontrahenta);
            return View(adres);
        }

        // GET: Adres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Adresy == null)
            {
                return NotFound();
            }

            var adres = await _context.Adresy.FindAsync(id);
            if (adres == null)
            {
                return NotFound();
            }
            ViewData["IdKontrahenta"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa", adres.IdKontrahenta);
            return View(adres);
        }

        // POST: Adres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdresu,Ulica,Miejscowosc,NrDomu,NrLokalu,KodPoczowy,Poczta,Kraj,Siedziba,Glowny,CzyAktywny,IdKontrahenta")] Adres adres)
        {
            if (id != adres.IdAdresu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdresExists(adres.IdAdresu))
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
            ViewData["IdKontrahenta"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa", adres.IdKontrahenta);
            return View(adres);
        }

        // GET: Adres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Adresy == null)
            {
                return NotFound();
            }

            var adres = await _context.Adresy
                .Include(a => a.Kontrahent)
                .FirstOrDefaultAsync(m => m.IdAdresu == id);
            if (adres == null)
            {
                return NotFound();
            }

            return View(adres);
        }

        // POST: Adres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Adresy == null)
            {
                return Problem("Entity set 'FirmaDbContext.Adresy'  is null.");
            }
            var adres = await _context.Adresy.FindAsync(id);
            if (adres != null)
            {
                _context.Adresy.Remove(adres);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdresExists(int id)
        {
            return _context.Adresy.Any(e => e.IdAdresu == id);
        }
    }
}
