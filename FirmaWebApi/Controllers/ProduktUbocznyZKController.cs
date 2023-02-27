using Firma.Data.Model;
using FirmaWebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktUbocznyZKController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public ProduktUbocznyZKController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/ProduktUbocznyZK
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProduktyUboczneZKForView>>> GetPrUboczneZleceniaKompletacji()
        {
            var produktUboczny = await _context.PrUboczneZleceniaKompletacji
                .Include(item => item.ZlecenieKompletacji.Kontrahent)
                .Include(item => item.ZlecenieKompletacji)
                .Include(item => item.Produkt)
                .ToListAsync();
            return produktUboczny.Select(pu => (ProduktyUboczneZKForView)pu).ToList();
        }

        // GET: api/ProduktUbocznyZK/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProduktyUboczneZKForView>> GetProduktUbocznyZK(int id)
        {
            var produktUbocznyZK = await _context.PrUboczneZleceniaKompletacji.FindAsync(id);

            if (produktUbocznyZK == null)
            {
                return NotFound();
            }

            return (ProduktyUboczneZKForView)produktUbocznyZK;
        }

        // PUT: api/ProduktUbocznyZK/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduktUbocznyZK(int id, ProduktUbocznyZK produktUbocznyZK)
        {
            if (id != produktUbocznyZK.IdPrUbocznego)
            {
                return BadRequest();
            }

            _context.Entry(produktUbocznyZK).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduktUbocznyZKExists(id))
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

        // POST: api/ProduktUbocznyZK
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProduktyUboczneZKForView>> PostProduktUbocznyZK(ProduktUbocznyZK produktUbocznyZK)
        {
            _context.PrUboczneZleceniaKompletacji.Add(produktUbocznyZK);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProduktUbocznyZK", new { id = produktUbocznyZK.IdPrUbocznego }, produktUbocznyZK);
            return Ok(produktUbocznyZK);
        }

        // DELETE: api/ProduktUbocznyZK/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduktUbocznyZK(int id)
        {
            var produktUbocznyZK = await _context.PrUboczneZleceniaKompletacji.FindAsync(id);
            if (produktUbocznyZK == null)
            {
                return NotFound();
            }

            _context.PrUboczneZleceniaKompletacji.Remove(produktUbocznyZK);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ProduktUbocznyZKExists(int id)
        {
            return _context.PrUboczneZleceniaKompletacji.Any(e => e.IdPrUbocznego == id);
        }
    }
}
