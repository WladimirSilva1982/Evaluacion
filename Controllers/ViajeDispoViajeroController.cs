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
    public class ViajeDispoViajeroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ViajeDispoViajeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ViajeDispoViajero
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViajeDispoViajero>>> GetViajeDispoViajero()
        {
            return await _context.ViajeDispoViajero.ToListAsync();
        }

        // GET: api/ViajeDispoViajero/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViajeDispoViajero>> GetViajeDispoViajero(string id)
        {
            var viajeDispoViajero = await _context.ViajeDispoViajero.FindAsync(id);

            if (viajeDispoViajero == null)
            {
                return NotFound();
            }

            return viajeDispoViajero;
        }

        // PUT: api/ViajeDispoViajero/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViajeDispoViajero(string id, ViajeDispoViajero viajeDispoViajero)
        {
            if (id != viajeDispoViajero.Cedula)
            {
                return BadRequest();
            }

            _context.Entry(viajeDispoViajero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViajeDispoViajeroExists(id))
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

        // POST: api/ViajeDispoViajero
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ViajeDispoViajero>> PostViajeDispoViajero(ViajeDispoViajero viajeDispoViajero)
        {
            _context.ViajeDispoViajero.Add(viajeDispoViajero);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ViajeDispoViajeroExists(viajeDispoViajero.Cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetViajeDispoViajero", new { id = viajeDispoViajero.Cedula }, viajeDispoViajero);
        }

        // DELETE: api/ViajeDispoViajero/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViajeDispoViajero(string id)
        {
            var viajeDispoViajero = await _context.ViajeDispoViajero.FindAsync(id);
            if (viajeDispoViajero == null)
            {
                return NotFound();
            }

            _context.ViajeDispoViajero.Remove(viajeDispoViajero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViajeDispoViajeroExists(string id)
        {
            return _context.ViajeDispoViajero.Any(e => e.Cedula == id);
        }
    }
}
