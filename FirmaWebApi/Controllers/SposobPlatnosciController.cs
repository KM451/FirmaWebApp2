using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SposobPlatnosciController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public SposobPlatnosciController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/SposobPlatnosci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SposobPlatnosci>>> GetSposobyPlatnosci()
        {
            return await _context.SposobyPlatnosci.ToListAsync();
        }

        // GET: api/SposobPlatnosci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SposobPlatnosci>> GetSposobPlatnosci(int id)
        {
            var sposobPlatnosci = await _context.SposobyPlatnosci.FindAsync(id);

            if (sposobPlatnosci == null)
            {
                return NotFound();
            }

            return sposobPlatnosci;
        }

        // PUT: api/SposobPlatnosci/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSposobPlatnosci(int id, SposobPlatnosci sposobPlatnosci)
        {
            if (id != sposobPlatnosci.IdSposobuPlatnosci)
            {
                return BadRequest();
            }

            _context.Entry(sposobPlatnosci).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SposobPlatnosciExists(id))
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

        // POST: api/SposobPlatnosci
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SposobPlatnosci>> PostSposobPlatnosci(SposobPlatnosci sposobPlatnosci)
        {
            _context.SposobyPlatnosci.Add(sposobPlatnosci);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetSposobPlatnosci", new { id = sposobPlatnosci.IdSposobuPlatnosci }, sposobPlatnosci);
            return Ok(sposobPlatnosci);
        }

        // DELETE: api/SposobPlatnosci/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSposobPlatnosci(int id)
        {
            var sposobPlatnosci = await _context.SposobyPlatnosci.FindAsync(id);
            if (sposobPlatnosci == null)
            {
                return NotFound();
            }

            _context.SposobyPlatnosci.Remove(sposobPlatnosci);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool SposobPlatnosciExists(int id)
        {
            return _context.SposobyPlatnosci.Any(e => e.IdSposobuPlatnosci == id);
        }
    }
}
