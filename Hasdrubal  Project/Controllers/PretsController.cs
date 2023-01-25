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
    public class PretsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public PretsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Prets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pret>>> GetPrets()
        {
            return await _context.Prets.ToListAsync();
        }

        // GET: api/Prets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pret>> GetPret(int id)
        {
            var pret = await _context.Prets.FindAsync(id);

            if (pret == null)
            {
                return NotFound();
            }

            return pret;
        }

        // PUT: api/Prets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPret(int id, Pret pret)
        {
            if (id != pret.Id)
            {
                return BadRequest();
            }

            _context.Entry(pret).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PretExists(id))
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

        // POST: api/Prets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pret>> PostPret(Pret pret)
        {
            _context.Prets.Add(pret);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPret", new { id = pret.Id }, pret);
        }

        // DELETE: api/Prets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePret(int id)
        {
            var pret = await _context.Prets.FindAsync(id);
            if (pret == null)
            {
                return NotFound();
            }

            _context.Prets.Remove(pret);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PretExists(int id)
        {
            return _context.Prets.Any(e => e.Id == id);
        }
    }
}
