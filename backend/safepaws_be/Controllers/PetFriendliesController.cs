using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Features;
using Newtonsoft.Json;
using NetTopologySuite.Geometries; 
using safepaws_be.Data;
using safepaws_be.Models;

namespace safepaws_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetFriendliesController : ControllerBase
    {
        private readonly SafepawsContext _context;

        public PetFriendliesController(SafepawsContext context)
        {
            _context = context;
        }

        // GET: api/PetFriendlies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetFriendly>>> GetPetFriendlies()
        {
            var feature = await _context.PetFriendlies.ToListAsync();
            var features = feature.Select(record =>
            {

                if (record.Geom == null)
                {
                    return null;
                }

                if (record.Geom is Point Point)

                {
                    var geojsonPoint = new
                    {
                        type = "Point",
                        coordinates = new[] { record.Geom.X, record.Geom.Y }
                    };

                    var properties = new Dictionary<string, object>
                    {
                        { "Id", record.Id },
                        { "Business Name", record.Businessname },
                        { "Date", record.Date }
                    };

                    // Create a GeoJSON Feature
                    return new
                    {
                        type = "Feature",
                        geometry = geojsonPoint,
                        properties
                    };
                }

                return null;
            })
            .Where(feature => feature != null)
            .ToList();

            //Create a FeatureCollection
            var featureCollection = new
            {
                type = "FeatureCollection",
                features
            };
            //Serialize to GeoJSON
            var geoJson = JsonConvert.SerializeObject(featureCollection, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            // Return GeoJSON with appropriate content type
            return Content(geoJson, "application/json");
        }

        // GET: api/PetFriendlies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetFriendly>> GetPetFriendly(int id)
        {
            var petFriendly = await _context.PetFriendlies.FindAsync(id);

            if (petFriendly == null)
            {
                return NotFound();
            }

            return petFriendly;
        }

        // PUT: api/PetFriendlies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetFriendly(int id, PetFriendly petFriendly)
        {
            if (id != petFriendly.Id)
            {
                return BadRequest();
            }

            _context.Entry(petFriendly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetFriendlyExists(id))
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

        // POST: api/PetFriendlies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PetFriendly>> PostPetFriendly(PetFriendly petFriendly)
        {
            _context.PetFriendlies.Add(petFriendly);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetFriendly", new { id = petFriendly.Id }, petFriendly);
        }

        // DELETE: api/PetFriendlies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetFriendly(int id)
        {
            var petFriendly = await _context.PetFriendlies.FindAsync(id);
            if (petFriendly == null)
            {
                return NotFound();
            }

            _context.PetFriendlies.Remove(petFriendly);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetFriendlyExists(int id)
        {
            return _context.PetFriendlies.Any(e => e.Id == id);
        }
    }
}
