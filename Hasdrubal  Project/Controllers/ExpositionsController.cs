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
    public class ExpositionsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ExpositionsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Expositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exposition>>> GetExpositions()
        {
            return await _context.Expositions.ToListAsync();
        }

        // GET: api/Expositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exposition>> GetExposition(int id)
        {
            var exposition = await _context.Expositions.FindAsync(id);

            if (exposition == null)
            {
                return NotFound();
            }

            return exposition;
        }

        // PUT: api/Expositions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExposition(int id, Exposition exposition)
        {
            if (id != exposition.Id)
            {
                return BadRequest();
            }

            _context.Entry(exposition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpositionExists(id))
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

        // POST: api/Expositions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exposition>> PostExposition(Exposition exposition)
        {
            _context.Expositions.Add(exposition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExposition", new { id = exposition.Id }, exposition);
        }

        // DELETE: api/Expositions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExposition(int id)
        {
            var exposition = await _context.Expositions.FindAsync(id);
            if (exposition == null)
            {
                return NotFound();
            }

            _context.Expositions.Remove(exposition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpositionExists(int id)
        {
            return _context.Expositions.Any(e => e.Id == id);
        }
    }
}
