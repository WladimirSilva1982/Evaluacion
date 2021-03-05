using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiViajes.Core.ContextSqlServerDB;
using ApiViajes.Core.Entities;

namespace ApiViajes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ViajeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Viajero
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viajero>>> GetViajero()
        {
            return await _context.Viajero.ToListAsync();
        }

        // GET: api/Viajero/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Viajero>> GetViajero(string id)
        {
            var viajero = await _context.Viajero.FindAsync(id);

            if (viajero == null)
            {
                return NotFound();
            }

            return viajero;
        }

        // PUT: api/Viajero/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViajero(string id, Viajero viajero)
        {
            if (id != viajero.Cedula)
            {
                return BadRequest();
            }

            _context.Entry(viajero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViajeroExists(id))
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

        // POST: api/Viajero
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Viajero>> PostViajero(Viajero viajero)
        {
            _context.Viajero.Add(viajero);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ViajeroExists(viajero.Cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetViajero", new { id = viajero.Cedula }, viajero);
        }

        // DELETE: api/Viajero/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViajero(string id)
        {
            var viajero = await _context.Viajero.FindAsync(id);
            if (viajero == null)
            {
                return NotFound();
            }

            _context.Viajero.Remove(viajero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViajeroExists(string id)
        {
            return _context.Viajero.Any(e => e.Cedula == id);
        }
    }
}
