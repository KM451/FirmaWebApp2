using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RodzajTransportuController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public RodzajTransportuController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/RodzajTransportu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RodzajTransportu>>> GetRodzajeTransportu()
        {
            return await _context.RodzajeTransportu.ToListAsync();
        }

        // GET: api/RodzajTransportu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RodzajTransportu>> GetRodzajTransportu(int id)
        {
            var rodzajTransportu = await _context.RodzajeTransportu.FindAsync(id);

            if (rodzajTransportu == null)
            {
                return NotFound();
            }

            return rodzajTransportu;
        }

        // PUT: api/RodzajTransportu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRodzajTransportu(int id, RodzajTransportu rodzajTransportu)
        {
            if (id != rodzajTransportu.IdRodzajuTransportu)
            {
                return BadRequest();
            }

            _context.Entry(rodzajTransportu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RodzajTransportuExists(id))
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

        // POST: api/RodzajTransportu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RodzajTransportu>> PostRodzajTransportu(RodzajTransportu rodzajTransportu)
        {
            _context.RodzajeTransportu.Add(rodzajTransportu);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetRodzajTransportu", new { id = rodzajTransportu.IdRodzajuTransportu }, rodzajTransportu);
            return Ok(rodzajTransportu);
        }

        // DELETE: api/RodzajTransportu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRodzajTransportu(int id)
        {
            var rodzajTransportu = await _context.RodzajeTransportu.FindAsync(id);
            if (rodzajTransportu == null)
            {
                return NotFound();
            }

            _context.RodzajeTransportu.Remove(rodzajTransportu);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool RodzajTransportuExists(int id)
        {
            return _context.RodzajeTransportu.Any(e => e.IdRodzajuTransportu == id);
        }
    }
}
