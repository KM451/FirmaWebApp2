using Firma.Data.Model;
using FirmaWebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZlecenieZakupuController : ControllerBase
    {
        private readonly FirmaDbContext _context;

        public ZlecenieZakupuController(FirmaDbContext context)
        {
            _context = context;
        }

        // GET: api/ZlecenieZakupu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZleceniaZakupuForView>>> GetZleceniaZakupu()
        {
            var zlecenieZ = await _context.ZleceniaZakupu
                .Include(item => item.Kontrahent)
                .Include(item => item.TypTransakcji)
                .Include(item => item.SposobDostawy)
                .Include(item => item.RodzajTransportu)
                .Include(item => item.SposobPlatnosci)
                .ToListAsync();
            return zlecenieZ.Select(zz => (ZleceniaZakupuForView)zz).ToList();
        }

        // GET: api/ZlecenieZakupu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ZleceniaZakupuForView>> GetZlecenieZakupu(int id)
        {
            var zlecenieZakupu = await _context.ZleceniaZakupu.FindAsync(id);

            if (zlecenieZakupu == null)
            {
                return NotFound();
            }

            return (ZleceniaZakupuForView)zlecenieZakupu;
        }

        // PUT: api/ZlecenieZakupu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZlecenieZakupu(int id, ZlecenieZakupu zlecenieZakupu)
        {
            if (id != zlecenieZakupu.IdZleceniaZakupu)
            {
                return BadRequest();
            }

            _context.Entry(zlecenieZakupu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZlecenieZakupuExists(id))
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

        // POST: api/ZlecenieZakupu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ZleceniaZakupuForView>> PostZlecenieZakupu(ZlecenieZakupu zlecenieZakupu)
        {
            _context.ZleceniaZakupu.Add(zlecenieZakupu);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetZlecenieZakupu", new { id = zlecenieZakupu.IdZleceniaZakupu }, zlecenieZakupu);
            return Ok(zlecenieZakupu);
        }

        // DELETE: api/ZlecenieZakupu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZlecenieZakupu(int id)
        {
            var zlecenieZakupu = await _context.ZleceniaZakupu.FindAsync(id);
            if (zlecenieZakupu == null)
            {
                return NotFound();
            }

            _context.ZleceniaZakupu.Remove(zlecenieZakupu);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ZlecenieZakupuExists(int id)
        {
            return _context.ZleceniaZakupu.Any(e => e.IdZleceniaZakupu == id);
        }
    }
}
