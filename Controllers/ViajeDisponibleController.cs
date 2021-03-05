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
    public class ViajeDisponibleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ViajeDisponibleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ViajeDisponible
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViajeDisponible>>> GetViajeDisponible()
        {
            return await _context.ViajeDisponible.ToListAsync();
        }

        // GET: api/ViajeDisponible/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViajeDisponible>> GetViajeDisponible(string id)
        {
            var viajeDisponible = await _context.ViajeDisponible.FindAsync(id);

            if (viajeDisponible == null)
            {
                return NotFound();
            }

            return viajeDisponible;
        }

        // PUT: api/ViajeDisponible/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViajeDisponible(string id, ViajeDisponible viajeDisponible)
        {
            if (id != viajeDisponible.CodViaje)
            {
                return BadRequest();
            }

            _context.Entry(viajeDisponible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViajeDisponibleExists(id))
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

        // POST: api/ViajeDisponible
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ViajeDisponible>> PostViajeDisponible(ViajeDisponible viajeDisponible)
        {
            _context.ViajeDisponible.Add(viajeDisponible);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ViajeDisponibleExists(viajeDisponible.CodViaje))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetViajeDisponible", new { id = viajeDisponible.CodViaje }, viajeDisponible);
        }

        // DELETE: api/ViajeDisponible/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViajeDisponible(string id)
        {
            var viajeDisponible = await _context.ViajeDisponible.FindAsync(id);
            if (viajeDisponible == null)
            {
                return NotFound();
            }

            _context.ViajeDisponible.Remove(viajeDisponible);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViajeDisponibleExists(string id)
        {
            return _context.ViajeDisponible.Any(e => e.CodViaje == id);
        }
    }
}
