using Firma.Data.Model;
using FirmaWebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkladnikZKController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public SkladnikZKController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/SkladnikZK
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkladnikZKForView>>> GetSkładnikiZleceniaKompletacji()
        {
            var skladnikZK = await _context.SkładnikiZleceniaKompletacji
                .Include(item => item.ZlecenieKompletacji.Kontrahent)
                .Include(item => item.ZlecenieKompletacji)
                .Include(item => item.Produkt)
                .ToListAsync();
            return skladnikZK.Select(sZK => (SkladnikZKForView)sZK).ToList();

        }

        // GET: api/SkladnikZK/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkladnikZKForView>> GetSkladnikZK(int id)
        {
            var skladnikZK = await _context.SkładnikiZleceniaKompletacji.FindAsync(id);

            if (skladnikZK == null)
            {
                return NotFound();
            }

            return (SkladnikZKForView)skladnikZK;
        }

        // PUT: api/SkladnikZK/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkladnikZK(int id, SkladnikZK skladnikZK)
        {
            if (id != skladnikZK.IdSkladnika)
            {
                return BadRequest();
            }

            _context.Entry(skladnikZK).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkladnikZKExists(id))
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

        // POST: api/SkladnikZK
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SkladnikZKForView>> PostSkladnikZK(SkladnikZK skladnikZK)
        {
            _context.SkładnikiZleceniaKompletacji.Add(skladnikZK);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetSkladnikZK", new { id = skladnikZK.IdSkladnika }, skladnikZK);
            return Ok(skladnikZK);
        }

        // DELETE: api/SkladnikZK/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkladnikZK(int id)
        {
            var skladnikZK = await _context.SkładnikiZleceniaKompletacji.FindAsync(id);
            if (skladnikZK == null)
            {
                return NotFound();
            }

            _context.SkładnikiZleceniaKompletacji.Remove(skladnikZK);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool SkladnikZKExists(int id)
        {
            return _context.SkładnikiZleceniaKompletacji.Any(e => e.IdSkladnika == id);
        }
    }
}
