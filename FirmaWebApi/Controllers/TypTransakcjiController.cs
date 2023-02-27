using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypTransakcjiController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public TypTransakcjiController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/TypTransakcji
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypTransakcji>>> GetTypyTransakcji()
        {
            return await _context.TypyTransakcji.ToListAsync();
        }

        // GET: api/TypTransakcji/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypTransakcji>> GetTypTransakcji(int id)
        {
            var typTransakcji = await _context.TypyTransakcji.FindAsync(id);

            if (typTransakcji == null)
            {
                return NotFound();
            }

            return typTransakcji;
        }

        // PUT: api/TypTransakcji/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypTransakcji(int id, TypTransakcji typTransakcji)
        {
            if (id != typTransakcji.IdTypuTransakcji)
            {
                return BadRequest();
            }

            _context.Entry(typTransakcji).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypTransakcjiExists(id))
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

        // POST: api/TypTransakcji
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypTransakcji>> PostTypTransakcji(TypTransakcji typTransakcji)
        {
            _context.TypyTransakcji.Add(typTransakcji);
            await _context.SaveChangesAsync();
            //return CreatedAtAction("GetTypTransakcji", new { id = typTransakcji.IdTypuTransakcji }, typTransakcji);
            return Ok(typTransakcji);
        }

        // DELETE: api/TypTransakcji/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypTransakcji(int id)
        {
            var typTransakcji = await _context.TypyTransakcji.FindAsync(id);
            if (typTransakcji == null)
            {
                return NotFound();
            }

            _context.TypyTransakcji.Remove(typTransakcji);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool TypTransakcjiExists(int id)
        {
            return _context.TypyTransakcji.Any(e => e.IdTypuTransakcji == id);
        }
    }
}
