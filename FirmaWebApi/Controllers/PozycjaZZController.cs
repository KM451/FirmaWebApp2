using Firma.Data.Model;
using FirmaWebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PozycjaZZController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public PozycjaZZController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/PozycjaZZs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PozycjeZZForView>>> GetPozycjeZleceniaZakupu()
        {
            var pozycjaZZ = await _context.PozycjeZleceniaZakupu
                .Include(x => x.Produkt)
                .Include(x => x.ZlecenieZakupu)
                .Include(x => x.ZlecenieZakupu.Kontrahent)
                .ToListAsync();
            return pozycjaZZ.Select(x => (PozycjeZZForView)x).ToList();
        }

        // GET: api/PozycjaZZs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PozycjeZZForView>> GetPozycjaZZ(int id)
        {
            var pozycjaZZ = await _context.PozycjeZleceniaZakupu.FindAsync(id);

            if (pozycjaZZ == null)
            {
                return NotFound();
            }

            return (PozycjeZZForView)pozycjaZZ;
        }

        // PUT: api/PozycjaZZs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPozycjaZZ(int id, PozycjaZZ pozycjaZZ)
        {
            if (id != pozycjaZZ.IdPozycjiZleceniaZakupu)
            {
                return BadRequest();
            }

            _context.Entry(pozycjaZZ).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PozycjaZZExists(id))
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

        // POST: api/PozycjaZZs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PozycjeZZForView>> PostPozycjaZZ(PozycjaZZ pozycjaZZ)
        {
            _context.PozycjeZleceniaZakupu.Add(pozycjaZZ);
            await _context.SaveChangesAsync();

            return Ok(pozycjaZZ);  //return CreatedAtAction("GetPozycjaZZ", new { id = pozycjaZZ.IdPozycjiZleceniaZakupu }, pozycjaZZ);
        }

        // DELETE: api/PozycjaZZs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePozycjaZZ(int id)
        {
            var pozycjaZZ = await _context.PozycjeZleceniaZakupu.FindAsync(id);
            if (pozycjaZZ == null)
            {
                return NotFound();
            }

            _context.PozycjeZleceniaZakupu.Remove(pozycjaZZ);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool PozycjaZZExists(int id)
        {
            return _context.PozycjeZleceniaZakupu.Any(e => e.IdPozycjiZleceniaZakupu == id);
        }
    }
}
