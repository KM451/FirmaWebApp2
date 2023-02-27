using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Model;
using FirmaWebApi.ViewModel;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontrahentController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public KontrahentController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/Kontrahent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KontrahenciForView>>> GetKontrahenci()
        {
            var klient = await _context.Kontrahenci
                .Include(k => k.SposobPlatnosci)
                .ToListAsync();
            return klient.Select(k => (KontrahenciForView)k).ToList();
        }

        // GET: api/Kontrahent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KontrahenciForView>> GetKontrahent(int id)
        {
            var kontrahent = await _context.Kontrahenci.FindAsync(id);

            if (kontrahent == null)
            {
                return NotFound();
            }

            return (KontrahenciForView)kontrahent;
        }

        // PUT: api/Kontrahent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKontrahent(int id, Kontrahent kontrahent)
        {
            if (id != kontrahent.IdKontrahenta)
            {
                return BadRequest();
            }

            _context.Entry(kontrahent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KontrahentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Kontrahent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KontrahenciForView>> PostKontrahent(Kontrahent kontrahent)
        {
            _context.Kontrahenci.Add(kontrahent);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetKontrahent", new { id = kontrahent.IdKontrahenta }, kontrahent);
            return Ok(kontrahent);
        }

        // DELETE: api/Kontrahent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKontrahent(int id)
        {
            var kontrahent = await _context.Kontrahenci.FindAsync(id);
            if (kontrahent == null)
            {
                return NotFound();
            }

            _context.Kontrahenci.Remove(kontrahent);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool KontrahentExists(int id)
        {
            return _context.Kontrahenci.Any(e => e.IdKontrahenta == id);
        }
    }
}
