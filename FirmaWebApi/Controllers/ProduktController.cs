using Firma.Data.Model;
using FirmaWebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public ProduktController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/Produkt
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProduktyForView>>> GetProdukty()
        {
            var produkt = await _context.Produkty
                .Include(item => item.TypProduktu)
                .Include(item => item.Dostawca)
                .ToListAsync();
            return produkt.Select(p => (ProduktyForView)p).ToList();

        }

        // GET: api/Produkt/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProduktyForView>> GetProdukt(int id)
        {
            var produkt = await _context.Produkty.FindAsync(id);

            if (produkt == null)
            {
                return NotFound();
            }

            return (ProduktyForView)produkt;
        }

        // PUT: api/Produkt/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdukt(int id, Produkt produkt)
        {
            if (id != produkt.IdProduktu)
            {
                return BadRequest();
            }

            _context.Entry(produkt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduktExists(id))
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

        // POST: api/Produkt
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProduktyForView>> PostProdukt(Produkt produkt)
        {
            _context.Produkty.Add(produkt);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProdukt", new { id = produkt.IdProduktu }, produkt);
            return Ok(produkt);
        }

        // DELETE: api/Produkt/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdukt(int id)
        {
            var produkt = await _context.Produkty.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }

            _context.Produkty.Remove(produkt);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ProduktExists(int id)
        {
            return _context.Produkty.Any(e => e.IdProduktu == id);
        }
    }
}
