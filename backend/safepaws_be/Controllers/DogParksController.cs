using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Features;
using Newtonsoft.Json;
using safepaws_be;
using safepaws_be.Data;

namespace safepaws_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogParksController : ControllerBase
    {
        private readonly SafepawsContext _context;

        public DogParksController(SafepawsContext context)
        {
            _context = context;
        }

        // GET: api/DogParks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogPark>>> GetDogParks()
        {
            var feature = await _context.DogParks.ToListAsync();
            var features = feature.Select(record =>
            {
                if (record.Geom == null)
                    return null;

                if (record.Geom is NetTopologySuite.Geometries.Polygon polygon)
                {
                    var polygonCoord = new List<List<Double[]>>()
                    {
                        polygon.ExteriorRing.Coordinates
                                .Select(coord => new[] { coord.X, coord.Y }) // Flip to [latitude, longitude]
                                .ToList()
                    };

                    var geoJsonPolygon = new
                    {
                        type = "Polygon",
                        coordinates = polygonCoord
                    };

                    // Add additional properties from your model
                    var properties = new Dictionary<string, object>
                    {
                        { "Id", record.Id },
                        { "Category", record.Category },
                        { "CivicNo", record.CivicNo },
                        { "Status", record.Status },
                        { "Municipality", record.MunicipalFacility },
                        { "OWernship", record.Ownership },
                        { "CreateDate", record.CreateDate },
                        { "UpdateDate", record.UpdateDate }
                    };

                    // Create a GeoJSON Feature
                    return new
                    {
                        type = "Feature",
                        geometry = polygonCoord,
                        properties
                    };
                }

                return null;
            })
                .Where(feature => feature != null) // Filter out null features
                .ToList();

            var featureCollection = new
            {
                type = "FeatureCollection",
                features
            };

            // Serialize to GeoJSON
            var geoJson = JsonConvert.SerializeObject(featureCollection);

            // Return GeoJSON with the appropriate content type
            return Content(geoJson, "application/json");
        }
        

        // GET: api/DogParks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DogPark>> GetDogPark(int id)
        {
            var dogPark = await _context.DogParks.FindAsync(id);

            if (dogPark == null)
            {
                return NotFound();
            }

            return dogPark;
        }

        // PUT: api/DogParks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogPark(int id, DogPark dogPark)
        {
            if (id != dogPark.Id)
            {
                return BadRequest();
            }

            _context.Entry(dogPark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogParkExists(id))
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

        // POST: api/DogParks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DogPark>> PostDogPark(DogPark dogPark)
        {
            _context.DogParks.Add(dogPark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogPark", new { id = dogPark.Id }, dogPark);
        }

        // DELETE: api/DogParks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogPark(int id)
        {
            var dogPark = await _context.DogParks.FindAsync(id);
            if (dogPark == null)
            {
                return NotFound();
            }

            _context.DogParks.Remove(dogPark);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogParkExists(int id)
        {
            return _context.DogParks.Any(e => e.Id == id);
        }
    }
}
