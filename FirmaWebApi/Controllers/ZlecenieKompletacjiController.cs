using Firma.Data.Model;
using FirmaWebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZlecenieKompletacjiController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public ZlecenieKompletacjiController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/ZlecenieKompletacji
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZleceniaKompletacjiForView>>> GetZleceniaKompletacji()
        {
            var zlecenieK = await _context.ZleceniaKompletacji
                .Include(item => item.Kontrahent)
                .Include(item => item.Produkt)
                .Include(item => item.Monter)
                .ToListAsync();
            return zlecenieK.Select(zk => (ZleceniaKompletacjiForView)zk).ToList();
        }

        // GET: api/ZlecenieKompletacji/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ZleceniaKompletacjiForView>> GetZlecenieKompletacji(int id)
        {
            var zlecenieKompletacji = await _context.ZleceniaKompletacji.FindAsync(id);

            if (zlecenieKompletacji == null)
            {
                return NotFound();
            }

            return (ZleceniaKompletacjiForView)zlecenieKompletacji;
        }

        // PUT: api/ZlecenieKompletacji/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZlecenieKompletacji(int id, ZlecenieKompletacji zlecenieKompletacji)
        {
            if (id != zlecenieKompletacji.IdZleceniaKompletacji)
            {
                return BadRequest();
            }

            _context.Entry(zlecenieKompletacji).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZlecenieKompletacjiExists(id))
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

        // POST: api/ZlecenieKompletacji
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ZleceniaKompletacjiForView>> PostZlecenieKompletacji(ZlecenieKompletacji zlecenieKompletacji)
        {
            _context.ZleceniaKompletacji.Add(zlecenieKompletacji);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetZlecenieKompletacji", new { id = zlecenieKompletacji.IdZleceniaKompletacji }, zlecenieKompletacji);
            return Ok(zlecenieKompletacji);
        }

        // DELETE: api/ZlecenieKompletacji/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZlecenieKompletacji(int id)
        {
            var zlecenieKompletacji = await _context.ZleceniaKompletacji.FindAsync(id);
            if (zlecenieKompletacji == null)
            {
                return NotFound();
            }

            _context.ZleceniaKompletacji.Remove(zlecenieKompletacji);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ZlecenieKompletacjiExists(int id)
        {
            return _context.ZleceniaKompletacji.Any(e => e.IdZleceniaKompletacji == id);
        }
    }
}
