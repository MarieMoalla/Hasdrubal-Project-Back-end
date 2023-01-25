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
    public class BibliographiesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public BibliographiesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Bibliographies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bibliographie>>> GetBibliographies()
        {
            return await _context.Bibliographies.ToListAsync();
        }

        // GET: api/Bibliographies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bibliographie>> GetBibliographie(int id)
        {
            var bibliographie = await _context.Bibliographies.FindAsync(id);

            if (bibliographie == null)
            {
                return NotFound();
            }

            return bibliographie;
        }

        // PUT: api/Bibliographies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBibliographie(int id, Bibliographie bibliographie)
        {
            if (id != bibliographie.Id)
            {
                return BadRequest();
            }

            _context.Entry(bibliographie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BibliographieExists(id))
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

        // POST: api/Bibliographies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bibliographie>> PostBibliographie(Bibliographie bibliographie)
        {
            _context.Bibliographies.Add(bibliographie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BibliographieExists(bibliographie.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBibliographie", new { id = bibliographie.Id }, bibliographie);
        }

        // DELETE: api/Bibliographies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBibliographie(int id)
        {
            var bibliographie = await _context.Bibliographies.FindAsync(id);
            if (bibliographie == null)
            {
                return NotFound();
            }

            _context.Bibliographies.Remove(bibliographie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BibliographieExists(int id)
        {
            return _context.Bibliographies.Any(e => e.Id == id);
        }
    }
}
