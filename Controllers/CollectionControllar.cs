using AshaApi.Data;
using CollectionFormApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollectionFormApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CollectionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Collection
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collection>>> GetAll()
        {
            var list = await _context.Collections.ToListAsync();

            if (list == null || !list.Any())
                return NotFound("No Collection found.");

            return Ok(list);
        }

        // GET: api/Collection/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Collection>> GetById(int id)
        {
            var collection = await _context.Collections.FindAsync(id);

            if (collection == null)
                return NotFound();

            return Ok(collection);
        }

        // POST: api/Collection
        [HttpPost]
        public async Task<ActionResult<Collection>> Create([FromBody] Collection collection)
        {
            if (collection == null)
                return BadRequest("Invalid Collection data.");

            collection.CreatedAt = DateTime.UtcNow;
            collection.UpdatedAt = DateTime.UtcNow;

            await _context.Collections.AddAsync(collection);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = collection.Id }, collection);
        }

        // PUT: api/Collection/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Collection collection)
        {
            if (id != collection.Id)
                return BadRequest("Collection ID mismatch.");

            var existingCollection = await _context.Collections.FindAsync(id);
            if (existingCollection == null)
                return NotFound("Collection not found.");

            collection.UpdatedAt = DateTime.UtcNow;

            _context.Entry(existingCollection).CurrentValues.SetValues(collection);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}