using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class ZlecenieZakupuController : Controller
    {
        private readonly FirmaDbContext _context;

        public ZlecenieZakupuController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: ZlecenieZakupu
        public async Task<IActionResult> Index()
        {
            var firmaDbContext = _context.ZleceniaZakupu
                .Include(z => z.Kontrahent)
                .Include(z => z.RodzajTransportu)
                .Include(z => z.SposobDostawy)
                .Include(z => z.SposobPlatnosci)
                .Include(z => z.TypTransakcji)
                .Include(z => z.PozycjaZZ);
            return View(await firmaDbContext.ToListAsync());
        }

        // GET: ZlecenieZakupu/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _context.ZleceniaZakupu == null)
            {
                return NotFound();
            }

            var zlecenieZakupu = await _context.ZleceniaZakupu
                .Include(z => z.Kontrahent)
                .Include(z => z.RodzajTransportu)
                .Include(z => z.SposobDostawy)
                .Include(z => z.SposobPlatnosci)
                .Include(z => z.TypTransakcji)
                .Include(z => z.PozycjaZZ)
                .FirstOrDefaultAsync(m => m.IdZleceniaZakupu == id);
            if (zlecenieZakupu == null)
            {
                return NotFound();
            }

            return View(zlecenieZakupu);
        }

        // GET: ZlecenieZakupu/Create
        public IActionResult Create()
        {
            ViewData["IdKontrahenta"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa");
            ViewData["IdRodzajuTransportu"] = new SelectList(_context.RodzajeTransportu, "IdRodzajuTransportu", "Nazwa");
            ViewData["IdSposobuDostawy"] = new SelectList(_context.SposobyDostawy, "IdSposobuDostawy", "Nazwa");
            ViewData["IdSposobuPlatnosci"] = new SelectList(_context.SposobyPlatnosci, "IdSposobuPlatnosci", "Nazwa");
            ViewData["IdTransakcji"] = new SelectList(_context.TypyTransakcji, "IdTypuTransakcji", "Nazwa");
            return View();
        }

        // POST: ZlecenieZakupu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZleceniaZakupu,IdKontrahenta,IdTransakcji,IdSposobuDostawy,IdRodzajuTransportu,IdSposobuPlatnosci,NrOferty,CzyPotwierdzone,NrPotwierdzenia,Status,DataWystawienia,CzyAktywne")] ZlecenieZakupu zlecenieZakupu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zlecenieZakupu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKontrahenta"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa", zlecenieZakupu.IdKontrahenta);
            ViewData["IdRodzajuTransportu"] = new SelectList(_context.RodzajeTransportu, "IdRodzajuTransportu", "Nazwa", zlecenieZakupu.IdRodzajuTransportu);
            ViewData["IdSposobuDostawy"] = new SelectList(_context.SposobyDostawy, "IdSposobuDostawy", "Nazwa", zlecenieZakupu.IdSposobuDostawy);
            ViewData["IdSposobuPlatnosci"] = new SelectList(_context.SposobyPlatnosci, "IdSposobuPlatnosci", "Nazwa", zlecenieZakupu.IdSposobuPlatnosci);
            ViewData["IdTransakcji"] = new SelectList(_context.TypyTransakcji, "IdTypuTransakcji", "Nazwa", zlecenieZakupu.IdTransakcji);
            return View(zlecenieZakupu);
        }

        // GET: ZlecenieZakupu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ZleceniaZakupu == null)
            {
                return NotFound();
            }

            var zlecenieZakupu = await _context.ZleceniaZakupu.FindAsync(id);
            if (zlecenieZakupu == null)
            {
                return NotFound();
            }
            ViewData["IdKontrahenta"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa", zlecenieZakupu.IdKontrahenta);
            ViewData["IdRodzajuTransportu"] = new SelectList(_context.RodzajeTransportu, "IdRodzajuTransportu", "Nazwa", zlecenieZakupu.IdRodzajuTransportu);
            ViewData["IdSposobuDostawy"] = new SelectList(_context.SposobyDostawy, "IdSposobuDostawy", "Nazwa", zlecenieZakupu.IdSposobuDostawy);
            ViewData["IdSposobuPlatnosci"] = new SelectList(_context.SposobyPlatnosci, "IdSposobuPlatnosci", "Nazwa", zlecenieZakupu.IdSposobuPlatnosci);
            ViewData["IdTransakcji"] = new SelectList(_context.TypyTransakcji, "IdTypuTransakcji", "Nazwa", zlecenieZakupu.IdTransakcji);
            return View(zlecenieZakupu);
        }

        // POST: ZlecenieZakupu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZleceniaZakupu,IdKontrahenta,IdTransakcji,IdSposobuDostawy,IdRodzajuTransportu,IdSposobuPlatnosci,NrOferty,CzyPotwierdzone,NrPotwierdzenia,Status,DataWystawienia,CzyAktywne")] ZlecenieZakupu zlecenieZakupu)
        {
            if (id != zlecenieZakupu.IdZleceniaZakupu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zlecenieZakupu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZlecenieZakupuExists(zlecenieZakupu.IdZleceniaZakupu))
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
            ViewData["IdKontrahenta"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa", zlecenieZakupu.IdKontrahenta);
            ViewData["IdRodzajuTransportu"] = new SelectList(_context.RodzajeTransportu, "IdRodzajuTransportu", "Nazwa", zlecenieZakupu.IdRodzajuTransportu);
            ViewData["IdSposobuDostawy"] = new SelectList(_context.SposobyDostawy, "IdSposobuDostawy", "Nazwa", zlecenieZakupu.IdSposobuDostawy);
            ViewData["IdSposobuPlatnosci"] = new SelectList(_context.SposobyPlatnosci, "IdSposobuPlatnosci", "Nazwa", zlecenieZakupu.IdSposobuPlatnosci);
            ViewData["IdTransakcji"] = new SelectList(_context.TypyTransakcji, "IdTypuTransakcji", "Nazwa", zlecenieZakupu.IdTransakcji);
            return View(zlecenieZakupu);
        }

        // GET: ZlecenieZakupu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ZleceniaZakupu == null)
            {
                return NotFound();
            }

            var zlecenieZakupu = await _context.ZleceniaZakupu
                .Include(z => z.Kontrahent)
                .Include(z => z.RodzajTransportu)
                .Include(z => z.SposobDostawy)
                .Include(z => z.SposobPlatnosci)
                .Include(z => z.TypTransakcji)
                .Include(z => z.PozycjaZZ)
                .FirstOrDefaultAsync(m => m.IdZleceniaZakupu == id);
            if (zlecenieZakupu == null)
            {
                return NotFound();
            }

            return View(zlecenieZakupu);
        }

        // POST: ZlecenieZakupu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ZleceniaZakupu == null)
            {
                return Problem("Entity set 'FirmaDbContext.ZleceniaZakupu'  is null.");
            }
            var zlecenieZakupu = await _context.ZleceniaZakupu.FindAsync(id);
            if (zlecenieZakupu != null)
            {
                _context.ZleceniaZakupu.Remove(zlecenieZakupu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZlecenieZakupuExists(int id)
        {
            return _context.ZleceniaZakupu.Any(e => e.IdZleceniaZakupu == id);
        }
    }
}
