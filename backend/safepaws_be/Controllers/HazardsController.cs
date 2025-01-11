using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using safepaws_be.Data;
using safepaws_be.Models;

namespace safepaws_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HazardsController : ControllerBase
    {
        private readonly SafepawsContext _context;

        public HazardsController(SafepawsContext context)
        {
            _context = context;
        }

        // GET: api/Hazards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hazard>>> GetHazards()
        {
            return await _context.Hazards.ToListAsync();
        }

        // GET: api/Hazards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hazard>> GetHazard(int id)
        {
            var hazard = await _context.Hazards.FindAsync(id);

            if (hazard == null)
            {
                return NotFound();
            }

            return hazard;
        }

        // PUT: api/Hazards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHazard(int id, Hazard hazard)
        {
            if (id != hazard.Id)
            {
                return BadRequest();
            }

            _context.Entry(hazard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HazardExists(id))
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

        // POST: api/Hazards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hazard>> PostHazard(Hazard hazard)
        {
            _context.Hazards.Add(hazard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHazard", new { id = hazard.Id }, hazard);
        }

        // DELETE: api/Hazards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHazard(int id)
        {
            var hazard = await _context.Hazards.FindAsync(id);
            if (hazard == null)
            {
                return NotFound();
            }

            _context.Hazards.Remove(hazard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HazardExists(int id)
        {
            return _context.Hazards.Any(e => e.Id == id);
        }
    }
}
