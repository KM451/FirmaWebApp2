using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SposobDostawyController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public SposobDostawyController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/SposobDostawy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SposobDostawy>>> GetSposobyDostawy()
        {
            return await _context.SposobyDostawy.ToListAsync();
        }

        // GET: api/SposobDostawy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SposobDostawy>> GetSposobDostawy(int id)
        {
            var sposobDostawy = await _context.SposobyDostawy.FindAsync(id);

            if (sposobDostawy == null)
            {
                return NotFound();
            }

            return sposobDostawy;
        }

        // PUT: api/SposobDostawy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSposobDostawy(int id, SposobDostawy sposobDostawy)
        {
            if (id != sposobDostawy.IdSposobuDostawy)
            {
                return BadRequest();
            }

            _context.Entry(sposobDostawy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SposobDostawyExists(id))
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

        // POST: api/SposobDostawy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SposobDostawy>> PostSposobDostawy(SposobDostawy sposobDostawy)
        {
            _context.SposobyDostawy.Add(sposobDostawy);
            await _context.SaveChangesAsync();

            return Ok(sposobDostawy);
        }

        // DELETE: api/SposobDostawy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSposobDostawy(int id)
        {
            var sposobDostawy = await _context.SposobyDostawy.FindAsync(id);
            if (sposobDostawy == null)
            {
                return NotFound();
            }

            _context.SposobyDostawy.Remove(sposobDostawy);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool SposobDostawyExists(int id)
        {
            return _context.SposobyDostawy.Any(e => e.IdSposobuDostawy == id);
        }
    }
}
