using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using safepaws_be.Data;
using safepaws_be.Models;
using Newtonsoft.Json;
using NetTopologySuite.Geometries;

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
            var feature =  await _context.Hazards.ToListAsync();
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
                        { "Intersection", record.UniqueId },
                        { "Type", record.GlassTrash }, 
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
