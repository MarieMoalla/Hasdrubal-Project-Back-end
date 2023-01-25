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
    public class RestaurationsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public RestaurationsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Restaurations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restauration>>> GetRestaurations()
        {
            return await _context.Restaurations.ToListAsync();
        }

        // GET: api/Restaurations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restauration>> GetRestauration(int id)
        {
            var restauration = await _context.Restaurations.FindAsync(id);

            if (restauration == null)
            {
                return NotFound();
            }

            return restauration;
        }

        // PUT: api/Restaurations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestauration(int id, Restauration restauration)
        {
            if (id != restauration.Id)
            {
                return BadRequest();
            }

            _context.Entry(restauration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurationExists(id))
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

        // POST: api/Restaurations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Restauration>> PostRestauration(Restauration restauration)
        {
            _context.Restaurations.Add(restauration);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RestaurationExists(restauration.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRestauration", new { id = restauration.Id }, restauration);
        }

        // DELETE: api/Restaurations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestauration(int id)
        {
            var restauration = await _context.Restaurations.FindAsync(id);
            if (restauration == null)
            {
                return NotFound();
            }

            _context.Restaurations.Remove(restauration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurationExists(int id)
        {
            return _context.Restaurations.Any(e => e.Id == id);
        }
    }
}
