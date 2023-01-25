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
    public class RedactionsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public RedactionsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Redactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Redaction>>> GetRedactions()
        {
            return await _context.Redactions.ToListAsync();
        }

        // GET: api/Redactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Redaction>> GetRedaction(int id)
        {
            var redaction = await _context.Redactions.FindAsync(id);

            if (redaction == null)
            {
                return NotFound();
            }

            return redaction;
        }

        // PUT: api/Redactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRedaction(int id, Redaction redaction)
        {
            if (id != redaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(redaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RedactionExists(id))
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

        // POST: api/Redactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Redaction>> PostRedaction(Redaction redaction)
        {
            _context.Redactions.Add(redaction);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RedactionExists(redaction.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRedaction", new { id = redaction.Id }, redaction);
        }

        // DELETE: api/Redactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRedaction(int id)
        {
            var redaction = await _context.Redactions.FindAsync(id);
            if (redaction == null)
            {
                return NotFound();
            }

            _context.Redactions.Remove(redaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RedactionExists(int id)
        {
            return _context.Redactions.Any(e => e.Id == id);
        }
    }
}
