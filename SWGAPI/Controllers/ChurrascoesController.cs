using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APPTESTE.Models;

namespace SWGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChurrascoesController : ControllerBase
    {
        private readonly Context _context;

        public ChurrascoesController(Context context)
        {
            _context = context;
        }

        // GET: api/Churrascoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Churrasco>>> GetChurrascos()
        {
            return await _context.Churrascos.ToListAsync();
        }

        // GET: api/Churrascoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Churrasco>> GetChurrasco(int id)
        {
            var churrasco = await _context.Churrascos.FindAsync(id);

            if (churrasco == null)
            {
                return NotFound();
            }

            return churrasco;
        }

        // PUT: api/Churrascoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChurrasco(int id, Churrasco churrasco)
        {
            if (id != churrasco.Id)
            {
                return BadRequest();
            }

            _context.Entry(churrasco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChurrascoExists(id))
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

        // POST: api/Churrascoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Churrasco>> PostChurrasco(Churrasco churrasco)
        {
            _context.Churrascos.Add(churrasco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChurrasco", new { id = churrasco.Id }, churrasco);
        }

        // DELETE: api/Churrascoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Churrasco>> DeleteChurrasco(int id)
        {
            var churrasco = await _context.Churrascos.FindAsync(id);
            if (churrasco == null)
            {
                return NotFound();
            }

            _context.Churrascos.Remove(churrasco);
            await _context.SaveChangesAsync();

            return churrasco;
        }

        private bool ChurrascoExists(int id)
        {
            return _context.Churrascos.Any(e => e.Id == id);
        }
    }
}
