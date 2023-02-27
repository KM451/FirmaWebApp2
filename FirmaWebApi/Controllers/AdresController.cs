using Firma.Data.Model;
using FirmaWebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public AdresController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/Adres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdresyForView>>> GetAdresy()
        {
            var adres = await _context.Adresy.ToListAsync();
            return adres.Select(a=> (AdresyForView)a).ToList();
        }

        // GET: api/Adres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdresyForView>> GetAdres(int id)
        {
            var adres = await _context.Adresy.FindAsync(id);

            if (adres == null)
            {
                return NotFound();
            }

            return (AdresyForView)adres;
        }

        // PUT: api/Adres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdres(int id, Adres adres)
        {
            if (id != adres.IdAdresu)
            {
                return BadRequest();
            }

            _context.Entry(adres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdresExists(id))
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

        // POST: api/Adres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdresyForView>> PostAdres(Adres adres)
        {
            _context.Adresy.Add(adres);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdres", new { id = adres.IdAdresu }, adres);
        }

        // DELETE: api/Adres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdres(int id)
        {
            var adres = await _context.Adresy.FindAsync(id);
            if (adres == null)
            {
                return NotFound();
            }

            _context.Adresy.Remove(adres);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool AdresExists(int id)
        {
            return _context.Adresy.Any(e => e.IdAdresu == id);
        }
    }
}
