using Firma.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypProduktuController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public TypProduktuController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/TypProduktu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypProduktu>>> GetTypyProduktow()
        {
            return await _context.TypyProduktow.ToListAsync();
        }

        // GET: api/TypProduktu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypProduktu>> GetTypProduktu(int id)
        {
            var typProduktu = await _context.TypyProduktow.FindAsync(id);

            if (typProduktu == null)
            {
                return NotFound();
            }

            return typProduktu;
        }

        // PUT: api/TypProduktu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypProduktu(int id, TypProduktu typProduktu)
        {
            if (id != typProduktu.IdTypuProduktu)
            {
                return BadRequest();
            }

            _context.Entry(typProduktu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypProduktuExists(id))
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

        // POST: api/TypProduktu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypProduktu>> PostTypProduktu(TypProduktu typProduktu)
        {
            _context.TypyProduktow.Add(typProduktu);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTypProduktu", new { id = typProduktu.IdTypuProduktu }, typProduktu);
            return Ok(typProduktu);
        }

        // DELETE: api/TypProduktu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypProduktu(int id)
        {
            var typProduktu = await _context.TypyProduktow.FindAsync(id);
            if (typProduktu == null)
            {
                return NotFound();
            }

            _context.TypyProduktow.Remove(typProduktu);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool TypProduktuExists(int id)
        {
            return _context.TypyProduktow.Any(e => e.IdTypuProduktu == id);
        }
    }
}
