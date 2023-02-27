using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class ProduktController : Controller
    {
        private readonly FirmaDbContext _context;

        public ProduktController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: Produkt
        public async Task<IActionResult> Index()
        {
            var firmaDbContext = _context.Produkty
                .Include(p => p.Dostawca)
                .Include(p => p.TypProduktu)
                .Include(p => p.Cena);
            return View(await firmaDbContext.ToListAsync());
        }

        // GET: Produkt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produkty == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkty
                .Include(p => p.Dostawca)
                .Include(p => p.TypProduktu)
                .Include(p => p.Cena)
                .FirstOrDefaultAsync(m => m.IdProduktu == id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        // GET: Produkt/Create
        public IActionResult Create()
        {
            ViewData["IdDostawcy"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa");
            ViewData["IdTypu"] = new SelectList(_context.TypyProduktow, "IdTypuProduktu", "Nazwa");
            return View();
        }

        // POST: Produkt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduktu,Kod,Nazwa,DodatkowaNazwa,JednostkaMiary,Symbol,SWW_PKWiU,Producent,IdTypu,FotoURL,StawkaVatZakupu,StawkaVatSprzedazy,OdwrotneObciazenie,PodzielonaPlatnosc,StawkaCla,StwkaAkcyzy,KodPcn,Kraj,CzasKompletacji,CzyAktywna,IdDostawcy")] Produkt produkt)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(produkt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDostawcy"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa", produkt.IdDostawcy);
            ViewData["IdTypu"] = new SelectList(_context.TypyProduktow, "IdTypuProduktu", "Nazwa", produkt.IdTypu);
            return View(produkt);
        }

        // GET: Produkt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produkty == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkty.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }
            ViewData["IdDostawcy"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa", produkt.IdDostawcy);
            ViewData["IdTypu"] = new SelectList(_context.TypyProduktow, "IdTypuProduktu", "Nazwa", produkt.IdTypu);
            return View(produkt);
        }

        // POST: Produkt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduktu,Kod,Nazwa,DodatkowaNazwa,JednostkaMiary,Symbol,SWW_PKWiU,Producent,IdTypu,FotoURL,StawkaVatZakupu,StawkaVatSprzedazy,OdwrotneObciazenie,PodzielonaPlatnosc,StawkaCla,StwkaAkcyzy,KodPcn,Kraj,CzasKompletacji,CzyAktywna,IdDostawcy")] Produkt produkt)
        {
            if (id != produkt.IdProduktu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produkt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduktExists(produkt.IdProduktu))
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
            ViewData["IdDostawcy"] = new SelectList(_context.Kontrahenci, "IdKontrahenta", "Nazwa", produkt.IdDostawcy);
            ViewData["IdTypu"] = new SelectList(_context.TypyProduktow, "IdTypuProduktu", "Nazwa", produkt.IdTypu);
            return View(produkt);
        }

        // GET: Produkt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produkty == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkty
                .Include(p => p.Dostawca)
                .Include(p => p.TypProduktu)
                .FirstOrDefaultAsync(m => m.IdProduktu == id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        // POST: Produkt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produkty == null)
            {
                return Problem("Entity set 'FirmaDbContext.Produkty'  is null.");
            }
            var produkt = await _context.Produkty.FindAsync(id);
            if (produkt != null)
            {
                _context.Produkty.Remove(produkt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduktExists(int id)
        {
          return _context.Produkty.Any(e => e.IdProduktu == id);
        }
    }
}
