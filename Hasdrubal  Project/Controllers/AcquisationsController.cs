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
    public class AcquisationsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public AcquisationsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Acquisations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acquisation>>> GetAcquisations()
        {
            return await _context.Acquisations.ToListAsync();
        }

        // GET: api/Acquisations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acquisation>> GetAcquisation(int id)
        {
            var acquisation = await _context.Acquisations.FindAsync(id);

            if (acquisation == null)
            {
                return NotFound();
            }

            return acquisation;
        }

        // PUT: api/Acquisations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcquisation(int id, Acquisation acquisation)
        {
            if (id != acquisation.Id)
            {
                return BadRequest();
            }

            _context.Entry(acquisation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcquisationExists(id))
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

        // POST: api/Acquisations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acquisation>> PostAcquisation(Acquisation acquisation)
        {
            _context.Acquisations.Add(acquisation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AcquisationExists(acquisation.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAcquisation", new { id = acquisation.Id }, acquisation);
        }

        // DELETE: api/Acquisations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcquisation(int id)
        {
            var acquisation = await _context.Acquisations.FindAsync(id);
            if (acquisation == null)
            {
                return NotFound();
            }

            _context.Acquisations.Remove(acquisation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcquisationExists(int id)
        {
            return _context.Acquisations.Any(e => e.Id == id);
        }
    }
}
