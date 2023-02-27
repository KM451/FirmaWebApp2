using Firma.Data.Model;
using FirmaWebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenaController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public CenaController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/Cena
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CenyForView>>> GetCeny()
        {
            var cena = await _context.Ceny
                .Include(item => item.Produkt)
                .Include(item => item.TypCeny)
                .ToListAsync();
            return cena.Select(c => (CenyForView)c).ToList();
        }

        // GET: api/Cena/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CenyForView>> GetCena(int id)
        {
            var cena = await _context.Ceny.FindAsync(id);

            if (cena == null)
            {
                return NotFound();
            }

            return (CenyForView)cena;
        }

        // PUT: api/Cena/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCena(int id, Cena cena)
        {
            if (id != cena.IdCeny)
            {
                return BadRequest();
            }

            _context.Entry(cena).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CenaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(id);
        }

        // POST: api/Cena
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CenyForView>> PostCena(Cena cena)
        {
            _context.Ceny.Add(cena);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCena", new { id = cena.IdCeny }, cena);
            return Ok(cena);
        }

        // DELETE: api/Cena/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCena(int id)
        {
            var cena = await _context.Ceny.FindAsync(id);
            if (cena == null)
            {
                return NotFound();
            }

            _context.Ceny.Remove(cena);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool CenaExists(int id)
        {
            return _context.Ceny.Any(e => e.IdCeny == id);
        }
    }
}
