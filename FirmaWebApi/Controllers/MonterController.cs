using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonterController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public MonterController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/Monter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monter>>> GetMonterzy()
        {
            return await _context.Monterzy.ToListAsync();
        }

        // GET: api/Monter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Monter>> GetMonter(int id)
        {
            var monter = await _context.Monterzy.FindAsync(id);

            if (monter == null)
            {
                return NotFound();
            }

            return monter;
        }

        // PUT: api/Monter/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonter(int id, Monter monter)
        {
            if (id != monter.IdMontera)
            {
                return BadRequest();
            }

            _context.Entry(monter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonterExists(id))
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

        // POST: api/Monter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Monter>> PostMonter(Monter monter)
        {
            _context.Monterzy.Add(monter);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetMonter", new { id = monter.IdMontera }, monter);
            return Ok(monter);
        }

        // DELETE: api/Monter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonter(int id)
        {
            var monter = await _context.Monterzy.FindAsync(id);
            if (monter == null)
            {
                return NotFound();
            }

            _context.Monterzy.Remove(monter);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool MonterExists(int id)
        {
            return _context.Monterzy.Any(e => e.IdMontera == id);
        }
    }
}
