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
    public class OeuvresController : ControllerBase
    {
        private readonly AppDBContext _context;

        public OeuvresController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Oeuvres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oeuvre>>> GetOeuvres()
        {
            return await _context.Oeuvres.ToListAsync();
        }

        // GET: api/Oeuvres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oeuvre>> GetOeuvre(int id)
        {
            var oeuvre = await _context.Oeuvres.FindAsync(id);

            if (oeuvre == null)
            {
                return NotFound();
            }

            return oeuvre;
        }

        // PUT: api/Oeuvres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOeuvre(int id, Oeuvre oeuvre)
        {
            if (id != oeuvre.Id)
            {
                return BadRequest();
            }

            _context.Entry(oeuvre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OeuvreExists(id))
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

        // POST: api/Oeuvres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Oeuvre>> PostOeuvre(Oeuvre oeuvre)
        {
            _context.Oeuvres.Add(oeuvre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOeuvre", new { id = oeuvre.Id }, oeuvre);
        }

        // DELETE: api/Oeuvres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOeuvre(int id)
        {
            var oeuvre = await _context.Oeuvres.FindAsync(id);
            if (oeuvre == null)
            {
                return NotFound();
            }

            _context.Oeuvres.Remove(oeuvre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OeuvreExists(int id)
        {
            return _context.Oeuvres.Any(e => e.Id == id);
        }
    }
}
