using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hasdrubal__Project.DBConnection;
using Hasdrubal__Project.Models;

namespace Hasdrubal__Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConservationLocationsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ConservationLocationsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/ConservationLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConservationLocation>>> GetConservationLocations()
        {
            return await _context.ConservationLocations.ToListAsync();
        }

        // GET: api/ConservationLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConservationLocation>> GetConservationLocation(int id)
        {
            var conservationLocation = await _context.ConservationLocations.FindAsync(id);

            if (conservationLocation == null)
            {
                return NotFound();
            }

            return conservationLocation;
        }

        // PUT: api/ConservationLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConservationLocation(int id, ConservationLocation conservationLocation)
        {
            if (id != conservationLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(conservationLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConservationLocationExists(id))
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

        // POST: api/ConservationLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConservationLocation>> PostConservationLocation(ConservationLocation conservationLocation)
        {
            _context.ConservationLocations.Add(conservationLocation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConservationLocationExists(conservationLocation.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConservationLocation", new { id = conservationLocation.Id }, conservationLocation);
        }

        // DELETE: api/ConservationLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConservationLocation(int id)
        {
            var conservationLocation = await _context.ConservationLocations.FindAsync(id);
            if (conservationLocation == null)
            {
                return NotFound();
            }

            _context.ConservationLocations.Remove(conservationLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConservationLocationExists(int id)
        {
            return _context.ConservationLocations.Any(e => e.Id == id);
        }
    }
}
