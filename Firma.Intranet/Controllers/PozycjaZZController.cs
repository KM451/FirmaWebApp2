using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class PozycjaZZController : Controller
    {
        private readonly FirmaDbContext _context;

        public PozycjaZZController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: PozycjaZZ
        public async Task<IActionResult> Index()
        {
            var firmaDbContext = _context.PozycjeZleceniaZakupu
                .Include(p => p.Produkt).Include(p => p.ZlecenieZakupu);
            return View(await firmaDbContext.ToListAsync());
        }

        // GET: PozycjaZZ/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PozycjeZleceniaZakupu == null)
            {
                return NotFound();
            }

            var pozycjaZZ = await _context.PozycjeZleceniaZakupu
                .Include(p => p.Produkt)
                .Include(p => p.ZlecenieZakupu)
                .FirstOrDefaultAsync(m => m.IdPozycjiZleceniaZakupu == id);
            if (pozycjaZZ == null)
            {
                return NotFound();
            }

            return View(pozycjaZZ);
        }

        // GET: PozycjaZZ/Create
        public IActionResult Create()
        {
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa");
            ViewData["IdZleceniaZakupu"] = new SelectList(_context.ZleceniaZakupu, "IdZleceniaZakupu", "IdZleceniaZakupu");
            return View();
        }

        // POST: PozycjaZZ/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPozycjiZleceniaZakupu,IdZleceniaZakupu,IdProduktu,Ilosc,Rabat,DataRealizacji,CzyAktywna")] PozycjaZZ pozycjaZZ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pozycjaZZ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", pozycjaZZ.IdProduktu);
            ViewData["IdZleceniaZakupu"] = new SelectList(_context.ZleceniaZakupu, "IdZleceniaZakupu", "IdZleceniaZakupu", pozycjaZZ.IdZleceniaZakupu);
            return View(pozycjaZZ);
        }

        // GET: PozycjaZZ/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PozycjeZleceniaZakupu == null)
            {
                return NotFound();
            }

            var pozycjaZZ = await _context.PozycjeZleceniaZakupu.FindAsync(id);
            if (pozycjaZZ == null)
            {
                return NotFound();
            }
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", pozycjaZZ.IdProduktu);
            ViewData["IdZleceniaZakupu"] = new SelectList(_context.ZleceniaZakupu, "IdZleceniaZakupu", "IdZleceniaZakupu", pozycjaZZ.IdZleceniaZakupu);
            return View(pozycjaZZ);
        }

        // POST: PozycjaZZ/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPozycjiZleceniaZakupu,IdZleceniaZakupu,IdProduktu,Ilosc,Rabat,DataRealizacji,CzyAktywna")] PozycjaZZ pozycjaZZ)
        {
            if (id != pozycjaZZ.IdPozycjiZleceniaZakupu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pozycjaZZ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PozycjaZZExists(pozycjaZZ.IdPozycjiZleceniaZakupu))
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
            ViewData["IdProduktu"] = new SelectList(_context.Produkty, "IdProduktu", "Nazwa", pozycjaZZ.IdProduktu);
            ViewData["IdZleceniaZakupu"] = new SelectList(_context.ZleceniaZakupu, "IdZleceniaZakupu", "IdZleceniaZakupu", pozycjaZZ.IdZleceniaZakupu);
            return View(pozycjaZZ);
        }

        // GET: PozycjaZZ/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PozycjeZleceniaZakupu == null)
            {
                return NotFound();
            }

            var pozycjaZZ = await _context.PozycjeZleceniaZakupu
                .Include(p => p.Produkt)
                .Include(p => p.ZlecenieZakupu)
                .FirstOrDefaultAsync(m => m.IdPozycjiZleceniaZakupu == id);
            if (pozycjaZZ == null)
            {
                return NotFound();
            }

            return View(pozycjaZZ);
        }

        // POST: PozycjaZZ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PozycjeZleceniaZakupu == null)
            {
                return Problem("Entity set 'FirmaDbContext.PozycjeZleceniaZakupu'  is null.");
            }
            var pozycjaZZ = await _context.PozycjeZleceniaZakupu.FindAsync(id);
            if (pozycjaZZ != null)
            {
                _context.PozycjeZleceniaZakupu.Remove(pozycjaZZ);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PozycjaZZExists(int id)
        {
          return _context.PozycjeZleceniaZakupu.Any(e => e.IdPozycjiZleceniaZakupu == id);
        }
    }
}
